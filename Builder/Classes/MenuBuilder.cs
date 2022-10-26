using AtlusFileSystemLibrary;
using AtlusFileSystemLibrary.Common.IO;
using AtlusFileSystemLibrary.FileSystems.PAK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public class MenuBuilder
    {
        public static int msgIndex;

        public static string assetsDir;
        public static string scriptsDir;
        public static string outputDir;
        
        public static void Build()
        {
            // Set build paths
            assetsDir = Path.Combine(Program.exeDir, "Assets");
            scriptsDir = Path.Combine(Program.exeDir, "Scripts");

            // Set output path if specified by user
            if (Program.Options.Output != "")
            {
                Directory.CreateDirectory(Program.Options.Output);
                outputDir = Program.Options.Output;
            }

            UnpackPACs(); // Get .bf files from .PAC files
            ProcessScripts(); // Enable/disable game-specific elements of Mod Menu .flow/.msg and reindex .msg files

            Output.Log("\nDone!", ConsoleColor.Green);

            #if DEBUG
                Console.ReadKey(); // wait for input before closing if debug build
            #endif
        }

        public static void UnpackPACs()
        {
            // Extract .bf files from each .PAC in Assets folder
            foreach (var pac in Directory.GetFiles(assetsDir, "*.pac", SearchOption.AllDirectories))
            {
                PAKFileSystem pak = new PAKFileSystem();
                if (PAKFileSystem.TryOpen(pac, out pak))
                {
                    Output.Log($"Unpacking: {pac}");

                    foreach (var fileInPAC in pak.EnumerateFiles())
                    {
                        string normalizedFilePath = fileInPAC.Replace("../", ""); //Remove backwards relative path
                        string outputPath = Path.Combine(Path.GetDirectoryName(pac), normalizedFilePath);

                        using (var stream = FileUtils.Create(outputPath))
                        using (var inputStream = pak.OpenFile(fileInPAC))
                        {
                            inputStream.CopyTo(stream);
                            Output.Log($"Extracted {Path.GetFileName(normalizedFilePath)} to:\n  {outputPath}", ConsoleColor.Green);
                        }
                    }
                }
            }
        }

        private static void ProcessScripts()
        {
            foreach (var script in Directory.GetFiles(scriptsDir,
                "*.flow", SearchOption.AllDirectories))
            {
                RemoveFlowComments(script); // Removes lines with a "/* Royal */" or "/* Vanilla */" comment from .flow depending on 
                if (Program.SelectedGame.Type.Equals("Royal"))
                    Royalify(script); // Update flag IDs from PS3 to Royal
            }
            
            foreach (var script in Directory.GetFiles(scriptsDir))
            {
                RemoveMsgComments(script); // Removes lines with a "// Royal" or "// Vanilla" comment from .msg depending on version
                ReplaceJoypadKeys(script); // Change joypad button names depending on options
            }

            // Reindex and compile each Hook script
            foreach (var script in Directory.GetFiles(Path.Combine(scriptsDir, "Hook"), 
                "*.flow", SearchOption.AllDirectories))
            {
                Output.Log($"Processing Hook script:\n  {script}");

                // Set index of messages to start at when reindexing .msg files
                msgIndex = 90;
                if (Program.SelectedGame.Type.Equals("Royal"))
                    msgIndex = 181;
                Output.VerboseLog($"\tmsgIndex: {msgIndex}");

                RecursivelyReindexMsgs(script); // Re-number HELP message names in referenced .msg files
                CompileHookScript(script); // Create new .bf in output folder

                Output.Log($"Done processing script.", ConsoleColor.Green);
            }

            Output.Log($"Finished processing Mod Menu scripts.", ConsoleColor.Green);
        }

        private static void RecursivelyReindexMsgs(string script)
        {
            if (script.EndsWith(".msg"))
            {
                Output.VerboseLog($"\tRecursively Reindexing .Msg: {script}\n\tmsgIndex: {msgIndex}");
                ReindexMsg(script);
            }
            else if (script.EndsWith(".flow"))
            {
                foreach (var line in File.ReadAllLines(script))
                {
                    if (line.Contains(".msg\""))
                        RecursivelyReindexMsgs(Path.Combine(Path.GetDirectoryName(script), line.Replace("import(\"", "").Replace("\");", "")));
                    if (line.Contains(".flow\""))
                        RecursivelyReindexMsgs(Path.Combine(Path.GetDirectoryName(script), line.Replace("import(\"", "").Replace("\");", "")));
                }
            }
        }

        private static void ReplaceJoypadKeys(string script)
        {
            if (Program.Options.Joypad != "PS" && File.Exists(script) && script.EndsWith(".msg"))
            {
                var lines = File.ReadAllLines(script);
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (Program.Options.Joypad == "MS")
                        line.Replace("□", "X").Replace("△", "Y").Replace("○", "B").Replace("╳","A");
                    if (Program.Options.Joypad == "NX")
                        line.Replace("□", "Y").Replace("△", "X").Replace("○", "A").Replace("╳", "B");
                    newLines.Add(line);
                }
                File.WriteAllText(script, String.Join("\n", newLines), Encoding.Unicode);
                Output.Log($"  Done changing joypad button names in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"  Could not find script to change joypad button names in: {script}", ConsoleColor.Red);
        }

        private static void Royalify(string script)
        {
            Output.Log($"  Looking for Royal bitflags in:\n  {script}");

            if (File.Exists(script))
            {
                var lines = File.ReadAllLines(script);
                List<string> newLines = new List<string>();

                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i].Trim();
                    if (line.StartsWith("BIT_OFF(") || line.StartsWith("BIT_ON(") || line.StartsWith("ToggleFlag("))
                    {
                        // Attempt to convert vanilla bitflag to Royal flag
                        string flag = Flag.Get(line);
                        int convertedFlag = -1;
                        try
                        {
                            convertedFlag = Flag.ConvertToRoyal(Convert.ToInt32(flag));
                        }
                        catch { }

                        if (convertedFlag != -1 && convertedFlag.ToString() != flag) // Replace line and notify user of this change
                        {
                            Output.Log($"  Replaced Vanilla bitflag ({flag}) with Royal bitflag ({convertedFlag}).");
                            newLines.Add(lines[i].Replace(flag, convertedFlag.ToString()));
                        }
                        else // Use original flag if flag could not be converted to Royal
                            newLines.Add(lines[i]);
                    }
                    else // Add original line if no changes needed
                        newLines.Add(lines[i]);
                }

                File.WriteAllText(script, String.Join("\n", newLines), Encoding.Unicode);
                Output.Log($"  Done converting Royal bitflags in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"  Could not find script: {script}", ConsoleColor.Red);
        }

        private static void RemoveMsgComments(string script)
        {
            Output.Log($"  Looking for version-specific commented lines in:\n  {script}");

            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
                removeType = "Royal";

            if (File.Exists(script))
            {
                // Remove entire line if opposite type
                var lines = File.ReadAllLines(script);
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                    if (!lines[i].Contains($"// {removeType}") && !lines[i].Contains($"//{removeType}"))
                        newLines.Add(lines[i]);

                // Remove comments from line for matching type and overwrite file
                File.WriteAllText(script, String.Join("\n", newLines)
                    .Replace($"// {Program.SelectedGame.Type}", "").Replace($"//{Program.SelectedGame.Type}", ""), Encoding.Unicode);

                Output.Log($"  Finished commenting out version-specific lines in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"Could not find script to remove .msg comments from:\n  {script}", ConsoleColor.Red);
        }

        private static void RemoveFlowComments(string script)
        {
            Output.Log($"  Looking for version-specific commented codeblocks in:\n  {script}");

            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
                removeType = "Royal";

            if (File.Exists(script))
            {
                // Comment out blocks for opposing game type
                File.WriteAllText(script, File.ReadAllText(script)
                    .Replace($"/* {removeType} Start */", $"/* {removeType} Start ")
                    .Replace($"/* {removeType} End */", $" {removeType} End */"), Encoding.Unicode);

                Output.Log($"  Finished commenting out version-specific codeblocks in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"Could not find script to remove .flow comments from:\n  {script}", ConsoleColor.Red);
        }

        public static void ReindexMsg(string script)
        {
            if (File.Exists(script))
            {
                // Update parameters of msg functions that displays description for menu selection
                Output.Log($"  Updating .msg index parameters in:" +
                    $"\n  {Path.GetFileName(script)}" +
                    $"\n  Starting from: {msgIndex}");

                var msgLines = File.ReadAllLines(script);
                int refCount = 0; // Keep track of total number of references per selection block

                for (int i = 0; i < msgLines.Length; i++)
                {
                    // Increase total number of messages so far
                    if (msgLines[i].Contains("[dlg ") || msgLines[i].Contains("[sel "))
                        msgIndex++;

                    // If current line contains "[ref "...
                    if (msgLines[i].Contains("[ref "))
                    {
                        // Reset reference count
                        refCount = 0;

                        // For each line containing "[ref " until file ends or a line doesn't contain "[ref "...
                        while (i + 1 < msgLines.Length && msgLines[i].Contains("[ref "))
                        {
                            // Separate part of string after "[ref "
                            int refIndex = msgLines[i].IndexOf("[ref ");
                            string substring = msgLines[i].Substring(refIndex);
                            // Create new second half of string
                            string newString = $"[ref {refCount} {msgIndex + refCount}][e]";
                            string newLine = msgLines[i].Remove(refIndex);
                            // Increase number of ref lines read so far for this sel block
                            refCount++;
                            // Update line with new data
                            msgLines[i] = newLine + newString;
                            // Increase current line number
                            i++;
                        }
                    }

                    if (msgLines[i].Contains("[dlg GENERIC_HELP_"))
                        msgLines[i] = $"[dlg GENERIC_HELP_{msgIndex}]";
                }

                File.WriteAllText(script, string.Join("\n", msgLines), Encoding.Unicode);
            }
        }

        private static void CompileHookScript(string script)
        {
            string outDir = Program.Options.Output;
            string outputFile = Path.Combine(outDir, Path.Combine(Path.GetDirectoryName(script), Path.GetFileNameWithoutExtension(script) + ".bf").Replace(Exe.Directory() + "\\Scripts\\Hook\\", ""));

            string[] args = new string[] {
            $"\"{script}\"", "-Compile",
            "-OutFormat", "V3BE",
            "-Encoding", Program.Options.Encoding,
            "-Library", Program.SelectedGame.ShortName,
            "-Out", $"\"{outputFile}\"",
            "-Hook" };

            Output.Log($"Compiling script: {script}");
            Output.VerboseLog($"\targs: {string.Join(" ", args)}");
            Exe.Run(Program.Options.Compiler, string.Join(" ", args));
        }
    }
}

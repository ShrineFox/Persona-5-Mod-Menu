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
using System.Text.RegularExpressions;

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
            foreach (var pac in Directory.GetFiles(assetsDir, "*.pac", SearchOption.AllDirectories).Where(x => x.Contains(Program.SelectedGame.Type.ToString())))
            {
                PAKFileSystem pak = new PAKFileSystem();
                if (PAKFileSystem.TryOpen(pac, out pak))
                {
                    foreach (var fileInPAC in pak.EnumerateFiles())
                    {
                        string normalizedFilePath = fileInPAC.Replace("../", ""); //Remove backwards relative path
                        string outputPath = Path.Combine(Path.GetDirectoryName(pac), normalizedFilePath);

                        using (var stream = FileUtils.Create(outputPath))
                        using (var inputStream = pak.OpenFile(fileInPAC))
                        {
                            inputStream.CopyTo(stream);
                        }
                    }
                }
                Output.Log($"Unpacked .PAC: {pac}", ConsoleColor.Green);
            }
        }

        private static void ProcessScripts()
        {
            foreach (var script in Directory.GetFiles(scriptsDir,
                "*.flow", SearchOption.AllDirectories))
            {
                using (FileSys.WaitForFile(script)) { }
                RemoveFlowComments(script); // Removes lines with a "/* Royal */" or "/* Vanilla */" comment from .flow depending on 
                using (FileSys.WaitForFile(script)) { }
                if (Program.SelectedGame.Type.Equals("Royal"))
                    Royalify(script); // Update flag IDs from PS3 to Royal
            }
            
            foreach (var script in Directory.GetFiles(scriptsDir))
            {
                using (FileSys.WaitForFile(script)) { }
                RemoveMsgComments(script); // Removes lines with a "// Royal" or "// Vanilla" comment from .msg depending on version
                using (FileSys.WaitForFile(script)) { }
                ReplaceJoypadKeys(script); // Change joypad button names depending on options
            }

            // Reindex and compile each Hook script
            foreach (var script in Directory.GetFiles(Path.Combine(scriptsDir, "Hook"), 
                "*.flow", SearchOption.AllDirectories))
            {
                using (FileSys.WaitForFile(script)) { }
                // Reset index of messages to start at
                msgIndex = -1;
                // Re-number HELP message names in referenced .msg files
                var msgs = RecursivelyGetMsgs(script);
                foreach (var msg in msgs)
                    ReindexMsg(msg);
                Compile(script); // Create new .bf in output folder
            }
        }

        private static List<string> RecursivelyGetMsgs(string script)
        {
            List<string> msgPaths = new List<string>();
            if (script.EndsWith(".msg"))
            {
                Output.Log($"Adding .msg: {script}");
                msgPaths.Add(script);
            }
            else if (script.EndsWith(".flow"))
            {
                foreach (var line in File.ReadAllLines(script))
                {
                    if (line.Contains(".bf\""))
                    {
                        string relativePath = line.Replace("import(\"", "").Replace("import( \"", "").Replace("\");", "").Replace("\" );", "").Replace('/', '\\');
                        string path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(script), relativePath));
                        Decompile(path);
                        using (FileSys.WaitForFile(path + ".flow")) { }
                        if (File.Exists(path + ".msg"))
                        {
                            Output.Log($"Adding .msg: {path + ".msg"}");
                            msgPaths.Add(path + ".msg");
                        }
                    }
                    else if (line.Contains(".msg\"") || line.Contains(".flow\""))
                    {
                        string relativePath = line.Replace("import(\"", "").Replace("import( \"", "").Replace("\");", "").Replace("\" );", "").Replace('/', '\\');
                        string path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(script), relativePath));
                        foreach (var msg in RecursivelyGetMsgs(path))
                            msgPaths.Add(msg);
                    }
                }
            }

            return msgPaths;
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
                Output.Log($"\tDone changing joypad button names in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"\tCould not find script to change joypad button names in: {script}", ConsoleColor.Red);
        }

        private static void Royalify(string script)
        {
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

                        // Replace line and notify user of this change
                        if (convertedFlag != -1 && convertedFlag.ToString() != flag) 
                            newLines.Add(lines[i].Replace(flag, convertedFlag.ToString()));
                        else // Use original flag if flag could not be converted to Royal
                            newLines.Add(lines[i]);
                    }
                    else // Add original line if no changes needed
                        newLines.Add(lines[i]);
                }

                File.WriteAllText(script, String.Join("\n", newLines), Encoding.Unicode);
                Output.Log($"\tDone converting Royal bitflags in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"\tCould not find script to replace Royal bitflags in: {script}", ConsoleColor.Red);
        }

        private static void RemoveMsgComments(string script)
        {
            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
                removeType = "Royal";

            if (File.Exists(script))
            {
                var lines = File.ReadAllLines(script);
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    // Remove comments from line for matching type and overwrite file
                    line = line.Replace($"// {Program.SelectedGame.Type}", "").Replace($"//{Program.SelectedGame.Type}", "");
                    // Remove entire line if opposite type
                    if (!line.Contains($"// {removeType}") && line.Contains($"//{removeType}"))
                        newLines.Add(line);
                }
                    
                File.WriteAllText(script, String.Join("\n", newLines), Encoding.Unicode);
                Output.Log($"\tRemoved version-specific lines in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"\tCould not find script to remove .msg comments from:\n  {script}", ConsoleColor.Red);
        }

        private static void RemoveFlowComments(string script)
        { 
            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
                removeType = "Royal";

            if (File.Exists(script))
            {
                // Comment out blocks for opposing game type, and remove comments
                string text = RemoveBetween(File.ReadAllText(script)
                    .Replace($"/* {removeType} Start */", $"/* {removeType} Start ")
                    .Replace($"/* {removeType} End */", $" {removeType} End */"), "/*", "*/");

                File.WriteAllText(script, text, Encoding.Unicode);

                Output.Log($"\tRemoved version-specific codeblocks from:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"\tCould not find script to remove .flow comments from:\n  {script}", ConsoleColor.Red);
        }

        public static string RemoveBetween(string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.Singleline);
            return regex.Replace(sourceString, startTag + endTag);
        }

        public static void ReindexMsg(string script)
        {
            // Update parameters of msg functions that displays description for menu selection
            if (File.Exists(script))
            {
                var msgLines = File.ReadAllLines(script);

                for (int i = 0; i < msgLines.Length; i++)
                {
                    // Increase total number of messages so far
                    if (msgLines[i].Contains("[msg ") || msgLines[i].Contains("[dlg ") || msgLines[i].Contains("[sel "))
                    {
                        msgIndex++;
                    }

                    // If current line contains "[ref "...
                    if (msgLines[i].Contains("[ref "))
                    {
                        int refCount = 0; // Keep track of total number of references per selection block

                        // For each line containing "[ref " until file ends or a line doesn't contain "[ref "...
                        while (i + 1 < msgLines.Length && msgLines[i].Contains("[ref "))
                        {
                            // Separate part of string after "[ref "
                            int refIndex = msgLines[i].IndexOf("[ref ");
                            string substring = msgLines[i].Substring(refIndex);
                            // Create new second half of string
                            string newString = $"[ref {refCount} {msgIndex + refCount + 1}][e]";
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
                using (FileSys.WaitForFile(script)) { }
                Output.Log($"\tReindexed .msg files in: {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"\tFailed to reindex .msg, file not found: {script}", ConsoleColor.Red);
        }

        private static void Compile(string script)
        {
            string outDir = Program.Options.Output;
            string outputFile = Path.Combine(outDir, Path.Combine(Path.GetDirectoryName(script), Path.GetFileNameWithoutExtension(script) + ".bf").Replace(Exe.Directory() + "\\Scripts\\Hook\\", ""));
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            string[] args = new string[] {
                $"\"{script}\"", "-Compile",
                "-OutFormat", "V3BE",
                "-Encoding", Program.Options.Encoding,
                "-Library", Program.SelectedGame.ShortName,
                "-Out", $"\"{outputFile}\"",
                "-Hook" };

            Output.Log($"Compiling script: {script}", ConsoleColor.Yellow);
            Exe.Run(Program.Options.Compiler, string.Join(" ", args));

            using (FileSys.WaitForFile(outputFile)) { }
            if (File.Exists(outputFile))
            {
                Output.Log($"Compiled script successfully: {script}", ConsoleColor.Green);
                #if DEBUG
                    Decompile(outputFile); // Decompile newly generated script for debugging
                #endif
            }
            else
                Output.Log($"Failed to compile script: {script}", ConsoleColor.Red);

        }

        private static void Decompile(string bf)
        {
            string[] args = new string[] {
                $"\"{bf}\"", "-Deompile",
                "-Encoding", Program.Options.Encoding,
                "-Library", Program.SelectedGame.ShortName
            };

            Output.Log($"Deompiling script: {bf}");
            Output.VerboseLog($"\targs: {string.Join(" ", args)}");
            Exe.Run(Program.Options.Compiler, string.Join(" ", args));
        }
    }
}

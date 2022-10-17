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
        public static int reindexStart;

        public static string assetsDir;
        public static string scriptsDir;
        public static string tempDir;
        public static string outputDir;
        public static string tempAssetsDir;
        public static string tempScriptsDir;
        
        public static void Build()
        {
            // Set build paths
            assetsDir = Path.Combine(Program.exeDir, "Assets");
            scriptsDir = Path.Combine(Program.exeDir, "Scripts");
            tempDir = Path.Combine(Program.exeDir, "Temp");
            outputDir = Path.Combine(Program.exeDir, "Output");
            tempAssetsDir = Path.Combine(tempDir, "Assets");
            tempScriptsDir = Path.Combine(tempDir, "Scripts");

            // Set output path if specified by user
            if (Program.Options.Output != "")
            {
                Directory.CreateDirectory(Program.Options.Output);
                outputDir = Program.Options.Output;
            }

            // Set index of messages to start at when reindexing .msg files
            reindexStart = 90;
            if (Program.SelectedGame.Type.Equals("Royal"))
                reindexStart = 181;

            CreateTempFolder(); // Move Assets/Scripts to Temp dir for modification
            UnpackPACs(); // Get .bf files from .PAC files
            ProcessScripts(); // Enable/disable game-specific elements of Mod Menu .flow/.msg and reindex .msg files
            CompileHookScripts(); // Create new .bf files from hook .flow
            if (!Program.Options.Unpack && Program.SelectedGame.Platform != PlatformType.New) 
            {
                // Pack changed .bf files back into .PAC
                RepackPACs(); 
            }
            CopyToOutput(); // Copy changed files to output folder

            Output.Log("\nDone!", ConsoleColor.Green);

            #if DEBUG
                Console.ReadKey(); // wait for input before closing if debug build
            #endif
        }

        private static void CreateTempFolder()
        {
            // Create new Temp folder
            DeleteTempFolder();
            Output.Log($"Creating new Temp directory:\n  {tempDir}");
            Directory.CreateDirectory(tempDir);

            // Copy Assets and Scripts folders to Temp folder
            Output.Log($"Copying Assets to Temp/Assets directory:\n  {tempAssetsDir}");
            FileSys.CopyDir(assetsDir, tempAssetsDir);
            Output.Log($"Copying Scripts to Temp/Scripts directory:\n  {tempScriptsDir}");
            FileSys.CopyDir(scriptsDir, tempScriptsDir);
        }

        private static void DeleteTempFolder()
        {
            // Delete Temp folder and all contents
            Output.Log($"Deleting Temp directory:\n  {tempDir}");
            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, true);
        }

        public static void UnpackPACs()
        {
            // Extract .bf files from each .PAC in Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf") && x.Archive.EndsWith(".pac")))
            {
                string pacFilePath = $"{tempAssetsDir}\\{Program.SelectedGame.Type}\\{inputFile.Archive}";
                if (File.Exists(pacFilePath))
                {
                    PAKFileSystem pak = new PAKFileSystem();
                    if (PAKFileSystem.TryOpen(pacFilePath, out pak))
                    {
                        Output.Log($"Unpacking {inputFile.Archive}...");

                        foreach (var fileInPAC in pak.EnumerateFiles())
                        {
                            if (fileInPAC.EndsWith(inputFile.Name))
                            {
                                string normalizedFilePath = fileInPAC.Replace("../", ""); //Remove backwards relative path
                                string outputPath = Path.Combine(Path.GetDirectoryName(pacFilePath), normalizedFilePath);

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
                else
                    Output.Log($"Could not find input .PAC: {pacFilePath}", ConsoleColor.Red);
            }
        }

        private static void ProcessScripts()
        {
            Output.Log("Processing Mod Menu scripts...");

            // Get list of scripts to process
            List<string> scripts = new List<string>();
            foreach (var script in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
                scripts.Add($"{tempScriptsDir}\\Hooks\\{script.HookPath}\\{script.Name}.flow");
            foreach (var script in Program.Scripts)
                scripts.Add(script);

            // Process each script
            foreach (var script in scripts)
            {
                Output.Log($"Processing script:\n  {script}");

                if (Program.SelectedGame.Type.Equals("Royal"))
                    Royalify(script);
                RemoveFlowComments(script); // Removes lines with a "/* Royal */" or "/* Vanilla */" comment from .flow depending on version
                RemoveMsgComments(script.Replace(".flow",".msg")); // Removes lines with a "// Royal" or "// Vanilla" comment from .msg depending on version
                ReindexMsg(script.Replace(".flow", ".msg")); // Update .msg indexes of file depending on if Royal or Vanilla

                Output.Log($"Done processing script.", ConsoleColor.Green);
            }

            Output.Log($"Finished processing Mod Menu scripts.", ConsoleColor.Green);
        }

        private static void Royalify(string script)
        {
            script = Path.Combine(tempScriptsDir, script);

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

                File.WriteAllText(script, String.Join("\n", newLines));
                Output.Log($"  Done converting Royal bitflags in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"  Could not find script: {script}", ConsoleColor.Red);
        }

        private static void RemoveMsgComments(string script)
        {
            script = Path.Combine(tempScriptsDir, script);
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
                    .Replace($"// {Program.SelectedGame.Type}", "").Replace($"//{Program.SelectedGame.Type}", ""));

                Output.Log($"  Finished commenting out version-specific lines in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"Could not find script to remove .msg comments from:\n  {script}", ConsoleColor.Red);
        }

        private static void RemoveFlowComments(string script)
        {
            script = Path.Combine(tempScriptsDir, script);
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
                    .Replace($"/* {removeType} End */", $" {removeType} End */"));

                Output.Log($"  Finished commenting out version-specific codeblocks in:\n  {script}", ConsoleColor.Green);
            }
            else
                Output.Log($"Could not find script to remove .flow comments from:\n  {script}", ConsoleColor.Red);
        }

        public static void ReindexMsg(string script)
        {
            script = Path.Combine(tempScriptsDir, script);

            if (File.Exists(script))
            {
                // Update parameters of msg functions that displays description for menu selection
                Output.Log($"  Updating .msg index parameters in:" +
                    $"\n  {Path.GetFileName(script)}" +
                    $"\n  Starting from: {reindexStart}");

                var msgLines = File.ReadAllLines(script);
                int refCount = 0; // Keep track of total number of references per selection block

                for (int i = 0; i < msgLines.Length; i++)
                {
                    // Increase total number of messages so far
                    if (msgLines[i].Contains("[dlg ") || msgLines[i].Contains("[sel "))
                        reindexStart++;

                    // If current line contains "[ref "...
                    if (msgLines[i].Contains("[ref "))
                    {
                        // Reset reference count
                        refCount = 0;

                        // For each line containing "[ref " until file ends or a line doesn't contain "[ref "...
                        while (i + 1 < msgLines.Length && msgLines[i].Contains("[ref "))
                        {
                            // Separate part of string after "[ref "
                            int index = msgLines[i].IndexOf("[ref ");
                            string substring = msgLines[i].Substring(index);
                            // Create new second half of string
                            string newString = $"[ref {refCount} {reindexStart + refCount + 1}][e]";
                            string newLine = msgLines[i].Remove(index);
                            // Update line with new data
                            msgLines[i] = newLine + newString;
                            // Increase number of ref lines read so far for this sel block
                            refCount++;
                            // Increase current line number
                            i++;
                        }
                    }

                    if (msgLines[i].Contains("[dlg GENERIC_HELP_"))
                        msgLines[i] = $"[dlg GENERIC_HELP_{reindexStart}]";
                }

                File.WriteAllText(script, string.Join("\n", msgLines));
            }
        }

        private static void CompileHookScripts()
        {
            // Compile Mod Menu hook scripts and output to Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
            {
                string flowPath = $"{tempScriptsDir}\\Hooks\\{inputFile.HookPath}\\{inputFile.Name}.flow";
                if (File.Exists(flowPath))
                {
                    string[] args = new string[] {
                    $"\"{flowPath}\"", "-Compile",
                    "-OutFormat", "V3BE",
                    "-Encoding", Program.Options.Encoding,
                    "-Library", Program.SelectedGame.ShortName,
                    "-Out", $"\"{tempAssetsDir}\\{Program.SelectedGame.Type}\\{inputFile.Path}\\{inputFile.Name}.flow.bf\"",
                    "-Hook" };

                    Output.Log($"Compiling .\\Hooks\\{inputFile.HookPath}\\{inputFile.Name}.flow");
                    Output.VerboseLog($"\args:\n    {string.Join(" ", args)}");
                    Exe.Run(Program.Options.Compiler, string.Join("", args));
                }
                else
                    Output.Log($"Failed to compile {inputFile.Name}.flow.bf, could not find script:\n  {flowPath}", ConsoleColor.Red);

            }
        }

        private static void RepackPACs()
        {
            // Replace .bf files in each PAC with ones from Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf") && x.Archive.EndsWith(".pac")))
            {
                string pacPath = $"{tempAssetsDir}\\{Program.SelectedGame.Type}\\{inputFile.Archive}";
                string bfPath = $"{tempAssetsDir}\\{Program.SelectedGame.Type}\\{inputFile.Path}\\{inputFile.Name}.flow.bf";

                if (File.Exists(pacPath))
                {
                    if (File.Exists(bfPath))
                    {
                        Output.Log($"Attempting to replace {inputFile.Name} in {inputFile.Archive} with:\n  {bfPath}");

                        PAKFileSystem pak = new PAKFileSystem();
                        if (PAKFileSystem.TryOpen(pacPath, out pak))
                        {
                            PAKFileSystem newPak = pak;

                            if (pak.EnumerateFiles().Any(x => x.EndsWith(inputFile.Name)))
                            {
                                string pakFilePath = pak.EnumerateFiles().First(x => x.EndsWith(inputFile.Name));
                                newPak.AddFile(pakFilePath, bfPath, ConflictPolicy.Replace);
                                Output.Log($"  Replaced {inputFile.Name} in {inputFile.Archive}");

                                string outputPath = Path.Combine(outputDir, inputFile.Archive);
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                                newPak.Save(outputPath);
                                Output.Log($"  Saved repacked PAC to output folder: {outputPath}", ConsoleColor.Green);
                            }
                            else
                                Output.Log($"  Could not find any file ending with {inputFile.Name} in: {pacPath}", ConsoleColor.Red);
                        }
                        else
                            Output.Log($"Failed to open .PAC for repacking:\n  {pacPath}", ConsoleColor.Red);
                    }
                    else
                        Output.Log($"Failed to replace {inputFile.Name} in {inputFile.Archive}, could not find compiled .BF:\n  {bfPath}", ConsoleColor.Red);
                }
                else
                    Output.Log($"Failed to repack PAC, could not find archive:\n  {pacPath}", ConsoleColor.Red);
            }
        }

        private static void CopyToOutput()
        {
            // Move non-PAC (i.e. .SPD) Asset files for appropriate game version to output directory
            // (repacked .PACs are already in Output directory by now)
            foreach (InputFile inputFile in Program.InputFiles)
            {
                string inputPath = $"{tempAssetsDir}\\{Program.SelectedGame.Type}\\{inputFile.Path}\\{inputFile.Name}";
                // Use compiled .bf as output for introduction script that enabled mod menu, since it doesn't go in a .PAC
                // If repacking was skipped by user, use compiled .bf for every input file except .SPD
                if (!inputFile.Archive.EndsWith(".pac") || Program.Options.Unpack)
                {
                    if (!inputFile.Path.Equals("camp\\shared"))
                        inputPath += ".flow.bf";
                    string outputPath = Path.Combine(outputDir, Path.Combine(inputFile.Path, inputFile.Name));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    Output.Log($"Copying file from: {inputPath}\n  to: {outputPath}");
                    File.Copy(inputPath, outputPath, true);
                }
            }
        }
    }
}

using AtlusFileSystemLibrary;
using AtlusFileSystemLibrary.Common.IO;
using AtlusFileSystemLibrary.FileSystems.PAK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMenuBuilder
{
    public class MenuBuilder
    {
        public static void Build()
        {
            CreateTempFolder(); // Move Assets/Scripts to Temp dir for modification
            UnpackPACs(); // Get .bf files from .PAC files
            RoyalifyScripts(); // Enable Royal-only elements of Mod Menu .flow/.msg
            RemoveFlowComments(); // Removes lines with a "/* Royal */" or "/* Vanilla */" comment from Mod Menu .flow depending on version
            RemoveMsgComments(); // Removes lines with a "// Royal" or "// Vanilla" comment from Mod Menu .msg depending on version
            UpdateImportPaths(); // Remove or update .flow/.msg import paths depending on if Royal or Vanilla
            ReindexMsgs(); // Update .msg indexes of files depending on if Royal or Vanilla
            CompileScripts(); // Create new .bf files from modified .flow
            RepackPACs(); // Pack changed .bf files back into .PAC
            CopyToOutput(); // Copy changed files to output folder

            Console.WriteLine("\nDone!");

            #if DEBUG
                Console.ReadKey(); // wait for input before closing if debug build
            #endif
        }

        private static void CreateTempFolder()
        {
            DeleteTempFolder();
            // Create new Temp folder
            Console.WriteLine("Creating new Temp directory");
            Directory.CreateDirectory("Temp");
            // Copy Assets and Scripts folders to Temp folder
            Console.WriteLine("Copying Assets to Temp/Assets directory");
            Tools.CopyDir("Assets", "Temp/Assets");
            Console.WriteLine("Copying Scripts to Temp/Scripts directory");
            Tools.CopyDir("Scripts", "Temp/Scripts");
        }

        private static void DeleteTempFolder()
        {
            // Delete Temp folder and all contents
            Console.WriteLine("Deleting Temp directory");
            if (Directory.Exists("Temp"))
                Directory.Delete("Temp", true);
        }

        public static void UnpackPACs()
        {
            // Extract .bf files from each PAC in Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf") && x.Archive.EndsWith(".pac")))
            {
                string pacFilePath = Path.Combine($"Temp\\Assets\\{Program.SelectedGame.Type}\\{inputFile.Path}", inputFile.Archive);
                if (File.Exists(pacFilePath))
                {
                    PAKFileSystem pak = new PAKFileSystem();
                    if (PAKFileSystem.TryOpen(pacFilePath, out pak))
                    {
                        Console.WriteLine($"Unpacking {inputFile.Archive}...");

                        foreach (var fileInPAC in pak.EnumerateFiles())
                        {
                            if (fileInPAC.EndsWith(inputFile.Name))
                            {
                                string normalizedFilePath = fileInPAC.Replace("../", ""); //Remove backwards relative path
                                string outputPath = Path.Combine(Path.GetDirectoryName(pacFilePath), inputFile.Name);

                                using (var stream = FileUtils.Create(outputPath))
                                using (var inputStream = pak.OpenFile(fileInPAC))
                                {
                                    inputStream.CopyTo(stream);
                                    Console.WriteLine($"Extracted {Path.GetFileName(normalizedFilePath)}");
                                }
                            }
                        }
                    }
                }
                else
                    Console.WriteLine($"Could not find input file: {pacFilePath}");
            }
        }

        private static void RoyalifyScripts()
        {
            // If game type is "Royal"...
            if (Program.SelectedGame.Type.Equals("Royal"))
            {
                // Replace vanilla-specific stuff with Royal stuff
                Console.WriteLine("Royal-ifying Mod Menu scripts...");

                // Get list of scripts to Royal-ify
                List<string> scripts = new List<string>();
                foreach (var script in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
                    scripts.Add($"Temp/Scripts/Hooks/{script.HookPath}/{script.Name}.flow");
                scripts.Add("Temp/Scripts/ModMenu.flow");

                foreach (var script in scripts)
                {
                    if (File.Exists(script))
                    {
                        var lines = File.ReadAllLines(script);
                        List<string> newLines = new List<string>();

                        for (int i = 0; i < lines.Length; i++)
                        {
                            var line = lines[i].Trim();
                            if (line.StartsWith("import(\"./Vanilla")) // Replace vanilla import script with Royal equivalent
                                newLines.Add(lines[i].Replace("import(\"./Vanilla", "import(\"./Royal"));
                            else if (line.StartsWith("BIT_OFF(") || line.StartsWith("BIT_ON("))
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
                                    Console.WriteLine($"Replaced Vanilla bitflag ({flag}) with Royal bitflag ({convertedFlag}).");
                                    newLines.Add(lines[i].Replace(flag, convertedFlag.ToString()));
                                }
                                else // Use original flag if flag could not be converted to Royal
                                    newLines.Add(lines[i]);
                            }
                            else // Add original line if no changes needed
                                newLines.Add(lines[i]);
                        }

                        File.WriteAllText(script, String.Join("\n", newLines));
                    }
                    else
                        Console.WriteLine($"Could not find script: {script}");
                }
            }
        }

        private static void RemoveMsgComments()
        {
            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Royal";
            if (Program.SelectedGame.Type.Equals("Royal"))
                removeType = "Vanilla";

            if (File.Exists("Temp/Scripts/ModMenu.msg"))
            {
                // Remove entire line if opposite type
                var lines = File.ReadAllLines("Temp/Scripts/ModMenu.msg");
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                    if (!lines[i].Contains($"// {removeType}") && !lines[i].Contains($"//{removeType}"))
                        newLines.Add(lines[i]);

                // Remove comments from line for matching type and overwrite file
                File.WriteAllText("Temp/Scripts/ModMenu.msg", String.Join("\n", newLines)
                    .Replace($"// {Program.SelectedGame.Type}", "").Replace($"//{Program.SelectedGame.Type}", ""));
            }
            else
                Console.WriteLine("Could not find script: Temp/Scripts/ModMenu.msg!");
        }

        private static void RemoveFlowComments()
        {
            // Remove lines with the opposite game type's comment from Mod Menu .flow
            string removeType = "Royal";
            if (Program.SelectedGame.Type.Equals("Royal"))
                removeType = "Vanilla";

            if (File.Exists("Temp/Scripts/ModMenu.flow"))
            {
                // Comment out blocks for opposing game type
                File.WriteAllText("Temp/Scripts/ModMenu.flow", File.ReadAllText("Temp/Scripts/ModMenu.flow")
                    .Replace($"/* {removeType} Start */", $"/* {removeType} Start ")
                    .Replace($"/* {removeType} End */", $" {removeType} End */"));
            }
            else
                Console.WriteLine("Could not find script: Temp/Scripts/ModMenu.flow!");
        }

        private static void UpdateImportPaths()
        {
            // Update .msg/.flow import paths for Royal
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
            {
                string flowPath = $"Temp/Scripts/Hooks/{inputFile.HookPath}/{inputFile.Name}.flow";

                if (Program.SelectedGame.Type.Equals("Royal"))
                {
                    if (File.Exists(flowPath))
                    {
                        Console.WriteLine($"Updated import paths in script: {flowPath}");
                        File.WriteAllText(flowPath, File.ReadAllText(flowPath).Replace("placeholder.msg", "placeholderRoyal.msg").Replace("/Vanilla/", "/Royal/"));
                    }
                    else
                        Console.WriteLine($"Failed to update import paths. Could not find script: {flowPath}");
                }
                else if (inputFile.Name.Equals("dungeon.bf"))
                {
                    if (File.Exists(flowPath))
                    {
                        Console.WriteLine($"Updated import paths in script: {flowPath}");
                        File.WriteAllText(flowPath, File.ReadAllText(flowPath).Replace("import(\"placeholderRoyal.msg\");", ""));
                    }
                    else
                        Console.WriteLine($"Failed to update import paths. Could not find script: {flowPath}");
                }
            }
        }

        public static void ReindexMsgs()
        {
            string path = "Temp/Scripts/ModMenu.msg";
            int startIndex = 90;
            if (Program.SelectedGame.Type.Equals("Royal"))
                startIndex = 181;

            // Update parameters of msg functions that displays description for menu selection
            Console.WriteLine($"Updating msg index parameters in {Path.GetFileName(path)} starting from {startIndex}");

            var msgLines = File.ReadAllLines(path);
            int msgCount = startIndex; // Keep track of total number of messages
            int refCount = 0; // Keep track of total number of references per selection block

            for (int i = 0; i < msgLines.Length; i++)
            {
                // Increase total number of messages so far
                if (msgLines[i].Contains("[dlg ") || msgLines[i].Contains("[sel "))
                    msgCount++;

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
                        string newString = $"[ref {refCount} {msgCount + refCount + 1}][e]";
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
                    msgLines[i] = $"[dlg GENERIC_HELP_{msgCount}]";
            }

            File.WriteAllText(path, string.Join("\n", msgLines));
        }

        private static void CompileScripts()
        {
            // Compile Mod Menu hook scripts and output to Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
            {
                string flowPath = $"./Temp/Scripts/Hooks/{inputFile.HookPath}/{inputFile.Name}.flow";
                if (File.Exists(flowPath))
                {
                    string[] args = new string[] {
                    $"\"{flowPath}\"", "-Compile",
                    "-OutFormat", "V3BE",
                    "-Encoding", Program.Options.Encoding,
                    "-Library", Program.SelectedGame.ShortName,
                    "-Out", $"\"Temp/Assets/{Program.SelectedGame.Type}/{inputFile.Path}/{inputFile.Name}.flow.bf\"",
                    "-Hook" };

                    Console.WriteLine($"Compiling with the arguments: {string.Join(" ", args)}");
                    Tools.RunCmd(Program.Options.Compiler, args);
                }
                else
                    Console.WriteLine($"Failed to compile {inputFile.Name}.flow.bf, could not find script: {flowPath}");

            }
        }

        private static void RepackPACs()
        {
            // Replace .bf files in each PAC with ones from Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf") && x.Archive.EndsWith(".pac")))
            {
                string pacPath = Path.Combine($".\\Temp\\Assets\\{Program.SelectedGame.Type}\\{inputFile.Path}", inputFile.Archive);
                string bfPath = Path.Combine($".\\Temp\\Assets\\{Program.SelectedGame.Type}\\{inputFile.Path}", inputFile.Name + ".flow.bf");

                if (File.Exists(pacPath))
                {
                    if (File.Exists(bfPath))
                    {
                        Console.WriteLine($"Attempting to replace {inputFile.Name} in {inputFile.Archive} with: {bfPath}");

                        PAKFileSystem pak = new PAKFileSystem();
                        if (PAKFileSystem.TryOpen(pacPath, out pak))
                        {
                            PAKFileSystem newPak = pak;

                            if (pak.EnumerateFiles().Any(x => x.EndsWith(inputFile.Name)))
                            {
                                string pakFilePath = pak.EnumerateFiles().First(x => x.EndsWith(inputFile.Name));
                                newPak.AddFile(pakFilePath, bfPath, ConflictPolicy.Replace);
                                Console.WriteLine($"  Replaced {inputFile.Name} in {inputFile.Archive}");

                                string outputPath = Path.Combine(Program.Options.Output, Path.Combine(inputFile.Path, inputFile.Archive));
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                                newPak.Save(outputPath);
                                Console.WriteLine($"  Saved repacked PAC to output folder: {outputPath}");
                            }
                            else
                                Console.WriteLine($"  Could not find any file ending with {inputFile.Name} in: {pacPath}");
                        }
                        else
                            Console.WriteLine($"Failed to open {pacPath} for repacking.");
                    }
                    else
                        Console.WriteLine($"Failed to replace {inputFile.Name} in {inputFile.Archive}, could not find compiled BF: {bfPath}");
                }
                else
                    Console.WriteLine($"Failed to repack PAC, could not find archive: {pacPath}");
            }
        }

        private static void CopyToOutput()
        {
            // Move non-PAC files for appropriate game version to output directory
            foreach (InputFile inputFile in Program.InputFiles.Where(x => !x.Archive.EndsWith(".pac")))
            {
                string inputPath = $"Temp/Assets/{Program.SelectedGame.Type}/{inputFile.Path}/{inputFile.Name}";
                if (inputFile.Path.Equals("script/field"))
                    inputPath += ".flow.bf";
                string outputPath = Path.Combine(Program.Options.Output, Path.Combine(inputFile.Path, inputFile.Name));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                Console.WriteLine($"Copying file from: {inputPath}\n  to: {outputPath}");
                File.Copy(inputPath, outputPath, true);
            }
        }
    }
}

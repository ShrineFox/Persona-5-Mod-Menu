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
            UnpackPACs(); // Get .bf files from .PAC files
            RoyalifyScripts(); // Enable Royal-only elements of Mod Menu .flow/.msg
            RemoveRoyalMsgComments(); // Removes lines with a "// Royal" comment from Mod Menu .msg
            UpdateImportPaths(); // Remove or update .flow/.msg import paths depending on if Royal or Vanilla
            ReindexMsgs(); // Update .msg indexes of files depending on if Royal or Vanilla
            CompileScripts(); // Create new .bf files from modified .flow
            RepackPACs(); // Pack changed .bf files back into .PAC
            CopyToOutput(); // Copy changed files to output folder

            Console.WriteLine("Done!");

            #if DEBUG
                Console.ReadKey(); // wait for input before closing if debug build
            #endif
        }

        private static void CopyToOutput()
        {
            // Move non-PAC files for appropriate game version to output directory
            foreach (InputFile inputFile in Program.InputFiles.Where(x => !x.Archive.EndsWith(".pac")))
            {
                string inputPath = $"Assets/{Program.SelectedGame.Type}/{inputFile.Path}/{inputFile.Name}";
                string outputPath = Path.Combine(Program.Options.Output, Path.Combine(inputFile.Path, inputFile.Name));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.Copy(inputPath, outputPath, true);
            }
        }

        private static void RepackPACs()
        {
            // Replace .bf files in each PAC with ones from Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf") && x.Archive.EndsWith(".pac")))
            {
                string pacPath = Path.Combine($".\\Assets\\{Program.SelectedGame.Type}\\{inputFile.Path}", inputFile.Archive);
                string bfPath = Path.Combine($".\\Assets\\{Program.SelectedGame.Type}\\{inputFile.Path}", inputFile.Name + ".flow.bf");

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
                                newPak.Save(outputPath);
                                Console.WriteLine($"Saved repacked PAC to output folder: {outputPath}");
                            }
                            else
                                Console.WriteLine($"Could not find any file ending with {inputFile.Name} in: {pacPath}");
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

        private static void CompileScripts()
        {
            // Compile Mod Menu hook scripts and output to Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
            {
                string flowPath = $"Scripts/Hooks/{inputFile.HookPath}/{inputFile.Name}.flow";
                if (File.Exists(flowPath))
                {
                    string[] args = new string[] { $"\"{flowPath}\"", "-Compile",
                    "-OutFormat", "V3BE",
                    "-Library", Program.SelectedGame.ShortName,
                    "-Out", $"\"Assets/{Program.SelectedGame.Type}/{inputFile.Path}/{inputFile.Name}.flow.bf\"",
                    "-Hook" };

                    AtlusScriptCompiler.Program.Main(args);
                }
                else
                    Console.WriteLine($"Failed to compile {inputFile.Name}.flow.bf, could not find script: {flowPath}");
                
            }
        }

        public static void ReindexMsgs()
        {
            string path = "Scripts/ModMenu.msg";
            int startIndex = 91;
            if (Program.SelectedGame.Type.Equals("Royal"))
                startIndex = 182;

            // Update parameters of msg functions that displays description for menu selection
            Console.WriteLine($"Updating msg index parameters in {Path.GetFileName(path)} starting from {startIndex}");

            List<string> msgLines = new List<string>();
            int msgCount = startIndex;

            foreach (string line in File.ReadAllLines(path))
            {
                string newLine = null;

                if (line.Contains("[dlg ") || line.Contains("[sel "))
                    msgCount = startIndex;

                if (line.Contains("[f 4 26 "))
                {
                    msgCount++;
                    int index = line.IndexOf("[f 4 26 ") + 8;
                    string substring = line.Substring(index);
                    string[] subParts = substring.Split(' ');
                    string newString = $"{msgCount}][e]";
                    newLine = line.Remove(index + subParts[0].Length);
                    newLine = newLine + " " + newString;
                }
                else if (line.Contains("[dlg GENERIC_HELP_"))
                {
                    int index = line.IndexOf("[dlg GENERIC_HELP_");
                    newLine = $"[dlg GENERIC_HELP_{msgCount}]";
                }

                if (newLine != null)
                    msgLines.Add(newLine);
                else
                    msgLines.Add(line);

                if (line.Contains("[dlg ") || line.Contains("[sel "))
                    msgCount++;
            }

            File.WriteAllText(path, string.Join("\n", msgLines));
        }

        private static void UpdateImportPaths()
        {
            // Update .msg/.flow import paths for Royal
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf")))
            {
                string flowPath = $"Scripts/Hooks/{inputFile.HookPath}/{inputFile.Name}.flow";

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
            }
        }

        private static void RemoveRoyalMsgComments()
        {
            // If game type is "Vanilla"...
            if (Program.SelectedGame.Type.Equals("Vanilla"))
            {
                // Remove "// Royal" lines from Mod Menu .msg
                if (File.Exists("Scripts/ModMenu.flow"))
                {
                    var lines = File.ReadAllLines("Scripts/ModMenu.msg");
                    List<string> newLines = new List<string>();
                    for (int i = 0; i < lines.Length; i++)
                        if (!lines[i].Contains("// Royal"))
                            newLines.Add(lines[i]);

                    File.WriteAllText("Scripts/ModMenu.msg", String.Join("\n", newLines));
                }
                else
                    Console.WriteLine("Could not find script: Scripts/ModMenu.msg!");
            }
        }

        private static void RoyalifyScripts()
        {
            // If game type is "Royal"...
            if (Program.SelectedGame.Type.Equals("Royal"))
            {
                // Replace vanilla-specific stuff with Royal stuff
                Console.WriteLine("Royal-ifying Mod Menu scripts...");

                if (File.Exists("Scripts/ModMenu.flow"))
                {
                    var lines = File.ReadAllLines("Scripts/ModMenu.flow");
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

                            if (convertedFlag != -1) // Replace line and notify user of this change
                            {
                                Console.WriteLine($"Replaced Vanilla bitflag ({flag}) with Royal bitflag ({convertedFlag}).");
                                newLines.Add(lines[i].Replace(flag, convertedFlag.ToString()));
                            }
                            else // Use original flag if flag could not be converted to Royal
                                newLines.Add(lines[i]);
                        }
                        else if (line.Contains("/* Royal")) // Remove opening comments from Royal-only code
                            newLines.Add(lines[i].Replace("/* Royal", ""));
                        else if (line.Contains("*/ Royal")) // Remove closing comments from Royal-only code
                            newLines.Add(lines[i].Replace("*/ Royal", ""));
                        else // Add original line if no changes needed
                            newLines.Add(lines[i]);
                    }

                    File.WriteAllText("Scripts/ModMenu.flow", String.Join("\n", newLines));
                }
                else
                    Console.WriteLine("Could not find script: Scripts/ModMenu.flow!");


                if (File.Exists("Scripts/ModMenu.flow")) // Remove comments from .msg
                    File.WriteAllText("Scripts/ModMenu.msg", File.ReadAllText("Scripts/ModMenu.msg").Replace("// Royal", ""));
                else
                    Console.WriteLine("Could not find script: Scripts/ModMenu.msg!");
            }
        }

        public static void UnpackPACs() 
        {
            // Extract .bf files from each PAC in Assets folder
            foreach (InputFile inputFile in Program.InputFiles.Where(x => x.Name.EndsWith(".bf") && x.Archive.EndsWith(".pac")))
            {
                string pacFilePath = Path.Combine($"Assets\\{Program.SelectedGame.Type}\\{inputFile.Path}", inputFile.Archive);
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
    }
}

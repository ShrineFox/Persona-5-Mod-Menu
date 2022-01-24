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
            if (Program.Options.Game.ToUpper().Equals("P5R"))
                RoyalifyScripts(); // Enable Royal-only elements of Mod Menu .flow/.msg
            else
                RemoveRoyalMsgComments(); // Removes lines with a "// Royal" comment from Mod Menu .msg
            MsgPlaceHolders(); // Remove or update .msg placeholder lines depending on if Royal or Vanilla
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
            string game = "Vanilla";
            if (Program.Options.Game.ToUpper().Equals("P5R"))
                game = "Royal";

            // Replace UI spritesheet file for appropriate game version
            string outputDir = Path.Combine(Program.Options.Output, "camp\\shared");
            Console.WriteLine($"Copying sharedUI.spd to {outputDir}");
            Directory.CreateDirectory(outputDir);
            File.Copy($"./Assets/{game}/camp/shared/sharedUI.spd", Path.Combine(outputDir, "sharedUI.spd"), true);

            // Replace intro fieldscript for appropriate game version
            outputDir = Path.Combine(Program.Options.Output, "script\\field");
            Console.WriteLine($"Copying fscr0150_002_100.bf to {outputDir}");
            Directory.CreateDirectory(outputDir);
            File.Copy($"./Assets/{game}/script/field/fscr0150_002_100.bf", Path.Combine(outputDir, "fscr0150_002_100.bf"), true);
        }

        private static void RepackPACs()
        {
            // Check that input path exists and has necessary files
            string game = "Vanilla";
            if (Program.Options.Game.ToUpper().Equals("P5R"))
                game = "Royal";

            // Extract .bf files from each PAC in Assets folder
            foreach (var file in InputFiles.PAC)
            {
                string pacFilePath = Path.Combine($".\\Assets\\{game}\\field", file);
                string bfFilePath = "";
                switch (file)
                {
                    case "atDngPack.pac":
                        bfFilePath = Path.Combine($".\\Assets\\{game}\\field", "at_dng.bf");
                        break;
                    case "dngPack.pac":
                        bfFilePath = Path.Combine($".\\Assets\\{game}\\field", "dungeon.bf");
                        break;
                    case "fldPack.pac":
                        bfFilePath = Path.Combine($".\\Assets\\{game}\\field", "field.bf");
                        break;
                }

                if (File.Exists(pacFilePath))
                {
                    Console.WriteLine($"Repacking {file}...");

                    if (File.Exists(bfFilePath))
                    {
                        Console.WriteLine($"Replacing {Path.GetFileName(bfFilePath)}...");
                        PAKFileSystem pak = new PAKFileSystem();
                        List<string> pakFiles = new List<string>();

                        if (PAKFileSystem.TryOpen(pacFilePath, out pak))
                        {
                            pakFiles = pak.EnumerateFiles().ToList();
                            PAKFileSystem newPak = pak;

                            foreach (var pakFile in pakFiles)
                            {
                                if (pakFile.EndsWith(file))
                                {
                                    string normalizedFilePath = pakFile.Replace("../", ""); //Remove backwards relative path

                                    Console.WriteLine($"Replacing {normalizedFilePath}");
                                    newPak.AddFile(normalizedFilePath.Replace("\\", "/"), bfFilePath, ConflictPolicy.Replace);
                                }
                            }
                            string outputPath = Path.Combine(Program.Options.Output, Path.Combine("field", Path.GetFileName(file)));
                            newPak.Save(outputPath);
                            Console.WriteLine($"Saving repacked PAC to output folder: {outputPath}");
                        }
                    }
                    else
                        Console.WriteLine($"Failed to open {Path.GetFileName(bfFilePath)}. Skipping...");
                }
                else
                    Console.WriteLine($"Failed to open {file}. Skipping...");
            }
        }

        private static void CompileScripts()
        {
            string assetDir = "Vanilla";
            if (Program.Options.Game.ToUpper().Equals("P5R"))
                assetDir = "Royal";

            // Compile ModMenu hook scripts and overwrite output in Assets folder
            foreach (var file in Directory.GetFiles("./Scripts/", "*.flow", SearchOption.AllDirectories))
            {
                if (InputFiles.BF.Any(x => file.Contains(x)))
                {
                    string[] args = new string[] { InputFiles.BF.First(x => file.Contains(x)), "-Compile", "-OutFormat", "V3BE", "-Library", 
                        Program.Options.Game, "-Out", 
                        Directory.GetFiles($"./Assets/{assetDir}", "*.bf", SearchOption.AllDirectories).First(x => x.Contains(Path.GetFileName(file.Replace(".flow","")))), 
                        "-Hook" };

                    AtlusScriptCompiler.Program.Main(args);
                }
            }
        }

        public static void ReindexMsgs()
        {
            string path = "./Scripts/ModMenu.flow";
            int startIndex = 91;
            if (Program.Options.Game.ToUpper().Equals("P5R"))
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

        private static void MsgPlaceHolders()
        {
            // Remove or update .msg placeholder lines depending on if Royal or Vanilla
            string game = "Vanilla";
            if (Program.Options.Game.ToUpper().Equals("P5R"))
                game = "Royal";

            string filePath = ".Scripts/Hooks/dungeon/dungeon.bf.flow";
            if (File.Exists(filePath) && game == "Vanilla")
                File.WriteAllText(filePath, File.ReadAllText(filePath).Replace("import(\"placeholderRoyal.msg\");", "// import( \"placeholderRoyal.msg\" );"));

            filePath = ".Scripts/Hooks/dungeon/field.bf.flow";
            if (File.Exists(filePath) && game == "Royal")
                File.WriteAllText(filePath, File.ReadAllText(filePath).Replace("placeholder.msg", "placeholderRoyal.msg"));
        }

        private static void RemoveRoyalMsgComments()
        {
            // Remove "// Royal" lines from Mod Menu .msg
            if (File.Exists("./Scripts/ModMenu.flow"))
            {
                var lines = File.ReadAllLines("./Scripts/ModMenu.msg");
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                    if (!lines[i].Contains("// Royal"))
                        newLines.Add(lines[i]);

                File.WriteAllText("./Scripts/ModMenu.msg", String.Join("\n", newLines));
            }
            else
                Console.WriteLine("Could not find script: ./Scripts/ModMenu.msg!");
        }

        private static void RoyalifyScripts()
        {
            // Replace vanilla-specific stuff with Royal stuff
            Console.WriteLine("Royal-ifying Mod Menu scripts...");
            
            if (File.Exists("./Scripts/ModMenu.flow"))
            {
                var lines = File.ReadAllLines("./Scripts/ModMenu.flow");
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

                File.WriteAllText("./Scripts/ModMenu.flow", String.Join("\n", newLines));
            }
            else
                Console.WriteLine("Could not find script: ./Scripts/ModMenu.flow!");


            if (File.Exists("./Scripts/ModMenu.flow")) // Remove comments from .msg
                File.WriteAllText("./Scripts/ModMenu.msg", File.ReadAllText("./Scripts/ModMenu.msg").Replace("// Royal",""));
            else
                Console.WriteLine("Could not find script: ./Scripts/ModMenu.msg!");
        }

        public static void UnpackPACs() 
        {
            // Check that input path exists and has necessary files
            string game = "Vanilla";
            if (Program.Options.Game.ToUpper().Equals("P5R"))
                game = "Royal";

            // Extract .bf files from each PAC in Assets folder
            foreach (var file in InputFiles.PAC)
            {
                string pacFilePath = Path.Combine($".\\Assets\\{game}\\field", file);
                if (File.Exists(pacFilePath))
                {
                    Console.WriteLine($"Unpacking {file}...");

                    PAKFileSystem pak = new PAKFileSystem();
                    if (PAKFileSystem.TryOpen(pacFilePath, out pak))
                    {
                        foreach (var fileInPAC in pak.EnumerateFiles())
                        {
                            if (fileInPAC.EndsWith(".bf"))
                            {
                                string normalizedFilePath = fileInPAC.Replace("../", ""); //Remove backwards relative path
                                string outputPath = Path.Combine(Path.GetDirectoryName(pacFilePath), Path.GetFileName(normalizedFilePath));

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

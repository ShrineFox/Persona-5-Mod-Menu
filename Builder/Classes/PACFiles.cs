using AtlusFileSystemLibrary;
using AtlusFileSystemLibrary.Common.IO;
using AtlusFileSystemLibrary.FileSystems.PAK;
using System;
using System.IO;
using System.Linq;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public partial class MenuBuilder
    {
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
                    Output.Log($"Unpacked .PAC: {pac}", ConsoleColor.Green);
                }
            }
        }

        private static void RepackPAC(string script)
        {
            if (Program.SelectedGame.Platform == PlatformType.Old)
            {
                // Get .PAC Name
                string pakName = "";
                string scriptName = Path.GetFileName(script).Split('.')[0];
                string outputScript = Path.Combine(outputDir, Path.Combine(Path.GetDirectoryName(script), Path.GetFileNameWithoutExtension(script) + ".bf").Replace(Exe.Directory() + "\\Temp\\Hook\\", ""));

                switch (scriptName)
                {
                    case "at_dng":
                        pakName = "atDngPack";
                        break;
                    case "field":
                        pakName = "fldPack";
                        break;
                    case "dungeon":
                        pakName = "dngPack";
                        break;
                    default:
                        return;
                }

                string pakPath = Path.Combine(Path.Combine(Path.Combine(assetsDir,
                    Program.SelectedGame.Type.ToString()), "field"), pakName + ".pac");

                if (Program.Options.Pack)
                {
                    PAKFileSystem pak = new PAKFileSystem();
                    // Open matching .PAC from Assets folder
                    if (PAKFileSystem.TryOpen(pakPath, out pak))
                    {
                        PAKFileSystem newPak = pak;
                        foreach (var fileInPAC in pak.EnumerateFiles().ToList())
                        {
                            // Replace file in .PAC with name matching script
                            if (fileInPAC.Contains(scriptName))
                            {
                                string normalizedFilePath = fileInPAC.Replace("../", "").Replace("\\", "/"); //Remove backwards relative path
                                using (FileSys.WaitForFile(outputScript)) { };
                                newPak.AddFile(normalizedFilePath, outputScript, ConflictPolicy.Replace);
                                Output.Log($"Replaced file {fileInPAC} in {Path.GetFileName(pakPath)}");
                            }
                        }
                        // Save .PAC to output folder
                        string outputPAC = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(outputScript)), pakName + ".pac");
                        if (File.Exists(outputPAC))
                            File.Delete(outputPAC);
                        string newDir = Path.GetDirectoryName(outputPAC);
                        Directory.CreateDirectory(newDir);
                        while (!Directory.Exists(newDir)) { }
                        newPak.Save(outputPAC);
                        using (FileSys.WaitForFile(outputPAC)) { };
                        Output.Log($"Saved repacked .PAC to: {outputPAC}", ConsoleColor.Green);
                    }
                    else
                        Output.Log($"Could not open .PAC: {pakPath}", ConsoleColor.Red);
                }
                else
                {
                    // Move script into folder named after .PAC for Aemulus
                    string newOutputPath = Path.Combine(Path.Combine(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(outputScript)), pakName), "etc"), Path.GetFileName(outputScript));
                    Directory.CreateDirectory(Path.GetDirectoryName(newOutputPath));
                    if (File.Exists(newOutputPath))
                        File.Delete(newOutputPath);
                    File.Move(outputScript, newOutputPath);
                    Output.Log($"Moved unpacked output script for Aemulus to: {newOutputPath}", ConsoleColor.Green);
                }
            }
        }

    }
}

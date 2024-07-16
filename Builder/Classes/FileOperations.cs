using ShrineFox.IO;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace ModMenuBuilder
{
    public partial class MenuBuilder
    {
        private static void CreateTempFolder()
        {
            Output.Log($"Copying Scripts to Temp folder...", ConsoleColor.White);
            FileSys.CopyDir(scriptsDir, tempDir);
            Output.Log($"Created Temp folder.", ConsoleColor.Green);
        }

        private static void DeleteTempFolder()
        {
            if (Directory.Exists(tempDir))
            {
                foreach (var file in Directory.GetFiles(tempDir, "*", SearchOption.AllDirectories))
                {
                    using (FileSys.WaitForFile(file)) { };
                }
                Thread.Sleep(500);
                Output.Log($"Deleting Temp folder...", ConsoleColor.White);
                Directory.Delete(tempDir, true);
                Output.Log($"Deleted Temp folder.", ConsoleColor.Green);
                Thread.Sleep(500);
            }
        }

        private static void DeleteDecompiledOutput(string outDir)
        {
            foreach (var file in Directory.GetFiles(outDir, "*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".flow") || file.EndsWith(".msg") || file.EndsWith(".h"))
                {
                    File.Delete(file);
                }
            }
        }

        private static void UpperCaseOutput()
        {
            foreach (var directory in Directory.GetDirectories(outputDir, "*", SearchOption.AllDirectories).Reverse())
            {
                string newDir = Path.Combine(outputDir, directory.Substring(outputDir.Length).TrimStart(Path.DirectorySeparatorChar).ToUpper());
                if (newDir != directory)
                {
                    Directory.Move(directory, newDir + "_");
                    Directory.Move(newDir + "_", newDir);
                }
            }
            Thread.Sleep(500);
            foreach (var file in Directory.GetFiles(outputDir, "*", SearchOption.AllDirectories))
            {
                string newFile = Path.Combine(outputDir, file.Substring(outputDir.Length).TrimStart(Path.DirectorySeparatorChar).ToUpper());
                if (newFile != file)
                {
                    File.Move(file, newFile + "_");
                    File.Move(newFile + "_", newFile);
                }
            }
            Output.Log($"Done uppercasing output files/directories.", ConsoleColor.Green);
        }

        private static void MoveToPCOutput(string script)
        {
            string outDir = Program.Options.Output + "\\FEmulator\\BF";
            string outputFile = outDir + "\\" + script.Replace(Exe.Directory(), "").Replace("\\Temp\\","\\");
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            File.Copy(script, outputFile, true);
            Output.Log($"Moved script: {outputFile}");
        }

        private static void CreateDummyBFFiles()
        {
            string scriptDir = outputDir + "\\FEmulator\\BF";
            string dummyDir = outputDir + "\\P5REssentials\\CPK\\DUMMYFILES.CPK";

            if (Directory.Exists(dummyDir))
                Directory.Delete(dummyDir, true);

            foreach (var file in Directory.GetFiles(scriptDir, "*", SearchOption.AllDirectories)
                .Where(x => !x.Contains("_CustomScripts") && !x.Contains(".CPK") &&
                    (x.ToLower().EndsWith(".msg") || x.ToLower().EndsWith(".flow"))))
            {
                string relativePath = file.Remove(0, scriptDir.Length);
                string dummyPath = dummyDir + "\\" + relativePath.Replace(".flow", ".BF").Replace(".msg", ".BF");

                if (!Directory.Exists(Path.GetDirectoryName(dummyPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(dummyPath));

                if (!File.Exists(dummyPath))
                {
                    File.CreateText(dummyPath).Close();
                    Output.VerboseLog($"Created dummy file: {dummyPath}");
                    if (dummyPath.Contains("\\SCRIPT\\FIELD\\"))
                    {
                        // CreateFallbackBF(dummyPath, file);
                    }
                }
            }
            Output.Log($"Finished creating dummy .BF files.");
        }
    }
}

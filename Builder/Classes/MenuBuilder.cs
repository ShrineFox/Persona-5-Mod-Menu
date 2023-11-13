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
using System.Media;
using System.Threading;
using AtlusScriptCompiler;
using AtlusScriptLibrary.Common.Logging;
using AtlusScriptLibrary.MessageScriptLanguage;
using AtlusScriptLibrary.Common.Text.Encodings;
using AtlusScriptLibrary.FlowScriptLanguage;

namespace ModMenuBuilder
{
    public class MenuBuilder
    {
        public static string assetsDir;
        public static string scriptsDir;
        public static string tempDir;
        public static string outputDir;
        
        public static void Build()
        {
            // Set build paths
            assetsDir = Path.Combine(Program.exeDir, "Assets");
            scriptsDir = Path.Combine(Program.exeDir, "Scripts");
            tempDir = Path.Combine(Program.exeDir, "Temp");

            // Set output path if specified by user
            if (Program.Options.Output != "")
            {
                Directory.CreateDirectory(Program.Options.Output);
                outputDir = Program.Options.Output;
            }

            UnpackPACs(); // Get .bf files from .PAC files
            ProcessScripts(); // Enable/disable game-specific elements of Mod Menu .flow/.msg and reindex .msg files
            CopyDDS(); // Move .dds files to destination
            if (Program.SelectedGame.ConsoleName == "Switch")
                UpperCaseOutput(); // Make all files/folders in output path uppercase

            Output.Log("\nDone!", ConsoleColor.Green);
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

        private static void CopyDDS()
        {
            FileSys.CopyDir(Path.Combine(assetsDir, "test"), Path.Combine(outputDir, "test"));
            Output.Log($"Done copying .dds files.", ConsoleColor.Green);
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
                    Output.Log($"Unpacked .PAC: {pac}", ConsoleColor.Green);
                }
            }
        }

        private static void ProcessScripts()
        {
            DeleteTempFolder();
            CreateTempFolder();

            // Removes lines with i.e. "/* Royal */" or "/* Vanilla */" comment from .flow depending on version
            foreach (var script in Directory.GetFiles(tempDir,
                "*.flow", SearchOption.AllDirectories))
            {
                using (FileSys.WaitForFile(script)) { }
                RemoveFlowComments(script); 
            }
            Output.Log($"Done removing version-specific codeblocks from .flow files.", ConsoleColor.Green);

            // Removes lines with a "// Royal" or "// Vanilla" comment from .msg depending on version
            foreach (var script in Directory.GetFiles(tempDir,
                "*", SearchOption.AllDirectories))
            {
                using (FileSys.WaitForFile(script)) { }
                RemoveMsgComments(script); 
            }
            Output.Log($"Done removing version-specific lines in all scripts.", ConsoleColor.Green);

            // Reindex and compile each Hook script
            foreach (var script in Directory.GetFiles(Path.Combine(tempDir, "Hook"),
            "*.flow", SearchOption.AllDirectories))
            {
                CompileHookScript(script);
            }

            // Replace file in .PAC and save new .PAC to output dir
            foreach (var script in Directory.GetFiles(Path.Combine(tempDir, "Hook"),
            "*.flow", SearchOption.AllDirectories))
            {
                RepackPAC(script);
            }

            DeleteTempFolder();
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
                    File.Move(outputScript, newOutputPath);
                    Output.Log($"Moved unpacked output script for Aemulus to: {newOutputPath}", ConsoleColor.Green);
                }
            }
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

        private static void CreateTempFolder()
        {
            Output.Log($"Copying Scripts to Temp folder...", ConsoleColor.White);
            FileSys.CopyDir(scriptsDir, tempDir);
            Output.Log($"Created Temp folder.", ConsoleColor.Green);
        }

        private static void CompileHookScript(string script)
        {
            string outputScript = "";
            if (Program.Options.Reindex)
            {
                ReindexMsgs(script);
            }

            // Create new .bf in output folder (again)
            outputScript = Compile(script);

            // Decompile newly generated script for debugging
            if (Program.Options.Decompile)
                Decompile(outputScript);
            else
                DeleteDecompiledOutput(Path.GetDirectoryName(outputScript));
            
        }

        private static void ReindexMsgs(string script)
        {
            // Get list of .msg files imported in scripts
            var msgs = RecursivelyGetImports(script).Where(x => x.EndsWith(".msg")).ToList();
            // Create new .bf in output folder
            string outputScript = Compile(script);
            
            // Re-order msgs based on output .h file
            Decompile(outputScript);
            using (FileSys.WaitForFile(outputScript + ".msg.h")) { }
            if (File.Exists(outputScript + ".msg.h"))
            {
                List<Tuple<int, string>> msgList = ReorderMsgsByH(msgs, outputScript + ".msg.h");
                // Re-number HELP message names in referenced .msg files
                foreach (var msg in msgList)
                    ReindexMsg(msg);
                Output.Log($"Reindexed .msg files referenced in scripts!", ConsoleColor.Cyan);
            }
            else
                Output.Log($"Could not access file for reindexing: {script + ".msg.h"}", ConsoleColor.Red);
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

        private static List<Tuple<int,string>> ReorderMsgsByH(List<string> msgs, string msgHeader)
        {
            // Create list of .msgs and indexes
            List<Tuple<int, string>> msgList = new List<Tuple<int, string>>();
            foreach (var line in File.ReadAllLines(msgHeader))
            {
                if (msgs.Any(x => Path.GetFileNameWithoutExtension(x).Equals(line.Split(' ')[2]))) 
                {
                    string path = msgs.Single(x => Path.GetFileNameWithoutExtension(x).Equals(line.Split(' ')[2]));
                    int index = Convert.ToInt32(line.Split('=')[1].TrimEnd(';').Trim());
                    msgList.Add(new Tuple<int, string>(index, path));
                }
            }
            // Reorder .msgs by index
            var list = msgList.OrderBy(x => x.Item1).ToList();
            // Move hooked .bf's .msg to top if it exists
            if (msgList.Any(x => x.Item2.EndsWith(".bf.msg")))
            {
                var hookMsg = msgList.First(x => x.Item2.EndsWith(".bf.msg"));
                var hookMsgIndex = msgList.IndexOf(hookMsg); 
                var item = list[hookMsgIndex];
                list.RemoveAt(hookMsgIndex);
                list.Insert(0, item);
            }
            
            return list;
        }

        private static List<string> RecursivelyGetImports(string script)
        {
            List<string> paths = GetImportPaths(script);
            List<string> newPaths = new List<string>();
            for (int i = 0; i < paths.Count; i++)
            {
                if (paths[i].EndsWith(".bf"))
                {
                    Decompile(paths[i]);
                    using (FileSys.WaitForFile(paths[i] + ".msg")) { }
                    if (File.Exists(paths[i] + ".msg"))
                        paths[i] = paths[i] + ".msg";
                }
                if (paths[i].EndsWith(".flow"))
                {
                    foreach (var path in RecursivelyGetImports(paths[i]))
                        newPaths.Add(path);
                }
            }
            return paths.Concat(newPaths).ToList();
        }
        private static List<string> GetImportPaths(string script)
        {
            List<string> importPaths = new List<string>();

            foreach (var line in File.ReadAllLines(script))
            {
                if (line.StartsWith("import("))
                {
                    string relativePath = line.Replace("import(\"", "").Replace("import( \"", "").Replace("\");", "").Replace("\" );", "").Replace('/', '\\');
                    string path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(script), relativePath));
                    importPaths.Add(path);
                }
            }

            return importPaths;
        }

        private static void RemoveMsgComments(string script)
        {
            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            string selectedType = "Royal";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
            {
                removeType = "Royal";
                selectedType = "Vanilla";
            }

            if (File.Exists(script))
            {
                var lines = File.ReadAllLines(script);
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    // Remove entire line if opposite type
                    if (line.Contains($"// {removeType}") || line.Contains($"//{removeType}"))
                        line = "";
                    else
                        line = line.Replace($"// {selectedType}","").Replace($"//{selectedType}","");
                    
                    if (line.Contains("// Version") || line.Contains("//Version"))
                    {
                        line = line.Replace("// Version", $"[n]{Program.Options.Version}").Replace("//Version",$"[n]{Program.Options.Version}");
                    }
                    if (!string.IsNullOrEmpty(line))
                        newLines.Add(line);
                }
                
                File.WriteAllText(script, String.Join("\n", newLines), Encoding.Unicode);
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
                // Comment out blocks for opposing game type
                string text = File.ReadAllText(script);
                text = text.Replace($"/* {removeType} Start */", $"/* {removeType} Start ")
                    .Replace($"/* {removeType} End */", $" {removeType} End */");

                // Remove lines with the wrong console name's comment from Mod Menu .msg
                foreach (var console in new List<string>() { "PS3", "PS4", "Switch", "PC" }.Where(x => !x.Equals(Program.SelectedGame.ConsoleName)))
                {
                    text = text.Replace($"/* {console} Start */", $"/* {console} Start ")
                    .Replace($"/* {console} End */", $" {console} End */");
                }

                text = RemoveBetween(text, "/*", "*/");
                File.WriteAllText(script, text, Encoding.Unicode);
            }
            else
                Output.Log($"\tCould not find script to remove .flow comments from:\n  {script}", ConsoleColor.Red);
        }

        public static string RemoveBetween(string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.Singleline);
            return regex.Replace(sourceString, startTag + endTag);
        }

        public static void ReindexMsg(Tuple<int,string> script)
        {
            int index = script.Item1;
            string msgFile = script.Item2;
            // Update parameters of msg functions that displays description for menu selection
            if (File.Exists(msgFile))
            {
                var msgLines = File.ReadAllLines(msgFile);

                for (int i = 0; i < msgLines.Length; i++)
                {
                    // Increase total number of messages so far
                    if (msgLines[i].Contains("[msg ") || msgLines[i].Contains("[dlg ") || msgLines[i].Contains("[sel "))
                    {
                        index++;
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
                            string newString = $"[ref {refCount} {index + refCount}][e]";
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
                        msgLines[i] = $"[dlg GENERIC_HELP_{index}]";
                }

                File.WriteAllText(msgFile, string.Join("\n", msgLines), Encoding.Unicode);
                using (FileSys.WaitForFile(msgFile)) { }
            }
            else
                Output.Log($"\tFailed to reindex .msg, file not found: {msgFile}", ConsoleColor.Red);
        }

        private static void InitializeScriptCompiler(string inputPath, string outputPath)
        {
            AtlusScriptCompiler.Program.IsActionAssigned = false;
            AtlusScriptCompiler.Program.InputFilePath = inputPath;
            AtlusScriptCompiler.Program.OutputFilePath = outputPath;
            //AtlusScriptCompiler.Program.MessageScriptEncoding = AtlusEncoding.GetEncoding(Program.Options.Encoding);
            AtlusScriptCompiler.Program.MessageScriptTextEncodingName = Program.Options.Encoding;
            switch (Path.GetExtension(inputPath).ToLower())
            {
                case ".bmd":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.MessageScriptBinary;
                    break;
                case ".bf":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.FlowScriptBinary;
                    break;
                case ".msg":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.MessageScriptTextSource;
                    break;
                case ".flow":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.FlowScriptTextSource;
                    break;
            }
            switch (Path.GetExtension(outputPath).ToLower())
            {
                case ".bmd":
                    AtlusScriptCompiler.Program.OutputFileFormat = OutputFileFormat.V1BE;
                    break;
                case ".bf":
                    AtlusScriptCompiler.Program.OutputFileFormat = OutputFileFormat.V3BE;
                    break;
                case ".msg":
                    AtlusScriptCompiler.Program.OutputFileFormat = OutputFileFormat.None;
                    break;
                case ".flow":
                    AtlusScriptCompiler.Program.OutputFileFormat = OutputFileFormat.None;
                    break;
            }
            AtlusScriptCompiler.Program.Logger = new Logger($"{nameof(AtlusScriptCompiler)}_{Path.GetFileNameWithoutExtension(outputPath)}");
            AtlusScriptCompiler.Program.Listener = new FileAndConsoleLogListener(true, LogLevel.Info | LogLevel.Warning | LogLevel.Error | LogLevel.Fatal);
        }

        private static string Compile(string script)
        {
            string outDir = Program.Options.Output;
            string outputFile = Path.Combine(outDir, Path.Combine(Path.GetDirectoryName(script), Path.GetFileNameWithoutExtension(script) + ".bf").Replace(Exe.Directory() + "\\Temp\\Hook\\", ""));
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            InitializeScriptCompiler(script, outputFile);

            string[] args = new string[] {
                $"\"{script}\"", "-Compile",
                "-OutFormat", "V3BE",
                "-Encoding", Program.Options.Encoding,
                "-Library", Program.SelectedGame.ShortName,
                "-Out", $"\"{outputFile}\"",
                "-Hook" };

            Output.Log($"Compiling script: {script}", ConsoleColor.Yellow);
            Output.VerboseLog($"\targs: {string.Join(" ", args)}");
            try
            {
                AtlusScriptCompiler.Program.Main(args);
            }
            catch (Exception e)
            {
                Output.Log(e.Message.ToString(), ConsoleColor.Red);
            }

            using (FileSys.WaitForFile(outputFile)) { }
            if (File.Exists(outputFile))
                Output.Log($"Compiled script successfully: {outputFile}", ConsoleColor.Green);
            else
                Output.Log($"Failed to compile script: {outputFile}", ConsoleColor.Red);

            return outputFile;
        }

        private static void Decompile(string bf)
        {
            string[] args = new string[] {
                $"\"{bf}\"", "-Decompile",
                "-Encoding", Program.Options.Encoding,
                "-Library", Program.SelectedGame.ShortName
            };

            InitializeScriptCompiler(bf, bf + ".flow");

            Output.Log($"Decompiling script: {bf}");
            Output.VerboseLog($"\targs: {string.Join(" ", args)}");
            try
            {
                AtlusScriptCompiler.Program.Main(args);
            }
            catch (Exception e)
            {
                Output.Log(e.Message.ToString(), ConsoleColor.Red);
            }

            using (FileSys.WaitForFile(bf + ".flow")) { }
            if (File.Exists(bf + ".flow"))
                Output.Log($"Decompiled script successfully: {bf + ".flow"}", ConsoleColor.Green);
            else
                Output.Log($"Failed to decompile script: {bf + ".flow"}", ConsoleColor.Red);
        }
    }
}

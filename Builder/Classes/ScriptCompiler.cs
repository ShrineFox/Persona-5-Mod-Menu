using Antlr4.Runtime.Tree.Xpath;
using AtlusScriptCompiler;
using AtlusScriptLibrary.Common.Logging;
using AtlusScriptLibrary.FlowScriptLanguage;
using AtlusScriptLibrary.FlowScriptLanguage.BinaryModel;
using AtlusScriptLibrary.MessageScriptLanguage;
using ShrineFox.IO;
using System;
using System.IO;

namespace ModMenuBuilder
{
    public partial class MenuBuilder
    {
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
                    AtlusScriptCompiler.Program.DoCompile = false;
                    AtlusScriptCompiler.Program.DoDecompile = true;
                    break;
                case ".bf":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.FlowScriptBinary;
                    AtlusScriptCompiler.Program.DoCompile = false;
                    AtlusScriptCompiler.Program.DoDecompile = true;
                    break;
                case ".msg":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.MessageScriptTextSource;
                    AtlusScriptCompiler.Program.DoCompile = true;
                    AtlusScriptCompiler.Program.DoDecompile = false;
                    break;
                case ".flow":
                    AtlusScriptCompiler.Program.InputFileFormat = InputFileFormat.FlowScriptTextSource;
                    AtlusScriptCompiler.Program.DoCompile = true;
                    AtlusScriptCompiler.Program.DoDecompile = false;
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

        private static string Compile(string script, string outFile = "")
        {
            string outDir = Program.Options.Output;
            if (string.IsNullOrEmpty(outFile))
            {
                outFile = Path.Combine(outDir, Path.Combine(Path.GetDirectoryName(script), 
                    Path.GetFileNameWithoutExtension(script) + ".bf").Replace(Exe.Directory() 
                    + "\\Temp\\Hook\\", ""));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(outFile));

            InitializeScriptCompiler(script, outFile);

            string[] args = new string[] {
                $"\"{script}\"", "-Compile",
                "-OutFormat", "V3BE",
                "-Encoding", Program.Options.Encoding,
                "-Library", Program.SelectedGame.ShortName,
                "-Out", outFile,
                "-Hook" };

            Output.Log($"Compiling script: {script}", ConsoleColor.Yellow);
            Output.VerboseLog($"\targs: {string.Join(" ", args)}\n");

            AtlusScriptCompiler.Program.Main(args);

            using (FileSys.WaitForFile(outFile)) { }
            if (!File.Exists(outFile))
                Output.Log($"Failed to compile script: {outFile}", ConsoleColor.Red);

            return outFile;
        }

        private static void Decompile(string bf)
        {
            string outFlow = bf + ".flow";
            string[] args = new string[] {
                $"\"{bf}\"", "-Decompile",
                "-Encoding", Program.Options.Encoding,
                "-Library", Program.SelectedGame.ShortName,
                $"-Out \"{outFlow}\""
            };

            InitializeScriptCompiler(bf, outFlow);

            Output.Log($"Decompiling script: {bf}");
            Output.VerboseLog($"\targs: {string.Join(" ", args)}\n");

            AtlusScriptCompiler.Program.Main(args);

            using (FileSys.WaitForFile(outFlow)) { }
            if (File.Exists(outFlow))
                Output.Log($"Decompiled script successfully: {outFlow}", ConsoleColor.Green);
            else
                Output.Log($"Failed to decompile script: {outFlow}", ConsoleColor.Red);
        }

        private static void CreateFallbackBF(string dummyBfPath, string flowPath)
        {
            string scriptImport = File.ReadAllLines(flowPath)[0];
            string scriptProcedure = File.ReadAllLines(flowPath)[4];

            string dummyFlowPath = Path.Combine(tempDir, "dummy.flow");
            File.Copy(Path.Combine(assetsDir, "dummy.flow"), dummyFlowPath, true);

            File.WriteAllText(Path.Combine(tempDir, "dummy.msg"), 
                $"[msg Msg_Dummy]\r\n[clr 1]Failed to Compile Script: {Path.GetFileName(dummyBfPath)}![clr 0][n]\n" +
                $"{scriptImport}[n]{scriptProcedure}[w][e]");

            using (FileSys.WaitForFile(dummyBfPath)) { }
            Compile(dummyFlowPath, dummyBfPath);
        }
    }
}

using AtlusScriptCompiler;
using AtlusScriptLibrary.Common.Logging;
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
                "-Out", outputFile,
                "-Hook" };

            Output.Log($"Compiling script: {script}", ConsoleColor.Yellow);
            Output.VerboseLog($"\targs: {string.Join(" ", args)}\n");

            AtlusScriptCompiler.Program.Main(args);

            using (FileSys.WaitForFile(outputFile)) { }
            if (!File.Exists(outputFile))
                Output.Log($"Failed to compile script: {outputFile}", ConsoleColor.Red);

            return outputFile;
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
    }
}

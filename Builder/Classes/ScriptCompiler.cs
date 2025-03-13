using AtlusScriptLibrary.Common.Logging;
using ShrineFox.IO;
using System;
using System.IO;

namespace ModMenuBuilder
{
    public partial class MenuBuilder
    {
        private static string Compile(string script, string outFile = "")
        {
            string outDir = Program.settings.Output;
            if (string.IsNullOrEmpty(outFile))
            {
                outFile = Path.Combine(outDir, Path.Combine(Path.GetDirectoryName(script), 
                    Path.GetFileNameWithoutExtension(script) + ".bf").Replace(Exe.Directory() 
                    + "\\Temp\\Hook\\", ""));
            }
            Directory.CreateDirectory(Path.GetDirectoryName(outFile));

            string args = $"\"{script}\" -Compile -OutFormat V3BE -Encoding " +
                $"{Program.settings.Encoding} -Library {Program.SelectedGameShortName} " +
                $"-Out {outFile} -Hook";

            Output.Log($"Compiling script: {script}", ConsoleColor.Yellow);
            Output.VerboseLog($"\targs: {args}\n");

            Exe.Run(Program.settings.CompilerPath, args);

            using (FileSys.WaitForFile(outFile)) { }
            if (!File.Exists(outFile))
                Output.Log($"Failed to compile script: {outFile}", ConsoleColor.Red);

            return outFile;
        }

        private static void Decompile(string bf)
        {
            string outFlow = bf + ".flow";
            string args = $"\"{bf}\" -Decompile -Encoding {Program.settings.Encoding} " +
                $"-Library {Program.SelectedGameShortName} -Out \"{outFlow}\"";

            Output.Log($"Decompiling script: {bf}");
            Output.VerboseLog($"\targs: {args}\n");

            Exe.Run(Program.settings.CompilerPath, args);

            using (FileSys.WaitForFile(outFlow)) { }
            if (File.Exists(outFlow))
                Output.Log($"Decompiled script successfully: {outFlow}", ConsoleColor.Green);
            else
                Output.Log($"Failed to decompile script: {outFlow}", ConsoleColor.Red);
        }
    }
}

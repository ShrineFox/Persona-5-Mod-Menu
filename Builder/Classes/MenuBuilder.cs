using System;
using System.IO;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public partial class MenuBuilder
    {
        // Directory to get vanilla game files from
        public static string assetsDir;
        // Directory to get mod menu scripts from
        public static string scriptsDir;
        // Directory to copy files to for programmatic editing
        public static string tempDir;
        // Directory to move mod-ready files to
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

            // Get .bf files from .PAC files
            UnpackPACs(); 

            // Enable/disable game-specific elements of Mod Menu .flow/.msg
            // and reindex .msg files
            ProcessScripts(); 

            if (Program.SelectedGame.ConsoleName == "Switch")
                UpperCaseOutput(); // Make all files/folders in output path uppercase

            Output.Log("\nDone!", ConsoleColor.Green);
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

            // Reindex and compile each script in Scripts/FIELD and Scripts/SCRIPT subfolders
            foreach (var script in Directory.GetFiles(Path.Combine(tempDir, "FIELD"),
                "*.*", SearchOption.AllDirectories))
            {
                CompileScript(script);
            }
            foreach (var script in Directory.GetFiles(Path.Combine(tempDir, "SCRIPT"),
                "*.*", SearchOption.AllDirectories))
            {
                CompileScript(script);
            }
            // Copy _CustomScripts directory to output for P5RPC
            if (Program.Options.Game == "P5R_PC")
            {
                foreach (var script in Directory.GetFiles(Path.Combine(tempDir, "_CustomScripts"),
                    "**", SearchOption.AllDirectories))
                {
                    CompileScript(script);
                }

                CreateDummyBFFiles();
            }

            // Replace file in .PAC and save new .PAC to output dir
            if (Program.Options.Game != "P5R_PC" || Program.Options.Game != "P5R_Switch")
            {
                foreach (var script in Directory.GetFiles(tempDir,
                    "*.flow", SearchOption.AllDirectories))
                {
                    RepackPAC(script);
                }
            }

#if !DEBUG
            DeleteTempFolder();
#endif
        }

        private static void CompileScript(string script)
        {
            if (Program.Options.Game != "P5R_PC")
            {
                if (Path.GetExtension(script).ToLower().EndsWith(".flow"))
                {
                    // Create new .bf in output folder (again)
                    string outputScript = Compile(script);

                    // Decompile newly generated script for debugging
                    if (Program.Options.Decompile)
                        Decompile(outputScript);
                    else
                        DeleteDecompiledOutput(Path.GetDirectoryName(outputScript));
                }
            }
            else
            {
                MoveToPCOutput(script);
            }
        }
    }
}

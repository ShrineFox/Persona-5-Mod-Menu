using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGE.SimpleCommandLine;

namespace ModMenuBuilder
{
    public class Program
    {
        public static ProgramOptions Options { get; private set; }
        public static Game SelectedGame { get; private set; } = new Game();

        public static List<InputFile> InputFiles = new List<InputFile>()
        {
            new InputFile() { Name = "at_dng.bf", Path = "field", Archive = "atDngPack.pac", HookPath = "mementos" },
            new InputFile() { Name = "dungeon.bf", Path = "field", Archive = "dngPack.pac", HookPath = "palace" },
            new InputFile() { Name = "field.bf", Path = "field", Archive = "fldPack.pac", HookPath = "overworld" },
            new InputFile() { Name = "fscr0150_002_100.bf", Path = "script/field", Archive = "", HookPath = "introduction" },
            new InputFile() { Name = "sharedUI.spd", Path = "camp/shared", Archive = "", HookPath = "" }
        };

        static void Main(string[] args)
        {
            // Show about message
            SimpleCommandLineFormatter.Default.FormatAbout<ProgramOptions>("ShrineFox", 
                "Generates Mod Menu output for P5/P5R." +
                "\nUsing TGE's AtlusScriptCompiler and AtlusFileSystemLibrary." +
                "\ngithub.com/ShrineFox/Persona-5-Mod-Menu" +
                "\n");

            try
            {
                // Validate input arguments, or show usage information if no arguments
                Options = SimpleCommandLineParser.Default.Parse<ProgramOptions>(args);

                // Set game abbreviation and type depending on if Royal or Vanilla
                if (Options.Game.ToUpper().Equals("P5R"))
                {
                    SelectedGame.ShortName = "P5R";
                    SelectedGame.Type = "Royal";
                }
            }
            catch (Exception e)
            {
                // Show error if arguments are invalid and quit processing
                Console.WriteLine(e.Message);
                return;
            }

            // Begin building Mod Menu output
            MenuBuilder.Build();
        }
    }

    public class ProgramOptions
    {
        [Option("g", "game", "P5|P5R", "Specifies the game to generate output for. Will use P5 if not specified.")]
        public string Game { get; set; } = "P5";

        [Option("e", "encoding", "P5|P5R_EFIGS|SJ", "Specifies the encoding to compile with. Will use P5 if not specified.")]
        public string Encoding { get; set; } = "P5";

        [Option("o", "output", "path", "Specifies the path to the directory to use as output.")]
        public string Output { get; set; } = ".\\Output";
    }

    public class InputFile
    {
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public string Archive { get; set; } = "";
        public string HookPath { get; set; } = "";

    }

    public class Game
    {
        public string Type { get; set; } = "Vanilla";
        public string ShortName { get; set; } = "P5";
    }
}

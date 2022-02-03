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
        public static string exeDir;

        public static List<InputFile> InputFiles = new List<InputFile>()
        {
            new InputFile() { Name = "at_dng.bf", Path = "field", Archive = "atDngPack.pac", HookPath = "mementos" },
            new InputFile() { Name = "dungeon.bf", Path = "field", Archive = "dngPack.pac", HookPath = "palace" },
            new InputFile() { Name = "field.bf", Path = "field", Archive = "fldPack.pac", HookPath = "overworld" },
            new InputFile() { Name = "fscr0150_002_100.bf", Path = "script\\field", Archive = "", HookPath = "introduction" },
            new InputFile() { Name = "sharedUI.spd", Path = "camp\\shared", Archive = "", HookPath = "" }
        };

        public static List<string> Scripts = new List<string>()
        {
            "ModMenu\\Calendar\\Calendar.flow",

            "ModMenu\\Call\\Battle\\Battle.flow",
            "ModMenu\\Call\\Cutins\\Cutins.flow",
            "ModMenu\\Call\\Events\\Events.flow",
            "ModMenu\\Call\\Fields\\Fields.flow",
            "ModMenu\\Call\\Font\\Font.flow",
            "ModMenu\\Call\\Sound\\Sound.flow",
            "ModMenu\\Call\\Call.flow",

            "ModMenu\\Camera\\Environment\\Environment.flow",
            "ModMenu\\Camera\\Camera.flow",

            "ModMenu\\Flags\\Category\\HUD\\HUDFlags.flow",
            "ModMenu\\Flags\\Category\\Party\\PartyFlags.flow",
            "ModMenu\\Flags\\Category\\Personas\\PersonaFlags.flow",
            "ModMenu\\Flags\\Category\\Room\\RoomFlags.flow",
            "ModMenu\\Flags\\Category\\FlagCategories.flow",
            "ModMenu\\Flags\\Flags.flow",

            "ModMenu\\Player\\Appearance\\Animation\\PlayerAnimation.flow",
            "ModMenu\\Player\\Appearance\\Model\\PlayerModel.flow",
            "ModMenu\\Player\\Appearance\\PlayerAppearance.flow",
            "ModMenu\\Player\\Confidants\\Confidants.flow",
            "ModMenu\\Player\\Items\\Items.flow",
            "ModMenu\\Player\\Personas\\Reserve\\ReservePersonas.flow",
            "ModMenu\\Player\\Personas\\Select\\PersonaSelect.flow",
            "ModMenu\\Player\\Personas\\Personas.flow",
            "ModMenu\\Player\\Skills\\Reserve\\ReserveSkills.flow",
            "ModMenu\\Player\\Skills\\Select\\SkillSelect.flow",
            "ModMenu\\Player\\Skills\\Skills.flow",
            "ModMenu\\Player\\Stats\\Stats.flow",
            "ModMenu\\Player\\Player.flow",

            "ModMenu\\Royal\\Royal.flow",

            "ModMenu\\Spawn\\FieldModels\\FieldModels.flow",
            "ModMenu\\Spawn\\NPCs\\Animation\\NPCAnimation.flow",
            "ModMenu\\Spawn\\NPCs\\NPCs.flow",
            "ModMenu\\Spawn\\Particles\\Particles.flow",

            "Utilities\\AssignNames.flow",
            "Utilities\\Math.flow",
            "Utilities\\Utilities.flow",

            "ModMenu\\ModMenu.flow",
        };

        static void Main(string[] args)
        {
            // Get executing directory
            exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            // Show about message
            Console.Write(SimpleCommandLineFormatter.Default.FormatAbout<ProgramOptions>("ShrineFox", 
                "\nGenerates Mod Menu output for P5/P5R." +
                "\nUsing TGE's SimpleCommandLine and AtlusFileSystemLibrary." +
                "\n\ngithub.com/ShrineFox/Persona-5-Mod-Menu" +
                "\n"));

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

                if (!File.Exists(Options.Compiler))
                {
                    Console.WriteLine($"Could not find AtlusScriptCompiler.exe at path: {Options.Compiler}");
                    Console.ReadKey();
                    return;
                }
            }
            catch (Exception e)
            {
                // Show error if arguments are invalid and quit processing
                Console.WriteLine(e.Message);
                #if DEBUG
                    Console.ReadKey();
                #endif
                return;
            }

            // Begin building Mod Menu output
            MenuBuilder.Build();
        }
    }

    public class ProgramOptions
    {
        [Option("c", "compiler", "path", "The path to AtlusScriptCompiler.exe.", Required = true)]
        public string Compiler { get; set; }

        [Option("g", "game", "P5|P5R", "Specifies the game to generate output for. Will use P5 if not specified.")]
        public string Game { get; set; } = "P5";

        [Option("e", "encoding", "P5|P5R_EFIGS|SJ", "Specifies the encoding to compile with. Will use P5 if not specified.")]
        public string Encoding { get; set; } = "P5";

        [Option("o", "output", "path", "Specifies the path to the directory to use as output.")]
        public string Output { get; set; } = "";
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

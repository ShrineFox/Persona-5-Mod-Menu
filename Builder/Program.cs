using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGE.SimpleCommandLine;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public class Program
    {
        public static ProgramOptions Options { get; private set; }
        public static Game SelectedGame { get; private set; } = new Game();
        public static string exeDir;

        public static List<InputFile> InputFiles = new List<InputFile>()
        {
            new InputFile() { Name = "at_dng.bf", Path = "field\\etc", Archive = "field\\atDngPack.pac", HookPath = "mementos" },
            new InputFile() { Name = "dungeon.bf", Path = "field\\etc", Archive = "field\\dngPack.pac", HookPath = "palace" },
            new InputFile() { Name = "field.bf", Path = "field\\etc", Archive = "field\\fldPack.pac", HookPath = "overworld" },
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

        [STAThread]
        private static void Main(string[] args)
        {
            // Set Logging Stuff
            Output.Logging = true;
            Output.LogToFile = false;
            #if DEBUG
                Output.VerboseLogging = true;
                Output.LogPath = "ModMenuBuilder_DebugLog.txt";
            #endif
            // Get executing directory
            exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            if (args.Length > 0)
                StartWithOptions(args);
            else
            {
                Hide();
                Application.Run(new BuilderForm());
            }
        }

        public static void StartWithOptions(string[] args)
        {
            try
            {
                // Validate input arguments, or show usage information if no arguments
                Options = SimpleCommandLineParser.Default.Parse<ProgramOptions>(args);

                // Set the platform type. Used for output directory structure (Old: PS3/PS4, New: Switch/PC)
                if (Options.NewPlatform)
                    SelectedGame.Platform = PlatformType.New;
                else
                    SelectedGame.Platform = PlatformType.Old;

                // Set game abbreviation and type depending on if Royal or Vanilla
                if (!Options.Game.ToUpper().Equals("P5R"))
                {
                    SelectedGame.ShortName = "P5";
                    SelectedGame.Type = GameType.Vanilla;
                    SelectedGame.Platform = PlatformType.Old;
                }

                if (!File.Exists(Options.Compiler))
                {
                    Output.Log($"Could not find AtlusScriptCompiler.exe at path: {Options.Compiler}");
                    Console.ReadKey();
                    return;
                }
            }
            catch (Exception e)
            {
                // Show error if arguments are invalid and quit processing
                Output.Log(e.Message);
#if DEBUG
                Console.ReadKey();
#endif
                return;
            }

            Output.Log($"Building {SelectedGame.ShortName} ({SelectedGame.Platform} platforms) Mod Menu with unpacked PACs set to {Options.Unpack}.\n\n");

            // Begin building Mod Menu output
            MenuBuilder.Build();
        }

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        readonly static IntPtr handle = GetConsoleWindow();
        [DllImport("kernel32.dll")] static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Hide()
        {
            ShowWindow(handle, SW_HIDE); //hide the console
        }
        public static void Show()
        {
            ShowWindow(handle, SW_SHOW); //show the console
        }
    }

    public class ProgramOptions
    {
        [Option("c", "compiler", "path", "The path to AtlusScriptCompiler.exe.", Required = true)]
        public string Compiler { get; set; }

        [Option("e", "encoding", "P5|P5R_EFIGS|SJ", "Specifies the encoding to compile with. (default: P5R_EFIGS)")]
        public string Encoding { get; set; } = "P5R_EFIGS";

        [Option("g", "game", "P5|P5R", "Specifies the game to generate output for. (default: P5R)")]
        public string Game { get; set; } = "P5R";

        [Option("n", "newplatform", "bool", "Whether to use PC/Switch directory structure instead of Sony. (default: true)")]
        public bool NewPlatform { get; set; } = true;

        [Option("o", "output", "path", "Specifies the path to the directory to use as output. (default: .exe directory)")]
        public string Output { get; set; } = "";

        [Option("u", "unpacked", "bool", "If specified, output .BF files will not be repacked into .PAC files. (default: true)")]
        public bool Unpack { get; set; } = true;
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
        public GameType Type { get; set; } = GameType.Royal;
        public PlatformType Platform { get; set; } = PlatformType.New;
        public string ShortName { get; set; } = "P5R";
    }

    public enum GameType
    {
        Royal,
        Vanilla
    }

    public enum PlatformType
    {
        New,
        Old
    }
}

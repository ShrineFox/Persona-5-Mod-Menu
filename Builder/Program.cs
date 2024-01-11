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
using System.Runtime;
using Newtonsoft.Json;

namespace ModMenuBuilder
{
    public class Program
    {
        public static ProgramOptions Options { get; private set; }
        public static Game SelectedGame { get; private set; } = new Game();
        public static string exeDir;
        public static string jsonPath = "./settings.json";

        [STAThread]
        private static void Main(string[] args)
        {
            WinForms.SetDefaultIcon();
            SetupOutputLogging();
            GetExeDir();

            if (args.Length > 0)
            {
                // Validate input arguments, or show usage information if no arguments
                Options = SimpleCommandLineParser.Default.Parse<ProgramOptions>(args);

                // Begin preparing for script building based on options
                StartWithOptions();

#if DEBUG
                // On debug build, don't immediately close program when finished
                Console.WriteLine("Done building, press any key to exit.");
                Console.ReadKey();
#endif
            }
            else
            {
                // Show GUI if program was started without any commandline arguments
                Program.Options = new ProgramOptions();
                Hide();
                Application.Run(new BuilderForm());
            }
        }

        private static void GetExeDir()
        {
            exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        private static void SetupOutputLogging()
        {
            Output.Logging = true;
            Output.LogToFile = true;
#if DEBUG
            Output.VerboseLogging = true;
            Output.LogPath = "ModMenuBuilder_DebugLog.txt";
#endif
        }

        public static void StartWithOptions()
        {
            try
            {
                // Set the platform type. Used for output directory structure (Old: PS3/PS4, New: Switch/PC)
                switch(Options.Game)
                {
                    case "P5_PS3":
                        SelectedGame.Version = GameVersion.P5_PS3;
                        SelectedGame.Platform = PlatformType.Old;
                        SelectedGame.Type = GameType.Vanilla;
                        SelectedGame.ShortName = "P5";
                        SelectedGame.ConsoleName = "PS3";
                        break;
                    case "P5_PS3_EX":
                        SelectedGame.Version = GameVersion.P5_PS3_EX;
                        SelectedGame.Platform = PlatformType.Old;
                        SelectedGame.Type = GameType.Vanilla;
                        SelectedGame.ShortName = "P5EX";
                        SelectedGame.ConsoleName = "PS3";
                        break;
                    case "P5_PS4":
                        SelectedGame.Version = GameVersion.P5_PS4;
                        SelectedGame.Platform = PlatformType.Old;
                        SelectedGame.Type = GameType.Vanilla;
                        SelectedGame.ShortName = "P5";
                        SelectedGame.ConsoleName = "PS4";
                        break;
                    case "P5R_PS4":
                        SelectedGame.Version = GameVersion.P5R_PS4;
                        SelectedGame.Platform = PlatformType.Old;
                        SelectedGame.Type = GameType.Royal;
                        SelectedGame.ShortName = "P5R";
                        SelectedGame.ConsoleName = "PS4";
                        break;
                    case "P5R_Switch":
                        SelectedGame.Version = GameVersion.P5R_Switch;
                        SelectedGame.Platform = PlatformType.New;
                        SelectedGame.Type = GameType.Royal;
                        SelectedGame.ShortName = "P5R";
                        SelectedGame.ConsoleName = "Switch";
                        break;
                    case "P5R_PC":
                        SelectedGame.Version = GameVersion.P5R_PC;
                        SelectedGame.Platform = PlatformType.New;
                        SelectedGame.Type = GameType.Royal;
                        SelectedGame.ShortName = "P5R";
                        SelectedGame.ConsoleName = "PC";
                        break;
                    default:
                        Output.Log($"Game selection is not valid!", ConsoleColor.Red);
                        return;
                }
            }
            catch (Exception e)
            {
                // Show error if arguments are invalid and quit processing
                Output.Log($"ERROR CAUGHT: {e.Message}", ConsoleColor.DarkRed);
                return;
            }

            Output.Log($"Building {SelectedGame.Version} Mod Menu" +
                $"\n\tDecompile output: {Options.Decompile}" +
                $"\n\tRepack .PACs: {Options.Pack}" +
                $"\n\tVersion string: {Options.Version}\n\n");

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
            ShowWindow(handle, SW_HIDE); // hide the console window
        }
        public static void Show()
        {
            ShowWindow(handle, SW_SHOW); // show the console window
        }

        public static void SaveOptionsJson()
        {
            if (Options == null)
                return;
            string jsonText = JsonConvert.SerializeObject(Options, Formatting.Indented);
            File.WriteAllText(jsonPath, jsonText);
        }

        public static void LoadOptions()
        {
            if (File.Exists(jsonPath))
                Options = JsonConvert.DeserializeObject<ProgramOptions>(File.ReadAllText(jsonPath));
        }
    }

    public class ProgramOptions
    {

        [Option("d", "decompile", "bool", "Whether to decompile output scripts for debugging. (default: false)")]
        public bool Decompile { get; set; } = false;

        [Option("e", "encoding", "P5|P5R_EFIGS|SJ", "Specifies the encoding to compile with. (default: P5R_EFIGS)")]
        public string Encoding { get; set; } = "P5R_EFIGS";

        [Option("g", "game", "P5_PS3|P5_PS3_EX|P5_PS4|P5R_PS4|P5R_Switch|P5R_PC", "Specifies the game to generate output for. (default: P5R_PC)")]
        public string Game { get; set; } = "P5R_PC";

        [Option("o", "output", "path", "Specifies the path to the directory to use as output. (default: .exe directory)")]
        public string Output { get; set; } = "";

        [Option("p", "pack", "bool", "Whether to output field scripts as repacked .PAC (old platform only). (default: false)")]
        public bool Pack { get; set; } = false;

        [Option("r", "reindex", "bool", "Whether to re-number messages, takes longer but fixes descriptions. (default: false)")]
        public bool Reindex { get; set; } = false;

        [Option("v", "version", "string", "Version string to show in About Menu option. (default: blank)")]
        public string Version { get; set; } = "";
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
        public GameVersion Version { get; set; } = GameVersion.P5R_PC;
        public string ShortName { get; set; } = "P5R";
        public string ConsoleName { get; set; } = "PC";
    }

    public enum GameType
    {
        Royal,
        Vanilla
    }

    public enum GameVersion
    {
        P5_PS3,
        P5_PS3_EX,
        P5_PS4,
        P5R_PS4,
        P5R_Switch,
        P5R_PC
    }

    public enum PlatformType
    {
        New,
        Old
    }
}

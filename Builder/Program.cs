using Newtonsoft.Json;
using ShrineFox.IO;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using TGE.SimpleCommandLine;

namespace ModMenuBuilder
{
    public class Program
    {
        public static Settings settings { get; private set; } = new Settings();
        public static string jsonPath = "./settings.json";
        public static string exeDir = "";

        [STAThread]
        private static void Main(string[] args)
        {
            WinForms.SetDefaultIcon();
            SetupOutputLogging();
            GetExeDir();

            if (args.Length > 0)
            {
                // Validate input arguments, or show usage information if no arguments
                settings = SimpleCommandLineParser.Default.Parse<Settings>(args);

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
                if (File.Exists(jsonPath))
                    LoadJson(jsonPath);
                // Show GUI if program was started without any commandline arguments
                Hide();
                Application.Run(new BuilderForm());
            }
        }

        public static void SaveJson(string jsonPath)
        {
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented));
        }

        public static void LoadJson(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                return;

            string jsonText = File.ReadAllText(Path.GetFullPath(jsonPath));
            settings = JsonConvert.DeserializeObject<Settings>(jsonText);
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
                switch(settings.Game)
                {
                    case "P5_PS3":
                        SelectedGameVersion = GameVersion.P5_PS3;
                        SelectedGamePlatform = PlatformType.Old;
                        SelectedGameType = GameType.Vanilla;
                        SelectedGameShortName = "P5";
                        SelectedConsoleName = "PS3";
                        break;
                    case "P5_PS3_EX":
                        SelectedGameVersion = GameVersion.P5_PS3_EX;
                        SelectedGamePlatform = PlatformType.Old;
                        SelectedGameType = GameType.Vanilla;
                        SelectedGameShortName = "P5EX";
                        SelectedConsoleName = "PS3";
                        break;
                    case "P5_PS4":
                        SelectedGameVersion = GameVersion.P5_PS4;
                        SelectedGamePlatform = PlatformType.Old;
                        SelectedGameType = GameType.Vanilla;
                        SelectedGameShortName = "P5";
                        SelectedConsoleName = "PS4";
                        break;
                    case "P5R_PS4":
                        SelectedGameVersion = GameVersion.P5R_PS4;
                        SelectedGamePlatform = PlatformType.Old;
                        SelectedGameType = GameType.Royal;
                        SelectedGameShortName = "P5R";
                        SelectedConsoleName = "PS4";
                        break;
                    case "P5R_Switch":
                        SelectedGameVersion = GameVersion.P5R_Switch;
                        SelectedGamePlatform = PlatformType.New;
                        SelectedGameType = GameType.Royal;
                        SelectedGameShortName = "P5R";
                        SelectedConsoleName = "Switch";
                        break;
                    case "P5R_PC":
                        SelectedGameVersion = GameVersion.P5R_PC;
                        SelectedGamePlatform = PlatformType.New;
                        SelectedGameType = GameType.Royal;
                        SelectedGameShortName = "P5R";
                        SelectedConsoleName = "PC";
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

            Output.Log($"Building {SelectedGameVersion} Mod Menu" +
                $"\n\tDecompile output: {settings.Decompile}" +
                $"\n\tRepack .PACs: {settings.Pack}" +
                $"\n\tVersion string: {settings.VersionString}\n\n");

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

        public static GameType SelectedGameType { get; set; } = GameType.Royal;
        public static PlatformType SelectedGamePlatform { get; set; } = PlatformType.New;
        public static GameVersion SelectedGameVersion { get; set; } = GameVersion.P5R_PC;
        public static string SelectedGameShortName = "";
        public static string SelectedConsoleName = "";
    }

    public class Settings
    {
        [Option("c", "compiler", "string", "Path to AtlusScriptCompiler.exe.")]
        public string CompilerPath { get; set; } = "";

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

        [Option("v", "version", "string", "Version string to show in About Menu option. (default: blank)")]
        public string VersionString { get; set; } = "";
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

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

                // Begin building Mod Menu output
                MenuBuilder.Build();
            }
            catch (Exception e)
            {
                // Show error if arguments are invalid
                Console.WriteLine(e.Message);
                return;
            }
        }
    }

    public class ProgramOptions
    {
        [Option("g", "game", "P5|P5R", "Specifies the game to generate output for. Will use P5 if not specified.")]
        public string Game { get; set; } = "P5";

        [Option("e", "encoding", "P5|SJ", "Specifies the encoding to compile with. Will use P5 if not specified.")]
        public string Encoding { get; set; } = "P5";

        [Option("o", "output", "path", "Specifies the path to the directory to use as output.")]
        public string Output { get; set; } = ".\\Output";
    }

    public static class InputFiles
    {
        public static string[] PAC = new string[] { "atDngPack.pac", "dngPack.pac", "fldPack.pac" };
        public static string[] BF = new string[] { "at_dng.bf", "dungeon.bf", "field.bf", "fscr0150_002_100.bf" };
    }
}

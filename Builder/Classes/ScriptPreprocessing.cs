using ShrineFox.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ModMenuBuilder
{
    public partial class MenuBuilder
    {
        private static void RemoveMsgComments(string script)
        {
            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            string selectedType = "Royal";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
            {
                removeType = "Royal";
                selectedType = "Vanilla";
            }

            if (File.Exists(script))
            {
                var lines = File.ReadAllLines(script);
                List<string> newLines = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    // Remove entire line if opposite type
                    if (line.Contains($"// {removeType}") || line.Contains($"//{removeType}"))
                        line = "";
                    else
                        line = line.Replace($"// {selectedType}", "").Replace($"//{selectedType}", "");

                    if (line.Contains("// Version") || line.Contains("//Version"))
                    {
                        line = line.Replace("// Version", $"[n]{Program.Options.Version}").Replace("//Version", $"[n]{Program.Options.Version}");
                    }
                    if (!string.IsNullOrEmpty(line))
                        newLines.Add(line);
                }

                File.WriteAllText(script, String.Join("\n", newLines), Encoding.Unicode);
            }
            else
                Output.Log($"\tCould not find script to remove .msg comments from:\n  {script}", ConsoleColor.Red);
        }

        private static void RemoveFlowComments(string script)
        {
            // Remove lines with the opposite game type's comment from Mod Menu .msg
            string removeType = "Vanilla";
            if (Program.SelectedGame.Type.Equals(GameType.Vanilla))
                removeType = "Royal";

            if (File.Exists(script))
            {
                // Comment out blocks for opposing game type
                string text = File.ReadAllText(script);
                text = text.Replace($"/* {removeType} Start */", $"/* {removeType} Start ")
                    .Replace($"/* {removeType} End */", $" {removeType} End */");

                // Remove lines with the wrong console name's comment from Mod Menu .msg
                foreach (var console in new List<string>() { "PS3", "PS4", "Switch", "PC" }.Where(x => !x.Equals(Program.SelectedGame.ConsoleName)))
                {
                    text = text.Replace($"/* {console} Start */", $"/* {console} Start ")
                    .Replace($"/* {console} End */", $" {console} End */");
                }

                text = RemoveBetween(text, "/*", "*/");
                File.WriteAllText(script, text, Encoding.Unicode);
            }
            else
                Output.Log($"\tCould not find script to remove .flow comments from:\n  {script}", ConsoleColor.Red);
        }

        public static string RemoveBetween(string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.Singleline);
            return regex.Replace(sourceString, startTag + endTag);
        }
    }
}

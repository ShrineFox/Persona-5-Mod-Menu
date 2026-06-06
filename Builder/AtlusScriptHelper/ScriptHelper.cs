using Microsoft.CSharp.RuntimeBinder;
using Octokit;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;

namespace AtlusScriptHelper
{
    public class ScriptHelper
    {
        public static string AtlusScriptToolsExePath { get; set; } = "./Atlus-Script-Tools/AtlusScriptCompiler.exe";

        public static async Task UpdateCompiler()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("AST-Updater"));

                Release release = await client.Repository.Release.GetLatest("tge-was-taken", "Atlus-Script-Tools");
                
                //if (versionComparison > 0)
                {
                    // Download Release
                    //try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            webClient.DownloadFile(release.Assets[0].BrowserDownloadUrl, "./master.zip");
                        }
                        if (Directory.Exists("./master/"))
                        {
                            Directory.Delete("./master/", true);
                        }
                        ZipFile.ExtractToDirectory("./master.zip", "./master/");
                        File.Delete("./master.zip");
                        //File.WriteAllText(versionTxtPath, latestGitHubVersion.ToString());
                    }
                    //catch (Exception ex)
                    {
                    }
                }
            
        }

        public static async Task RunCompiler(string args)
        {
            //if (!File.Exists(AtlusScriptToolsExePath))
            //    await UpdateCompiler();

            Run(Path.GetFullPath(AtlusScriptToolsExePath), args);
        }

        public static string ConcatMsgs(string msgsDir)
        {
            string txt = "";
            foreach(var file in Directory.GetFiles(msgsDir, "*.msg", SearchOption.AllDirectories))
            {
                txt += File.ReadAllText(file) + "\r\n";
            }
            return txt;
        }

        public static bool Run(string exePath, string args = "")
        {
            int exitCode = 0;
            using (Process p = new Process())
            {
                p.StartInfo.FileName = exePath;
                p.StartInfo.Arguments = args;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                p.Start();
                p.WaitForExit();
                exitCode = p.ExitCode;

                p.Close();
                p.Dispose();
            }

            if (exitCode == 0)
                return true;
            return false;
        }

        public static void RemoveFlowComments(string script, string removeIfComment = "Vanilla", bool completelyRemoveComments = false)
        {
            if (File.Exists(script))
            {
                string text = File.ReadAllText(script);
                
                // Comment out blocks that only pertain to specific game version (i.e. Royal, Vanilla)
                text = text.Replace($"/* {removeIfComment} Start */", $"/* {removeIfComment} Start ")
                .Replace($"/* {removeIfComment} End */", $" {removeIfComment} End */");

                // Optionally remove commented out blocks entirely from script
                if (completelyRemoveComments)
                    text = RemoveBetween(text, "/*", "*/");

                File.WriteAllText(script, text, Encoding.Unicode);
            }
        }

        public static string RemoveBetween(string sourceString, string startTag, string endTag)
        {
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape(startTag), Regex.Escape(endTag)), RegexOptions.Singleline);
            return regex.Replace(sourceString, startTag + endTag);
        }

        public static async void ReindexMsgs(string script, string msgFile, string bfPathRelativeToFlow)
        {
            // STEP 1: Compile FLOW to BF to get msg file and header
            string tempDir = Path.GetDirectoryName(script);
            string tempFlow = Path.Combine(tempDir, "temp.flow");
            string tempBf = Path.Combine(tempDir, "temp.bf");
            string tempMsg = Path.Combine(tempDir, "temp.msg");
            string tempMsgHeader = tempMsg + ".h";
            
            if (File.Exists(tempFlow))
                File.Delete(tempFlow);
            if (File.Exists(tempBf))
                File.Delete(tempBf);
            if (File.Exists(tempMsg))
                File.Delete(tempMsg);
            if (File.Exists(tempMsgHeader))
                File.Delete(tempMsgHeader);

            string scriptTxt = File.ReadAllText(script);
            // Create temporary .FLOW with import of original .BF
            File.WriteAllText(tempFlow, $"import( \"{bfPathRelativeToFlow.Replace("\\","/")}\" );\r\n"
                + scriptTxt);

            // Compile .FLOW to .BF
            await RunCompiler($"-Compile \"{tempFlow}\" -Library P5R -Encoding P5R_EFIGS -OutFormat V3BE -Hook -SumBits -Out \"{tempBf}\"");
            
            if (!File.Exists(tempBf))
                return; // TODO: Error message

            await RunCompiler($"-Decompile \"{tempBf}\" -Library P5R -Encoding P5R_EFIGS -Hook -SumBits");
            if (!File.Exists(tempMsgHeader))
                return; // TODO: Error message

            // If compilation and decompilation succeeds, save indexes of GENERIC_HELP msgs and their references
            var msgNames = File.ReadAllLines(tempMsgHeader);
            List<Tuple<string, int, int>> msgIndexes = new List<Tuple<string, int, int>>(); // sel_name, help_index, overall_msg_index
            for (int i = 0; i < msgNames.Length; i++)
            {
                if (msgNames[i].StartsWith("const int GENERIC_HELP_"))
                {
                    for (int x = i - 1; x > 0; x--)
                    {
                        if (!msgNames[x].StartsWith("const int GENERIC_HELP_"))
                        {
                            string selName = msgNames[x].Replace("const int ", "").Split(' ')[0];
                            msgIndexes.Add(new Tuple<string, int, int>(selName, msgIndexes.Count(x => x.Item1.Equals(selName)), i - 1));
                            break;
                        }
                    }
                }
            }

            //foreach(var msgFile in Directory.GetFiles(msgsDir, "*.msg", SearchOption.AllDirectories))
            if (File.Exists(msgFile))
            {
                string[] msgLines = File.ReadAllLines(msgFile);
                int helpCountSinceLastSel = 0;

                string latestSel = "";
                for (int i = 0; i < msgLines.Length; i++)
                {
                    if (msgLines[i].Contains("[sel "))
                    {
                        latestSel = msgLines[i];
                        helpCountSinceLastSel = 0;
                    }

                    // If current line contains "[ref "...
                    if (msgLines[i].Contains("[ref "))
                    {
                        for (int x = i; x < msgLines.Length; x++)
                        {
                            if (!msgLines[x].Contains("[ref "))
                            {
                                i = x;
                                break;
                            }
                            // Get name of selection option
                            int refIndex = msgLines[x].IndexOf("[ref ");
                            string substring = msgLines[x].Substring(refIndex);
                            // Create new option string with reindexed ref block
                            string newString = $"{substring}[ref {i - x} {msgIndexes.Where(x => x.Item1.Equals(latestSel)).ToList()[i - x]}]";
                            // Update line with new data
                            msgLines[x] = newString;
                        }
                    }

                    if (msgLines[i].Contains("[dlg GENERIC_HELP_") || msgLines[i].Contains("[msg GENERIC_HELP_"))
                    {
                        msgLines[i] = $"[dlg GENERIC_HELP_{msgIndexes.Where(x => x.Item1.Equals(latestSel)).ToList()[i - helpCountSinceLastSel]}]";
                        helpCountSinceLastSel++;
                    }
                }
                

                File.WriteAllText(msgFile, string.Join("\n", msgLines), Encoding.Unicode);
            }

        }

        public static FileStream WaitForFile(string fullPath,
            System.IO.FileMode mode = System.IO.FileMode.Open,
            FileAccess access = FileAccess.ReadWrite,
            FileShare share = FileShare.None)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fullPath, mode, access, share);
                    return fs;
                }
                catch (IOException)
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                    Thread.Sleep(2000);
                }
            }
            return null;
        }

        public static void RemoveMsgComments(string msgFile, string newMsgDest, string removeIfComment = "Royal")
        {
            if (!File.Exists(msgFile))
                return;

            var lines = File.ReadAllLines(msgFile);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // Remove entire line if comment doesn't match given string
                if (line.Contains($"// {removeIfComment}") || line.Contains($"//{removeIfComment}"))
                    lines[i] = line.Replace($"// {removeIfComment}", "").Replace($"//{removeIfComment}", "");
                else if (line.Contains("//"))
                    lines[i] = "";
            }

            File.WriteAllText(newMsgDest, String.Join("\n", lines), Encoding.Unicode);
        }

        public static void RemoveMsgImports(string scriptsDir)
        {
            foreach(var file in Directory.GetFiles(scriptsDir, "*.flow", SearchOption.AllDirectories))
            {
                var lines = File.ReadAllLines(file);
                for(int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(".msg"))
                        lines[i] = "//" + lines[i];
                }
                File.WriteAllText(file, String.Join("\n", lines), Encoding.Unicode);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMenuBuilder
{
    public class Tools
    {
        public static void RunCmd(string program, string[] args)
        {
            ProcessStartInfo cmdInfo = new ProcessStartInfo();
            cmdInfo.CreateNoWindow = false;
            cmdInfo.UseShellExecute = false;
            cmdInfo.FileName = $"\"{program}\"";
            cmdInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmdInfo.WorkingDirectory = Program.exeDir;
            cmdInfo.Arguments = string.Join(" ", args);

            using (Process process = new Process())
            {
                process.StartInfo = cmdInfo;
                process.Start();
                process.WaitForExit();
            }
        }

        public static void CopyDir(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            // Get Files & Copy
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }

            // Get dirs recursively and copy files
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyDir(folder, dest);
            }
        }
    }
}

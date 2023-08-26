using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public partial class BuilderForm : DarkUI.Forms.DarkForm
    {
        bool changedSettings = false;
        public BuilderForm()
        {
            InitializeComponent();
            Output.LogControl = rtb_Log;
            if (File.Exists("compilerPath.txt"))
                txt_Path.Text = File.ReadAllText("compilerPath.txt");
            if (File.Exists("outputPath.txt"))
                txt_OutPath.Text = File.ReadAllText("outputPath.txt");
            if (File.Exists("version.txt"))
                txt_Version.Text = File.ReadAllText("version.txt");
            try
            {
                comboBox_Version.SelectedIndex = comboBox_Version.Items.IndexOf("P5R_PC");
                if (File.Exists("game.txt"))
                    comboBox_Version.SelectedIndex = comboBox_Version.Items.IndexOf(File.ReadAllText("game.txt"));
            } catch { }
            try
            {
                comboBox_Encoding.SelectedIndex = comboBox_Encoding.Items.IndexOf("P5R_EFIGS");
                if (File.Exists("encoding.txt"))
                    comboBox_Encoding.SelectedIndex = comboBox_Encoding.Items.IndexOf(File.ReadAllText("encoding.txt"));
            }
            catch { }
            changedSettings = true;

#if DEBUG
            Program.Show();
            System.Threading.Thread.Sleep(200);
            Output.LogControl = null;
            chk_Reindex.Checked = false;
            chk_Decompile.Checked = true;
#endif

            rtb_Log.Text += $"{this.Text} by ShrineFox\nProcesses and compiles scripts for Persona 5 on PS3, PS4, PC and Switch.";
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();

            List<string> args = new List<string>();

            args.Add("-g"); args.Add(comboBox_Version.Text);
            args.Add("-e"); args.Add(comboBox_Encoding.Text);
            args.Add("-c"); args.Add(txt_Path.Text);
            if (chk_Decompile.Checked)
            {
                args.Add("-d"); args.Add("true");
            }
            if (chk_Reindex.Checked)
            {
                args.Add("-r"); args.Add("true");
            }
            if (chk_RepackPACs.Checked)
            {
                args.Add("-p"); args.Add("true");
            }
            if (!string.IsNullOrEmpty(txt_Version.Text))
            {
                args.Add("-v"); args.Add(txt_Version.Text);
            }
            args.Add("-o"); args.Add(txt_OutPath.Text);

            if (chk_VerboseLog.Checked)
                Output.VerboseLogging = true;
            else
                Output.VerboseLogging = false;
            btn_Build.Enabled = false;

            Task.Run(() => {
                Program.StartWithOptions(args.ToArray());
            });

            btn_Build.Enabled = true;
            SystemSounds.Exclamation.Play();
        }

        private void Path_Changed(object sender, EventArgs e)
        {
            if (File.Exists(txt_Path.Text) && Directory.Exists(txt_OutPath.Text))
                btn_Build.Enabled = true;
            else
                btn_Build.Enabled = false;
        }

        private void Path_Click(object sender, EventArgs e)
        {
            var paths = WinFormsDialogs.SelectFile("Choose AtlusScriptCompiler.exe", false, new string[] { "Executable File (*.exe)" });
            if (paths.Count > 0)
            {
                if (File.Exists(paths.First()))
                {
                    txt_Path.Text = paths.First();
                    File.WriteAllText("compilerPath.txt", paths.First());
                }
            }
        }

        private void OutPath_Click(object sender, EventArgs e)
        {
            var path = WinFormsDialogs.SelectFolder("Choose Mod Output Folder");
            txt_OutPath.Text = path;
            File.WriteAllText("outputPath.txt", path);
        }

        private void Version_Changed(object sender, EventArgs e)
        {
            if (comboBox_Version.Text.Contains("P5_") || comboBox_Version.Text.Contains("PS4"))
            {
                chk_RepackPACs.Enabled = true;
            }
            else
            {
                chk_RepackPACs.Checked = false;
                chk_RepackPACs.Enabled = false;
            }

            if (changedSettings)
                File.WriteAllText("game.txt", comboBox_Version.Text);
        }

        private void VersionString_Changed(object sender, EventArgs e)
        {
            File.WriteAllText("version.txt", txt_Version.Text);
        }

        private void Encoding_Changed(object sender, EventArgs e)
        {
            if (changedSettings)
                File.WriteAllText("encoding.txt", comboBox_Encoding.Text);
        }
    }
}

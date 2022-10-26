using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public partial class BuilderForm : DarkUI.Forms.DarkForm
    {
        public BuilderForm()
        {
            InitializeComponent();
            Output.LogControl = rtb_Log;
#if DEBUG
            txt_Path.Text = @"C:\Users\Administrator\Documents\GitHub\Atlus-Script-Tools\Build\Release\AtlusScriptCompiler.exe";
            txt_OutPath.Text = @"C:\Program Files (x86)\Steam\steamapps\common\P5R\Reloaded\Mods\p5rpc.misc.modmenu\P5REssentials\CPK\EN.CPK";
            Program.Show();
            System.Threading.Thread.Sleep(200);
            Output.LogControl = null;
#endif

        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            List<string> args = new List<string>();
           
            args.Add("-c"); args.Add(txt_Path.Text);
            if (radio_Old.Checked)
            {
                args.Add("-n"); args.Add("false");
            }
            if (radio_Vanilla.Checked)
            {
                args.Add("-g"); args.Add("P5");
                args.Add("-e"); args.Add("P5");
            }
            if (radio_Nintendo.Checked)
            {
                args.Add("-j"); args.Add("NX");
            }
            if (radio_Playstation.Checked)
            {
                args.Add("-j"); args.Add("PS");
            }
            if (radio_Xbox.Checked)
            {
                args.Add("-j"); args.Add("MS");
            }
            args.Add("-o"); args.Add(txt_OutPath.Text);

            Program.StartWithOptions(args.ToArray());
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
            var paths = WinFormsEvents.FilePath_Click("Choose AtlusScriptCompiler.exe", false, new string[] { "Executable File (*.exe)" });
            if (paths.Count > 0)
            {
                if (File.Exists(paths.First()))
                    txt_Path.Text = paths.First();
            }
        }

        private void OutPath_Click(object sender, EventArgs e)
        {
            var path = WinFormsEvents.FolderPath_Click("Choose AtlusScriptCompiler.exe");
            txt_OutPath.Text = path;
        }
    }
}

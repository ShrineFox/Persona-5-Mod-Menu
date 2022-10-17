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
#if DEBUG
            txt_Path.Text = @"C:\Users\Ryan\Documents\GitHub\Atlus-Script-Tools\Build\Debug\AtlusScriptCompiler.exe";
#endif
            Output.LogControl = rtb_Log;
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            List<string> args = new List<string>();
           
            args.Add("-c"); args.Add(txt_Path.Text);
            if (radio_Old.Checked)
            {
                args.Add("-n"); args.Add("false");
            }
            if (radio_Pack.Checked)
            {
                args.Add("-u"); args.Add("false");
            }
            if (radio_Vanilla.Checked)
            {
                args.Add("-g"); args.Add("P5");
                args.Add("-e"); args.Add("P5");
            }
            /* Program.Show();
            System.Threading.Thread.Sleep(200); */
            Program.StartWithOptions(args.ToArray());
        }

        private void Version_Changed(object sender, EventArgs e)
        {
            if (radio_Royal.Checked)
            {
                radio_Unpack.Checked = true;
                groupBox_PACs.Enabled = false;
            }
            else
                groupBox_PACs.Enabled = true;
        }

        private void Path_Changed(object sender, EventArgs e)
        {
            if (File.Exists(txt_Path.Text))
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
    }
}

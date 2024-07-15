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
using System.Xml.Linq;
using MetroSet_UI.Forms;
using ShrineFox.IO;

namespace ModMenuBuilder
{
    public partial class BuilderForm : MetroSetForm
    {
        public BuilderForm()
        {
            // TODO: Figure out why scripts don't build with the GUI anymore
            InitializeComponent();

            // Set Dark Theme
            Theme.ApplyToForm(this);

            // Display output of AtlusScriptCompiler in RichTextBox control
            Output.LogControl = rtb_Log;

            // Load previously used options from .json if available
            Program.LoadOptions();
            comboBox_Encoding.SelectedIndex = comboBox_Encoding.Items.IndexOf(Program.Options.Encoding);
            comboBox_Version.SelectedIndex = comboBox_Version.Items.IndexOf(Program.Options.Game);
            txt_OutPath.Text = Program.Options.Output;
            txt_Version.Text = Program.Options.Version;
            chk_Decompile.Checked = Program.Options.Decompile;
            chk_RepackPACs.Checked = Program.Options.Pack;

            SetDebugDefaults();
        }

        private void SetDebugDefaults()
        {
#if DEBUG
            // When debugging, log to console window instead of form control
            Program.Show();
            Output.LogControl = null;
            // Default to decompiling output and not reindexing (faster)
            chk_Reindex.Checked = false;
            chk_Decompile.Checked = true;
#endif
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();

            // Save form values to options, then save to .json
            Program.Options.Game = comboBox_Version.Text;
            Program.Options.Encoding = comboBox_Encoding.Text;
            Program.Options.Output = txt_OutPath.Text;
            Program.Options.Decompile = chk_Decompile.Checked;
            Program.Options.Version = txt_Version.Text;
            Program.Options.Pack = chk_RepackPACs.Checked;
            Program.SaveOptionsJson();

            // Use verbose logging if checked
            if (chk_VerboseLog.Checked)
                Output.VerboseLogging = true;
            else
                Output.VerboseLogging = false;

            Task.Run(() => {
                // Begin script building process
                Program.StartWithOptions();
                // Alert user that building is complete
                SystemSounds.Exclamation.Play();
            });
        }

        private void Path_Changed(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_OutPath.Text))
                btn_Build.Enabled = true;
            else
                btn_Build.Enabled = false;
        }

        private void OutPath_Click(object sender, EventArgs e)
        {
            var path = WinFormsDialogs.SelectFolder("Choose Mod Output Folder");
            txt_OutPath.Text = path;
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
        }

    }
}

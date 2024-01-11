using MetroSet_UI.Forms;
using System.Windows.Forms;

namespace ModMenuBuilder
{
    partial class BuilderForm : MetroSetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuilderForm));
            this.btn_Build = new System.Windows.Forms.Button();
            this.groupBox_Version = new System.Windows.Forms.GroupBox();
            this.comboBox_Version = new System.Windows.Forms.ComboBox();
            this.lbl_OutPath = new System.Windows.Forms.Label();
            this.txt_OutPath = new System.Windows.Forms.TextBox();
            this.btn_OutPath = new System.Windows.Forms.Button();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlp_Paths = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Options = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_Encoding = new System.Windows.Forms.GroupBox();
            this.comboBox_Encoding = new System.Windows.Forms.ComboBox();
            this.tlp_Checkboxes = new System.Windows.Forms.TableLayoutPanel();
            this.chk_VerboseLog = new System.Windows.Forms.CheckBox();
            this.chk_RepackPACs = new System.Windows.Forms.CheckBox();
            this.chk_Reindex = new System.Windows.Forms.CheckBox();
            this.chk_Decompile = new System.Windows.Forms.CheckBox();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.groupBox_VersionString = new System.Windows.Forms.GroupBox();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.groupBox_Version.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.tlp_Paths.SuspendLayout();
            this.tlp_Options.SuspendLayout();
            this.groupBox_Encoding.SuspendLayout();
            this.tlp_Checkboxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.groupBox_VersionString.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Build
            // 
            this.btn_Build.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Build.Enabled = false;
            this.btn_Build.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_Build.Location = new System.Drawing.Point(329, 3);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Build.Size = new System.Drawing.Size(158, 74);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "Build";
            this.btn_Build.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // groupBox_Version
            // 
            this.groupBox_Version.Controls.Add(this.comboBox_Version);
            this.groupBox_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Version.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Version.Name = "groupBox_Version";
            this.groupBox_Version.Size = new System.Drawing.Size(157, 74);
            this.groupBox_Version.TabIndex = 1;
            this.groupBox_Version.TabStop = false;
            this.groupBox_Version.Text = "Version";
            // 
            // comboBox_Version
            // 
            this.comboBox_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.comboBox_Version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Version.ForeColor = System.Drawing.Color.Silver;
            this.comboBox_Version.FormattingEnabled = true;
            this.comboBox_Version.Items.AddRange(new object[] {
            "P5_PS3",
            "P5_PS3_EX",
            "P5_PS4",
            "P5R_PS4",
            "P5R_Switch",
            "P5R_PC"});
            this.comboBox_Version.Location = new System.Drawing.Point(3, 31);
            this.comboBox_Version.Name = "comboBox_Version";
            this.comboBox_Version.Size = new System.Drawing.Size(148, 28);
            this.comboBox_Version.TabIndex = 1;
            this.comboBox_Version.SelectedIndexChanged += new System.EventHandler(this.Version_Changed);
            // 
            // lbl_OutPath
            // 
            this.lbl_OutPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_OutPath.AutoSize = true;
            this.lbl_OutPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_OutPath.Location = new System.Drawing.Point(3, 1);
            this.lbl_OutPath.Name = "lbl_OutPath";
            this.lbl_OutPath.Size = new System.Drawing.Size(220, 20);
            this.lbl_OutPath.TabIndex = 7;
            this.lbl_OutPath.Text = "Output Path:";
            // 
            // txt_OutPath
            // 
            this.txt_OutPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_OutPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_OutPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Paths.SetColumnSpan(this.txt_OutPath, 2);
            this.txt_OutPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_OutPath.Location = new System.Drawing.Point(3, 38);
            this.txt_OutPath.Name = "txt_OutPath";
            this.txt_OutPath.Size = new System.Drawing.Size(446, 26);
            this.txt_OutPath.TabIndex = 8;
            this.txt_OutPath.TextChanged += new System.EventHandler(this.Path_Changed);
            // 
            // btn_OutPath
            // 
            this.btn_OutPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OutPath.Location = new System.Drawing.Point(455, 40);
            this.btn_OutPath.Name = "btn_OutPath";
            this.btn_OutPath.Padding = new System.Windows.Forms.Padding(5);
            this.btn_OutPath.Size = new System.Drawing.Size(32, 23);
            this.btn_OutPath.TabIndex = 9;
            this.btn_OutPath.Text = "...";
            this.btn_OutPath.Click += new System.EventHandler(this.OutPath_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.tlp_Paths, 0, 0);
            this.tlp_Main.Controls.Add(this.tlp_Options, 0, 1);
            this.tlp_Main.Controls.Add(this.tlp_Checkboxes, 0, 2);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(496, 289);
            this.tlp_Main.TabIndex = 10;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rtb_Log.Location = new System.Drawing.Point(0, 0);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(496, 55);
            this.rtb_Log.TabIndex = 3;
            this.rtb_Log.Text = "";
            // 
            // tlp_Paths
            // 
            this.tlp_Paths.ColumnCount = 3;
            this.tlp_Paths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Paths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Paths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlp_Paths.Controls.Add(this.lbl_OutPath, 0, 0);
            this.tlp_Paths.Controls.Add(this.txt_OutPath, 0, 1);
            this.tlp_Paths.Controls.Add(this.btn_OutPath, 2, 1);
            this.tlp_Paths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Paths.Location = new System.Drawing.Point(3, 3);
            this.tlp_Paths.Name = "tlp_Paths";
            this.tlp_Paths.RowCount = 2;
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.03226F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.96774F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Paths.Size = new System.Drawing.Size(490, 80);
            this.tlp_Paths.TabIndex = 0;
            // 
            // tlp_Options
            // 
            this.tlp_Options.ColumnCount = 3;
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.Controls.Add(this.groupBox_Encoding, 1, 0);
            this.tlp_Options.Controls.Add(this.groupBox_Version, 0, 0);
            this.tlp_Options.Controls.Add(this.btn_Build, 2, 0);
            this.tlp_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Options.Location = new System.Drawing.Point(3, 89);
            this.tlp_Options.Name = "tlp_Options";
            this.tlp_Options.RowCount = 1;
            this.tlp_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Options.Size = new System.Drawing.Size(490, 80);
            this.tlp_Options.TabIndex = 1;
            // 
            // groupBox_Encoding
            // 
            this.groupBox_Encoding.Controls.Add(this.comboBox_Encoding);
            this.groupBox_Encoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Encoding.Location = new System.Drawing.Point(166, 3);
            this.groupBox_Encoding.Name = "groupBox_Encoding";
            this.groupBox_Encoding.Size = new System.Drawing.Size(157, 74);
            this.groupBox_Encoding.TabIndex = 2;
            this.groupBox_Encoding.TabStop = false;
            this.groupBox_Encoding.Text = "Encoding";
            // 
            // comboBox_Encoding
            // 
            this.comboBox_Encoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Encoding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.comboBox_Encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Encoding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Encoding.ForeColor = System.Drawing.Color.Silver;
            this.comboBox_Encoding.FormattingEnabled = true;
            this.comboBox_Encoding.Items.AddRange(new object[] {
            "P5",
            "P5R_EFIGS",
            "SJ"});
            this.comboBox_Encoding.Location = new System.Drawing.Point(6, 31);
            this.comboBox_Encoding.Name = "comboBox_Encoding";
            this.comboBox_Encoding.Size = new System.Drawing.Size(148, 28);
            this.comboBox_Encoding.TabIndex = 2;
            // 
            // tlp_Checkboxes
            // 
            this.tlp_Checkboxes.ColumnCount = 3;
            this.tlp_Checkboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Checkboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Checkboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Checkboxes.Controls.Add(this.chk_VerboseLog, 2, 1);
            this.tlp_Checkboxes.Controls.Add(this.chk_RepackPACs, 0, 0);
            this.tlp_Checkboxes.Controls.Add(this.chk_Reindex, 2, 0);
            this.tlp_Checkboxes.Controls.Add(this.chk_Decompile, 1, 0);
            this.tlp_Checkboxes.Controls.Add(this.groupBox_VersionString, 0, 1);
            this.tlp_Checkboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Checkboxes.Location = new System.Drawing.Point(3, 175);
            this.tlp_Checkboxes.Name = "tlp_Checkboxes";
            this.tlp_Checkboxes.RowCount = 2;
            this.tlp_Checkboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Checkboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Checkboxes.Size = new System.Drawing.Size(490, 111);
            this.tlp_Checkboxes.TabIndex = 4;
            // 
            // chk_VerboseLog
            // 
            this.chk_VerboseLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_VerboseLog.AutoSize = true;
            this.chk_VerboseLog.Checked = true;
            this.chk_VerboseLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_VerboseLog.Location = new System.Drawing.Point(339, 71);
            this.chk_VerboseLog.Name = "chk_VerboseLog";
            this.chk_VerboseLog.Size = new System.Drawing.Size(148, 24);
            this.chk_VerboseLog.TabIndex = 11;
            this.chk_VerboseLog.Text = "Verbose Output";
            // 
            // chk_RepackPACs
            // 
            this.chk_RepackPACs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_RepackPACs.AutoSize = true;
            this.chk_RepackPACs.Enabled = false;
            this.chk_RepackPACs.Location = new System.Drawing.Point(3, 15);
            this.chk_RepackPACs.Name = "chk_RepackPACs";
            this.chk_RepackPACs.Size = new System.Drawing.Size(157, 24);
            this.chk_RepackPACs.TabIndex = 2;
            this.chk_RepackPACs.Text = "Pack output .PACs";
            // 
            // chk_Reindex
            // 
            this.chk_Reindex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_Reindex.AutoSize = true;
            this.chk_Reindex.Checked = true;
            this.chk_Reindex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Reindex.Location = new System.Drawing.Point(346, 15);
            this.chk_Reindex.Name = "chk_Reindex";
            this.chk_Reindex.Size = new System.Drawing.Size(141, 24);
            this.chk_Reindex.TabIndex = 0;
            this.chk_Reindex.Text = "Reindex .msgs";
            // 
            // chk_Decompile
            // 
            this.chk_Decompile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_Decompile.AutoSize = true;
            this.chk_Decompile.Location = new System.Drawing.Point(166, 15);
            this.chk_Decompile.Name = "chk_Decompile";
            this.chk_Decompile.Size = new System.Drawing.Size(157, 24);
            this.chk_Decompile.TabIndex = 1;
            this.chk_Decompile.Text = "Decompile output";
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(2, 70);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.tlp_Main);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.rtb_Log);
            this.splitContainer_Main.Size = new System.Drawing.Size(496, 348);
            this.splitContainer_Main.SplitterDistance = 289;
            this.splitContainer_Main.TabIndex = 11;
            // 
            // groupBox_VersionString
            // 
            this.tlp_Checkboxes.SetColumnSpan(this.groupBox_VersionString, 2);
            this.groupBox_VersionString.Controls.Add(this.txt_Version);
            this.groupBox_VersionString.Location = new System.Drawing.Point(3, 58);
            this.groupBox_VersionString.Name = "groupBox_VersionString";
            this.groupBox_VersionString.Size = new System.Drawing.Size(304, 50);
            this.groupBox_VersionString.TabIndex = 12;
            this.groupBox_VersionString.TabStop = false;
            this.groupBox_VersionString.Text = "Version String";
            // 
            // txt_Version
            // 
            this.txt_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_Version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_Version.Location = new System.Drawing.Point(3, 22);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(298, 26);
            this.txt_Version.TabIndex = 11;
            // 
            // BuilderForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.splitContainer_Main);
            this.DropShadowEffect = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.HeaderHeight = -40;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 420);
            this.Name = "BuilderForm";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(2, 70, 2, 2);
            this.ShowHeader = true;
            this.ShowLeftRect = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroSet_UI.Enums.Style.Dark;
            this.Text = "MOD MENU BUILDER";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroDark";
            this.groupBox_Version.ResumeLayout(false);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Paths.ResumeLayout(false);
            this.tlp_Paths.PerformLayout();
            this.tlp_Options.ResumeLayout(false);
            this.groupBox_Encoding.ResumeLayout(false);
            this.tlp_Checkboxes.ResumeLayout(false);
            this.tlp_Checkboxes.PerformLayout();
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.groupBox_VersionString.ResumeLayout(false);
            this.groupBox_VersionString.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.GroupBox groupBox_Version;
        private System.Windows.Forms.TableLayoutPanel tlp_Paths;
        private System.Windows.Forms.Button btn_OutPath;
        private System.Windows.Forms.Label lbl_OutPath;
        private System.Windows.Forms.TextBox txt_OutPath;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Options;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.TableLayoutPanel tlp_Checkboxes;
        private System.Windows.Forms.CheckBox chk_Reindex;
        private System.Windows.Forms.CheckBox chk_Decompile;
        private System.Windows.Forms.CheckBox chk_RepackPACs;
        private System.Windows.Forms.CheckBox chk_VerboseLog;
        private System.Windows.Forms.GroupBox groupBox_Encoding;
        private System.Windows.Forms.ComboBox comboBox_Version;
        private System.Windows.Forms.ComboBox comboBox_Encoding;
        private SplitContainer splitContainer_Main;
        private GroupBox groupBox_VersionString;
        private TextBox txt_Version;
    }
}
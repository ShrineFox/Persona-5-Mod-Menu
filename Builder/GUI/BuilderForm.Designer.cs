
namespace ModMenuBuilder
{
    partial class BuilderForm : DarkUI.Forms.DarkForm
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
            this.btn_Build = new DarkUI.Controls.DarkButton();
            this.groupBox_Version = new DarkUI.Controls.DarkGroupBox();
            this.lbl_Path = new DarkUI.Controls.DarkLabel();
            this.txt_Path = new DarkUI.Controls.DarkTextBox();
            this.btn_Path = new DarkUI.Controls.DarkButton();
            this.lbl_OutPath = new DarkUI.Controls.DarkLabel();
            this.txt_OutPath = new DarkUI.Controls.DarkTextBox();
            this.btn_OutPath = new DarkUI.Controls.DarkButton();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlp_Paths = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Options = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Checkboxes = new System.Windows.Forms.TableLayoutPanel();
            this.chk_VerboseLog = new DarkUI.Controls.DarkCheckBox();
            this.txt_Version = new DarkUI.Controls.DarkTextBox();
            this.chk_RepackPACs = new DarkUI.Controls.DarkCheckBox();
            this.chk_Reindex = new DarkUI.Controls.DarkCheckBox();
            this.chk_Decompile = new DarkUI.Controls.DarkCheckBox();
            this.lbl_Version = new DarkUI.Controls.DarkLabel();
            this.groupBox_Encoding = new DarkUI.Controls.DarkGroupBox();
            this.comboBox_Version = new System.Windows.Forms.ComboBox();
            this.comboBox_Encoding = new System.Windows.Forms.ComboBox();
            this.groupBox_Version.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.tlp_Paths.SuspendLayout();
            this.tlp_Options.SuspendLayout();
            this.tlp_Checkboxes.SuspendLayout();
            this.groupBox_Encoding.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Build
            // 
            this.btn_Build.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Build.Enabled = false;
            this.btn_Build.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_Build.Location = new System.Drawing.Point(291, 3);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Build.Size = new System.Drawing.Size(138, 78);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "Build";
            this.btn_Build.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // groupBox_Version
            // 
            this.groupBox_Version.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Version.Controls.Add(this.comboBox_Version);
            this.groupBox_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Version.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Version.Name = "groupBox_Version";
            this.groupBox_Version.Size = new System.Drawing.Size(138, 78);
            this.groupBox_Version.TabIndex = 1;
            this.groupBox_Version.TabStop = false;
            this.groupBox_Version.Text = "Version";
            // 
            // lbl_Path
            // 
            this.lbl_Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Path.AutoSize = true;
            this.tlp_Paths.SetColumnSpan(this.lbl_Path, 2);
            this.lbl_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_Path.Location = new System.Drawing.Point(3, 0);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(388, 14);
            this.lbl_Path.TabIndex = 4;
            this.lbl_Path.Text = "AtlusScriptCompiler.exe Path:";
            // 
            // txt_Path
            // 
            this.txt_Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Paths.SetColumnSpan(this.txt_Path, 2);
            this.txt_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_Path.Location = new System.Drawing.Point(3, 21);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(388, 22);
            this.txt_Path.TabIndex = 5;
            this.txt_Path.TextChanged += new System.EventHandler(this.Path_Changed);
            // 
            // btn_Path
            // 
            this.btn_Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Path.Location = new System.Drawing.Point(397, 20);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Path.Size = new System.Drawing.Size(32, 23);
            this.btn_Path.TabIndex = 6;
            this.btn_Path.Text = "...";
            this.btn_Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // lbl_OutPath
            // 
            this.lbl_OutPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_OutPath.AutoSize = true;
            this.lbl_OutPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_OutPath.Location = new System.Drawing.Point(3, 55);
            this.lbl_OutPath.Name = "lbl_OutPath";
            this.lbl_OutPath.Size = new System.Drawing.Size(191, 17);
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
            this.txt_OutPath.Location = new System.Drawing.Point(3, 87);
            this.txt_OutPath.Name = "txt_OutPath";
            this.txt_OutPath.Size = new System.Drawing.Size(388, 22);
            this.txt_OutPath.TabIndex = 8;
            this.txt_OutPath.TextChanged += new System.EventHandler(this.Path_Changed);
            // 
            // btn_OutPath
            // 
            this.btn_OutPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OutPath.Location = new System.Drawing.Point(397, 86);
            this.btn_OutPath.Name = "btn_OutPath";
            this.btn_OutPath.Padding = new System.Windows.Forms.Padding(5);
            this.btn_OutPath.Size = new System.Drawing.Size(32, 23);
            this.btn_OutPath.TabIndex = 9;
            this.btn_OutPath.Text = "...";
            this.btn_OutPath.Click += new System.EventHandler(this.OutPath_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.rtb_Log, 0, 3);
            this.tlp_Main.Controls.Add(this.tlp_Paths, 0, 0);
            this.tlp_Main.Controls.Add(this.tlp_Options, 0, 1);
            this.tlp_Main.Controls.Add(this.tlp_Checkboxes, 0, 2);
            this.tlp_Main.Location = new System.Drawing.Point(12, 12);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.Size = new System.Drawing.Size(438, 409);
            this.tlp_Main.TabIndex = 10;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rtb_Log.Location = new System.Drawing.Point(3, 288);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(432, 118);
            this.rtb_Log.TabIndex = 3;
            this.rtb_Log.Text = "";
            // 
            // tlp_Paths
            // 
            this.tlp_Paths.ColumnCount = 3;
            this.tlp_Paths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Paths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Paths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlp_Paths.Controls.Add(this.btn_OutPath, 2, 3);
            this.tlp_Paths.Controls.Add(this.lbl_OutPath, 0, 2);
            this.tlp_Paths.Controls.Add(this.lbl_Path, 0, 0);
            this.tlp_Paths.Controls.Add(this.btn_Path, 2, 1);
            this.tlp_Paths.Controls.Add(this.txt_Path, 0, 1);
            this.tlp_Paths.Controls.Add(this.txt_OutPath, 0, 3);
            this.tlp_Paths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Paths.Location = new System.Drawing.Point(3, 3);
            this.tlp_Paths.Name = "tlp_Paths";
            this.tlp_Paths.RowCount = 4;
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.03226F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.96774F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Paths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Paths.Size = new System.Drawing.Size(432, 119);
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
            this.tlp_Options.Location = new System.Drawing.Point(3, 128);
            this.tlp_Options.Name = "tlp_Options";
            this.tlp_Options.RowCount = 1;
            this.tlp_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Options.Size = new System.Drawing.Size(432, 84);
            this.tlp_Options.TabIndex = 1;
            // 
            // tlp_Checkboxes
            // 
            this.tlp_Checkboxes.ColumnCount = 3;
            this.tlp_Checkboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Checkboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Checkboxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Checkboxes.Controls.Add(this.chk_VerboseLog, 2, 1);
            this.tlp_Checkboxes.Controls.Add(this.txt_Version, 1, 1);
            this.tlp_Checkboxes.Controls.Add(this.chk_RepackPACs, 0, 0);
            this.tlp_Checkboxes.Controls.Add(this.chk_Reindex, 2, 0);
            this.tlp_Checkboxes.Controls.Add(this.chk_Decompile, 1, 0);
            this.tlp_Checkboxes.Controls.Add(this.lbl_Version, 0, 1);
            this.tlp_Checkboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Checkboxes.Location = new System.Drawing.Point(3, 218);
            this.tlp_Checkboxes.Name = "tlp_Checkboxes";
            this.tlp_Checkboxes.RowCount = 2;
            this.tlp_Checkboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Checkboxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Checkboxes.Size = new System.Drawing.Size(432, 64);
            this.tlp_Checkboxes.TabIndex = 4;
            // 
            // chk_VerboseLog
            // 
            this.chk_VerboseLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_VerboseLog.AutoSize = true;
            this.chk_VerboseLog.Checked = true;
            this.chk_VerboseLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_VerboseLog.Location = new System.Drawing.Point(299, 37);
            this.chk_VerboseLog.Name = "chk_VerboseLog";
            this.chk_VerboseLog.Size = new System.Drawing.Size(130, 21);
            this.chk_VerboseLog.TabIndex = 11;
            this.chk_VerboseLog.Text = "Verbose Output";
            // 
            // txt_Version
            // 
            this.txt_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_Version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_Version.Location = new System.Drawing.Point(147, 37);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(138, 22);
            this.txt_Version.TabIndex = 10;
            this.txt_Version.TextChanged += new System.EventHandler(this.VersionString_Changed);
            // 
            // chk_RepackPACs
            // 
            this.chk_RepackPACs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_RepackPACs.AutoSize = true;
            this.chk_RepackPACs.Enabled = false;
            this.chk_RepackPACs.Location = new System.Drawing.Point(3, 5);
            this.chk_RepackPACs.Name = "chk_RepackPACs";
            this.chk_RepackPACs.Size = new System.Drawing.Size(138, 21);
            this.chk_RepackPACs.TabIndex = 2;
            this.chk_RepackPACs.Text = "Pack output .PACs";
            // 
            // chk_Reindex
            // 
            this.chk_Reindex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_Reindex.AutoSize = true;
            this.chk_Reindex.Checked = true;
            this.chk_Reindex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Reindex.Location = new System.Drawing.Point(307, 5);
            this.chk_Reindex.Name = "chk_Reindex";
            this.chk_Reindex.Size = new System.Drawing.Size(122, 21);
            this.chk_Reindex.TabIndex = 0;
            this.chk_Reindex.Text = "Reindex .msgs";
            // 
            // chk_Decompile
            // 
            this.chk_Decompile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chk_Decompile.AutoSize = true;
            this.chk_Decompile.Location = new System.Drawing.Point(147, 5);
            this.chk_Decompile.Name = "chk_Decompile";
            this.chk_Decompile.Size = new System.Drawing.Size(138, 21);
            this.chk_Decompile.TabIndex = 1;
            this.chk_Decompile.Text = "Decompile output";
            // 
            // lbl_Version
            // 
            this.lbl_Version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_Version.Location = new System.Drawing.Point(3, 39);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(138, 17);
            this.lbl_Version.TabIndex = 3;
            this.lbl_Version.Text = "Version string:";
            // 
            // groupBox_Encoding
            // 
            this.groupBox_Encoding.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Encoding.Controls.Add(this.comboBox_Encoding);
            this.groupBox_Encoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Encoding.Location = new System.Drawing.Point(147, 3);
            this.groupBox_Encoding.Name = "groupBox_Encoding";
            this.groupBox_Encoding.Size = new System.Drawing.Size(138, 78);
            this.groupBox_Encoding.TabIndex = 2;
            this.groupBox_Encoding.TabStop = false;
            this.groupBox_Encoding.Text = "Encoding";
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
            this.comboBox_Version.Location = new System.Drawing.Point(3, 33);
            this.comboBox_Version.Name = "comboBox_Version";
            this.comboBox_Version.Size = new System.Drawing.Size(129, 24);
            this.comboBox_Version.TabIndex = 1;
            this.comboBox_Version.SelectedIndexChanged += new System.EventHandler(this.Version_Changed);
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
            this.comboBox_Encoding.Location = new System.Drawing.Point(6, 33);
            this.comboBox_Encoding.Name = "comboBox_Encoding";
            this.comboBox_Encoding.Size = new System.Drawing.Size(129, 24);
            this.comboBox_Encoding.TabIndex = 2;
            this.comboBox_Encoding.SelectedIndexChanged += new System.EventHandler(this.Encoding_Changed);
            // 
            // BuilderForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(462, 433);
            this.Controls.Add(this.tlp_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "BuilderForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Mod Menu Builder v1.0";
            this.groupBox_Version.ResumeLayout(false);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Paths.ResumeLayout(false);
            this.tlp_Paths.PerformLayout();
            this.tlp_Options.ResumeLayout(false);
            this.tlp_Checkboxes.ResumeLayout(false);
            this.tlp_Checkboxes.PerformLayout();
            this.groupBox_Encoding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkButton btn_Build;
        private DarkUI.Controls.DarkGroupBox groupBox_Version;
        private DarkUI.Controls.DarkLabel lbl_Path;
        private System.Windows.Forms.TableLayoutPanel tlp_Paths;
        private DarkUI.Controls.DarkButton btn_OutPath;
        private DarkUI.Controls.DarkLabel lbl_OutPath;
        private DarkUI.Controls.DarkButton btn_Path;
        private DarkUI.Controls.DarkTextBox txt_Path;
        private DarkUI.Controls.DarkTextBox txt_OutPath;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Options;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.TableLayoutPanel tlp_Checkboxes;
        private DarkUI.Controls.DarkCheckBox chk_Reindex;
        private DarkUI.Controls.DarkCheckBox chk_Decompile;
        private DarkUI.Controls.DarkCheckBox chk_RepackPACs;
        private DarkUI.Controls.DarkLabel lbl_Version;
        private DarkUI.Controls.DarkTextBox txt_Version;
        private DarkUI.Controls.DarkCheckBox chk_VerboseLog;
        private DarkUI.Controls.DarkGroupBox groupBox_Encoding;
        private System.Windows.Forms.ComboBox comboBox_Version;
        private System.Windows.Forms.ComboBox comboBox_Encoding;
    }
}
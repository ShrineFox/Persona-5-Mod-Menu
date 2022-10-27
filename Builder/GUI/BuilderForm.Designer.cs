
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
            this.radio_Royal = new DarkUI.Controls.DarkRadioButton();
            this.radio_Vanilla = new DarkUI.Controls.DarkRadioButton();
            this.groupBox_Version = new DarkUI.Controls.DarkGroupBox();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.radio_New = new DarkUI.Controls.DarkRadioButton();
            this.radio_Old = new DarkUI.Controls.DarkRadioButton();
            this.groupBox_Platform = new DarkUI.Controls.DarkGroupBox();
            this.lbl_Path = new DarkUI.Controls.DarkLabel();
            this.txt_Path = new DarkUI.Controls.DarkTextBox();
            this.btn_Path = new DarkUI.Controls.DarkButton();
            this.radio_Xbox = new DarkUI.Controls.DarkRadioButton();
            this.radio_Nintendo = new DarkUI.Controls.DarkRadioButton();
            this.radio_Playstation = new DarkUI.Controls.DarkRadioButton();
            this.groupBox_Joypad = new DarkUI.Controls.DarkGroupBox();
            this.lbl_OutPath = new DarkUI.Controls.DarkLabel();
            this.txt_OutPath = new DarkUI.Controls.DarkTextBox();
            this.btn_OutPath = new DarkUI.Controls.DarkButton();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Paths = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Options = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_Version.SuspendLayout();
            this.groupBox_Platform.SuspendLayout();
            this.groupBox_Joypad.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.tlp_Paths.SuspendLayout();
            this.tlp_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Build
            // 
            this.btn_Build.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Build.Enabled = false;
            this.btn_Build.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_Build.Location = new System.Drawing.Point(327, 3);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Build.Size = new System.Drawing.Size(102, 88);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "Build";
            this.btn_Build.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // radio_Royal
            // 
            this.radio_Royal.AutoSize = true;
            this.radio_Royal.Checked = true;
            this.radio_Royal.Location = new System.Drawing.Point(7, 22);
            this.radio_Royal.Name = "radio_Royal";
            this.radio_Royal.Size = new System.Drawing.Size(65, 21);
            this.radio_Royal.TabIndex = 0;
            this.radio_Royal.TabStop = true;
            this.radio_Royal.Text = "Royal";
            this.radio_Royal.CheckedChanged += new System.EventHandler(this.Version_Changed);
            // 
            // radio_Vanilla
            // 
            this.radio_Vanilla.AutoSize = true;
            this.radio_Vanilla.Location = new System.Drawing.Point(7, 49);
            this.radio_Vanilla.Name = "radio_Vanilla";
            this.radio_Vanilla.Size = new System.Drawing.Size(71, 21);
            this.radio_Vanilla.TabIndex = 1;
            this.radio_Vanilla.Text = "Vanilla";
            // 
            // groupBox_Version
            // 
            this.groupBox_Version.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Version.Controls.Add(this.radio_Vanilla);
            this.groupBox_Version.Controls.Add(this.radio_Royal);
            this.groupBox_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Version.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Version.Name = "groupBox_Version";
            this.groupBox_Version.Size = new System.Drawing.Size(102, 88);
            this.groupBox_Version.TabIndex = 1;
            this.groupBox_Version.TabStop = false;
            this.groupBox_Version.Text = "Version";
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rtb_Log.Location = new System.Drawing.Point(3, 228);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(432, 178);
            this.rtb_Log.TabIndex = 2;
            this.rtb_Log.Text = "";
            // 
            // radio_New
            // 
            this.radio_New.AutoSize = true;
            this.radio_New.Checked = true;
            this.radio_New.Location = new System.Drawing.Point(7, 22);
            this.radio_New.Name = "radio_New";
            this.radio_New.Size = new System.Drawing.Size(56, 21);
            this.radio_New.TabIndex = 0;
            this.radio_New.TabStop = true;
            this.radio_New.Text = "New";
            // 
            // radio_Old
            // 
            this.radio_Old.AutoSize = true;
            this.radio_Old.Location = new System.Drawing.Point(7, 49);
            this.radio_Old.Name = "radio_Old";
            this.radio_Old.Size = new System.Drawing.Size(51, 21);
            this.radio_Old.TabIndex = 1;
            this.radio_Old.Text = "Old";
            // 
            // groupBox_Platform
            // 
            this.groupBox_Platform.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Platform.Controls.Add(this.radio_Old);
            this.groupBox_Platform.Controls.Add(this.radio_New);
            this.groupBox_Platform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Platform.Location = new System.Drawing.Point(111, 3);
            this.groupBox_Platform.Name = "groupBox_Platform";
            this.groupBox_Platform.Size = new System.Drawing.Size(102, 88);
            this.groupBox_Platform.TabIndex = 2;
            this.groupBox_Platform.TabStop = false;
            this.groupBox_Platform.Text = "Platform";
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
            // radio_Xbox
            // 
            this.radio_Xbox.AutoSize = true;
            this.radio_Xbox.Checked = true;
            this.radio_Xbox.Location = new System.Drawing.Point(7, 22);
            this.radio_Xbox.Name = "radio_Xbox";
            this.radio_Xbox.Size = new System.Drawing.Size(60, 21);
            this.radio_Xbox.TabIndex = 0;
            this.radio_Xbox.TabStop = true;
            this.radio_Xbox.Text = "Xbox";
            // 
            // radio_Nintendo
            // 
            this.radio_Nintendo.AutoSize = true;
            this.radio_Nintendo.Location = new System.Drawing.Point(7, 43);
            this.radio_Nintendo.Name = "radio_Nintendo";
            this.radio_Nintendo.Size = new System.Drawing.Size(86, 21);
            this.radio_Nintendo.TabIndex = 1;
            this.radio_Nintendo.Text = "Nintendo";
            // 
            // radio_Playstation
            // 
            this.radio_Playstation.AutoSize = true;
            this.radio_Playstation.Location = new System.Drawing.Point(7, 65);
            this.radio_Playstation.Name = "radio_Playstation";
            this.radio_Playstation.Size = new System.Drawing.Size(100, 21);
            this.radio_Playstation.TabIndex = 2;
            this.radio_Playstation.Text = "PlayStation";
            // 
            // groupBox_Joypad
            // 
            this.groupBox_Joypad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox_Joypad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Joypad.Controls.Add(this.radio_Playstation);
            this.groupBox_Joypad.Controls.Add(this.radio_Nintendo);
            this.groupBox_Joypad.Controls.Add(this.radio_Xbox);
            this.groupBox_Joypad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Joypad.Location = new System.Drawing.Point(219, 3);
            this.groupBox_Joypad.Name = "groupBox_Joypad";
            this.groupBox_Joypad.Size = new System.Drawing.Size(102, 88);
            this.groupBox_Joypad.TabIndex = 4;
            this.groupBox_Joypad.TabStop = false;
            this.groupBox_Joypad.Text = "Joypad";
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
            this.tlp_Main.Controls.Add(this.tlp_Paths, 0, 0);
            this.tlp_Main.Controls.Add(this.tlp_Options, 0, 1);
            this.tlp_Main.Controls.Add(this.rtb_Log, 0, 2);
            this.tlp_Main.Location = new System.Drawing.Point(12, 12);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.Size = new System.Drawing.Size(438, 409);
            this.tlp_Main.TabIndex = 10;
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
            this.tlp_Paths.Size = new System.Drawing.Size(432, 119);
            this.tlp_Paths.TabIndex = 0;
            // 
            // tlp_Options
            // 
            this.tlp_Options.ColumnCount = 4;
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Options.Controls.Add(this.btn_Build, 3, 0);
            this.tlp_Options.Controls.Add(this.groupBox_Version, 0, 0);
            this.tlp_Options.Controls.Add(this.groupBox_Platform, 1, 0);
            this.tlp_Options.Controls.Add(this.groupBox_Joypad, 2, 0);
            this.tlp_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Options.Location = new System.Drawing.Point(3, 128);
            this.tlp_Options.Name = "tlp_Options";
            this.tlp_Options.RowCount = 1;
            this.tlp_Options.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Options.Size = new System.Drawing.Size(432, 94);
            this.tlp_Options.TabIndex = 1;
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
            this.groupBox_Version.PerformLayout();
            this.groupBox_Platform.ResumeLayout(false);
            this.groupBox_Platform.PerformLayout();
            this.groupBox_Joypad.ResumeLayout(false);
            this.groupBox_Joypad.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Paths.ResumeLayout(false);
            this.tlp_Paths.PerformLayout();
            this.tlp_Options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkButton btn_Build;
        private DarkUI.Controls.DarkRadioButton radio_Royal;
        private DarkUI.Controls.DarkRadioButton radio_Vanilla;
        private DarkUI.Controls.DarkGroupBox groupBox_Version;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private DarkUI.Controls.DarkRadioButton radio_New;
        private DarkUI.Controls.DarkRadioButton radio_Old;
        private DarkUI.Controls.DarkGroupBox groupBox_Platform;
        private DarkUI.Controls.DarkLabel lbl_Path;
        private System.Windows.Forms.TableLayoutPanel tlp_Paths;
        private DarkUI.Controls.DarkButton btn_OutPath;
        private DarkUI.Controls.DarkLabel lbl_OutPath;
        private DarkUI.Controls.DarkButton btn_Path;
        private DarkUI.Controls.DarkTextBox txt_Path;
        private DarkUI.Controls.DarkTextBox txt_OutPath;
        private DarkUI.Controls.DarkRadioButton radio_Xbox;
        private DarkUI.Controls.DarkRadioButton radio_Nintendo;
        private DarkUI.Controls.DarkRadioButton radio_Playstation;
        private DarkUI.Controls.DarkGroupBox groupBox_Joypad;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Options;
    }
}
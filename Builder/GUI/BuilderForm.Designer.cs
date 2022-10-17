
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
            this.btn_Build = new DarkUI.Controls.DarkButton();
            this.groupBox_Version = new DarkUI.Controls.DarkGroupBox();
            this.radio_Vanilla = new DarkUI.Controls.DarkRadioButton();
            this.radio_Royal = new DarkUI.Controls.DarkRadioButton();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.groupBox_Platform = new DarkUI.Controls.DarkGroupBox();
            this.radio_Old = new DarkUI.Controls.DarkRadioButton();
            this.radio_New = new DarkUI.Controls.DarkRadioButton();
            this.groupBox_PACs = new DarkUI.Controls.DarkGroupBox();
            this.radio_Pack = new DarkUI.Controls.DarkRadioButton();
            this.radio_Unpack = new DarkUI.Controls.DarkRadioButton();
            this.lbl_Path = new DarkUI.Controls.DarkLabel();
            this.txt_Path = new DarkUI.Controls.DarkTextBox();
            this.btn_Path = new DarkUI.Controls.DarkButton();
            this.groupBox_Version.SuspendLayout();
            this.groupBox_Platform.SuspendLayout();
            this.groupBox_PACs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Build
            // 
            this.btn_Build.Enabled = false;
            this.btn_Build.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_Build.Location = new System.Drawing.Point(335, 67);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Build.Size = new System.Drawing.Size(110, 90);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "Build";
            this.btn_Build.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // groupBox_Version
            // 
            this.groupBox_Version.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Version.Controls.Add(this.radio_Vanilla);
            this.groupBox_Version.Controls.Add(this.radio_Royal);
            this.groupBox_Version.Location = new System.Drawing.Point(12, 59);
            this.groupBox_Version.Name = "groupBox_Version";
            this.groupBox_Version.Size = new System.Drawing.Size(95, 97);
            this.groupBox_Version.TabIndex = 1;
            this.groupBox_Version.TabStop = false;
            this.groupBox_Version.Text = "Version";
            // 
            // radio_Vanilla
            // 
            this.radio_Vanilla.AutoSize = true;
            this.radio_Vanilla.Location = new System.Drawing.Point(7, 49);
            this.radio_Vanilla.Name = "radio_Vanilla";
            this.radio_Vanilla.Size = new System.Drawing.Size(71, 21);
            this.radio_Vanilla.TabIndex = 1;
            this.radio_Vanilla.Text = "Vanilla";
            this.radio_Vanilla.CheckedChanged += new System.EventHandler(this.Version_Changed);
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
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rtb_Log.Location = new System.Drawing.Point(13, 163);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(432, 256);
            this.rtb_Log.TabIndex = 2;
            this.rtb_Log.Text = "";
            // 
            // groupBox_Platform
            // 
            this.groupBox_Platform.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Platform.Controls.Add(this.radio_Old);
            this.groupBox_Platform.Controls.Add(this.radio_New);
            this.groupBox_Platform.Location = new System.Drawing.Point(113, 60);
            this.groupBox_Platform.Name = "groupBox_Platform";
            this.groupBox_Platform.Size = new System.Drawing.Size(106, 97);
            this.groupBox_Platform.TabIndex = 2;
            this.groupBox_Platform.TabStop = false;
            this.groupBox_Platform.Text = "Platform";
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
            // groupBox_PACs
            // 
            this.groupBox_PACs.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox_PACs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_PACs.Controls.Add(this.radio_Pack);
            this.groupBox_PACs.Controls.Add(this.radio_Unpack);
            this.groupBox_PACs.Enabled = false;
            this.groupBox_PACs.Location = new System.Drawing.Point(225, 61);
            this.groupBox_PACs.Name = "groupBox_PACs";
            this.groupBox_PACs.Size = new System.Drawing.Size(104, 96);
            this.groupBox_PACs.TabIndex = 3;
            this.groupBox_PACs.TabStop = false;
            this.groupBox_PACs.Text = "PACs";
            // 
            // radio_Pack
            // 
            this.radio_Pack.AutoSize = true;
            this.radio_Pack.Location = new System.Drawing.Point(7, 49);
            this.radio_Pack.Name = "radio_Pack";
            this.radio_Pack.Size = new System.Drawing.Size(60, 21);
            this.radio_Pack.TabIndex = 1;
            this.radio_Pack.Text = "Pack";
            // 
            // radio_Unpack
            // 
            this.radio_Unpack.AutoSize = true;
            this.radio_Unpack.Checked = true;
            this.radio_Unpack.Location = new System.Drawing.Point(7, 22);
            this.radio_Unpack.Name = "radio_Unpack";
            this.radio_Unpack.Size = new System.Drawing.Size(77, 21);
            this.radio_Unpack.TabIndex = 0;
            this.radio_Unpack.TabStop = true;
            this.radio_Unpack.Text = "Unpack";
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_Path.Location = new System.Drawing.Point(12, 13);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(193, 17);
            this.lbl_Path.TabIndex = 4;
            this.lbl_Path.Text = "AtlusScriptCompiler.exe Path:";
            // 
            // txt_Path
            // 
            this.txt_Path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_Path.Location = new System.Drawing.Point(12, 33);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(393, 22);
            this.txt_Path.TabIndex = 5;
            this.txt_Path.TextChanged += new System.EventHandler(this.Path_Changed);
            // 
            // btn_Path
            // 
            this.btn_Path.Location = new System.Drawing.Point(411, 33);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Path.Size = new System.Drawing.Size(33, 23);
            this.btn_Path.TabIndex = 6;
            this.btn_Path.Text = "...";
            this.btn_Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // BuilderForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(457, 431);
            this.Controls.Add(this.btn_Path);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.groupBox_PACs);
            this.Controls.Add(this.groupBox_Platform);
            this.Controls.Add(this.rtb_Log);
            this.Controls.Add(this.groupBox_Version);
            this.Controls.Add(this.btn_Build);
            this.Name = "BuilderForm";
            this.Text = "Mod Menu Builder";
            this.groupBox_Version.ResumeLayout(false);
            this.groupBox_Version.PerformLayout();
            this.groupBox_Platform.ResumeLayout(false);
            this.groupBox_Platform.PerformLayout();
            this.groupBox_PACs.ResumeLayout(false);
            this.groupBox_PACs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton btn_Build;
        private DarkUI.Controls.DarkGroupBox groupBox_Version;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private DarkUI.Controls.DarkRadioButton radio_Royal;
        private DarkUI.Controls.DarkRadioButton radio_Vanilla;
        private DarkUI.Controls.DarkGroupBox groupBox_Platform;
        private DarkUI.Controls.DarkRadioButton radio_Old;
        private DarkUI.Controls.DarkRadioButton radio_New;
        private DarkUI.Controls.DarkGroupBox groupBox_PACs;
        private DarkUI.Controls.DarkRadioButton radio_Pack;
        private DarkUI.Controls.DarkRadioButton radio_Unpack;
        private DarkUI.Controls.DarkLabel lbl_Path;
        private DarkUI.Controls.DarkTextBox txt_Path;
        private DarkUI.Controls.DarkButton btn_Path;
    }
}
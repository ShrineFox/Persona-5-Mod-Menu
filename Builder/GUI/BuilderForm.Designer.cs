
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
            this.lbl_Path = new DarkUI.Controls.DarkLabel();
            this.txt_Path = new DarkUI.Controls.DarkTextBox();
            this.btn_Path = new DarkUI.Controls.DarkButton();
            this.groupBox_Joypad = new DarkUI.Controls.DarkGroupBox();
            this.radio_Playstation = new DarkUI.Controls.DarkRadioButton();
            this.radio_Nintendo = new DarkUI.Controls.DarkRadioButton();
            this.radio_Xbox = new DarkUI.Controls.DarkRadioButton();
            this.btn_OutPath = new DarkUI.Controls.DarkButton();
            this.txt_OutPath = new DarkUI.Controls.DarkTextBox();
            this.lbl_OutPath = new DarkUI.Controls.DarkLabel();
            this.groupBox_Version.SuspendLayout();
            this.groupBox_Platform.SuspendLayout();
            this.groupBox_Joypad.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Build
            // 
            this.btn_Build.Enabled = false;
            this.btn_Build.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_Build.Location = new System.Drawing.Point(327, 121);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Build.Size = new System.Drawing.Size(123, 88);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "Build";
            this.btn_Build.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // groupBox_Version
            // 
            this.groupBox_Version.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Version.Controls.Add(this.radio_Vanilla);
            this.groupBox_Version.Controls.Add(this.radio_Royal);
            this.groupBox_Version.Location = new System.Drawing.Point(12, 111);
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
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rtb_Log.Location = new System.Drawing.Point(13, 214);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(437, 205);
            this.rtb_Log.TabIndex = 2;
            this.rtb_Log.Text = "";
            // 
            // groupBox_Platform
            // 
            this.groupBox_Platform.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Platform.Controls.Add(this.radio_Old);
            this.groupBox_Platform.Controls.Add(this.radio_New);
            this.groupBox_Platform.Location = new System.Drawing.Point(113, 112);
            this.groupBox_Platform.Name = "groupBox_Platform";
            this.groupBox_Platform.Size = new System.Drawing.Size(92, 97);
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
            this.btn_Path.Size = new System.Drawing.Size(38, 23);
            this.btn_Path.TabIndex = 6;
            this.btn_Path.Text = "...";
            this.btn_Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // groupBox_Joypad
            // 
            this.groupBox_Joypad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox_Joypad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.groupBox_Joypad.Controls.Add(this.radio_Playstation);
            this.groupBox_Joypad.Controls.Add(this.radio_Nintendo);
            this.groupBox_Joypad.Controls.Add(this.radio_Xbox);
            this.groupBox_Joypad.Location = new System.Drawing.Point(211, 113);
            this.groupBox_Joypad.Name = "groupBox_Joypad";
            this.groupBox_Joypad.Size = new System.Drawing.Size(110, 96);
            this.groupBox_Joypad.TabIndex = 4;
            this.groupBox_Joypad.TabStop = false;
            this.groupBox_Joypad.Text = "Joypad";
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
            // radio_Nintendo
            // 
            this.radio_Nintendo.AutoSize = true;
            this.radio_Nintendo.Location = new System.Drawing.Point(7, 43);
            this.radio_Nintendo.Name = "radio_Nintendo";
            this.radio_Nintendo.Size = new System.Drawing.Size(86, 21);
            this.radio_Nintendo.TabIndex = 1;
            this.radio_Nintendo.Text = "Nintendo";
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
            // btn_OutPath
            // 
            this.btn_OutPath.Location = new System.Drawing.Point(412, 83);
            this.btn_OutPath.Name = "btn_OutPath";
            this.btn_OutPath.Padding = new System.Windows.Forms.Padding(5);
            this.btn_OutPath.Size = new System.Drawing.Size(38, 23);
            this.btn_OutPath.TabIndex = 9;
            this.btn_OutPath.Text = "...";
            this.btn_OutPath.Click += new System.EventHandler(this.OutPath_Click);
            // 
            // txt_OutPath
            // 
            this.txt_OutPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txt_OutPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_OutPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_OutPath.Location = new System.Drawing.Point(13, 83);
            this.txt_OutPath.Name = "txt_OutPath";
            this.txt_OutPath.Size = new System.Drawing.Size(393, 22);
            this.txt_OutPath.TabIndex = 8;
            this.txt_OutPath.TextChanged += new System.EventHandler(this.Path_Changed);
            // 
            // lbl_OutPath
            // 
            this.lbl_OutPath.AutoSize = true;
            this.lbl_OutPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lbl_OutPath.Location = new System.Drawing.Point(13, 63);
            this.lbl_OutPath.Name = "lbl_OutPath";
            this.lbl_OutPath.Size = new System.Drawing.Size(88, 17);
            this.lbl_OutPath.TabIndex = 7;
            this.lbl_OutPath.Text = "Output Path:";
            // 
            // BuilderForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(462, 433);
            this.Controls.Add(this.btn_OutPath);
            this.Controls.Add(this.txt_OutPath);
            this.Controls.Add(this.lbl_OutPath);
            this.Controls.Add(this.groupBox_Joypad);
            this.Controls.Add(this.btn_Path);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.groupBox_Platform);
            this.Controls.Add(this.rtb_Log);
            this.Controls.Add(this.groupBox_Version);
            this.Controls.Add(this.btn_Build);
            this.MaximumSize = new System.Drawing.Size(480, 480);
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "BuilderForm";
            this.Text = "Mod Menu Builder";
            this.groupBox_Version.ResumeLayout(false);
            this.groupBox_Version.PerformLayout();
            this.groupBox_Platform.ResumeLayout(false);
            this.groupBox_Platform.PerformLayout();
            this.groupBox_Joypad.ResumeLayout(false);
            this.groupBox_Joypad.PerformLayout();
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
        private DarkUI.Controls.DarkLabel lbl_Path;
        private DarkUI.Controls.DarkTextBox txt_Path;
        private DarkUI.Controls.DarkButton btn_Path;
        private DarkUI.Controls.DarkGroupBox groupBox_Joypad;
        private DarkUI.Controls.DarkRadioButton radio_Nintendo;
        private DarkUI.Controls.DarkRadioButton radio_Xbox;
        private DarkUI.Controls.DarkRadioButton radio_Playstation;
        private DarkUI.Controls.DarkButton btn_OutPath;
        private DarkUI.Controls.DarkTextBox txt_OutPath;
        private DarkUI.Controls.DarkLabel lbl_OutPath;
    }
}
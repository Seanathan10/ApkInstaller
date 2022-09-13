
namespace ApkInstaller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.APKLabel = new System.Windows.Forms.Label();
            this.APK_Path = new System.Windows.Forms.TextBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.SetupButton = new System.Windows.Forms.Button();
            this.MainHelpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // APKLabel
            // 
            this.APKLabel.AutoSize = true;
            this.APKLabel.Location = new System.Drawing.Point(12, 9);
            this.APKLabel.Name = "APKLabel";
            this.APKLabel.Size = new System.Drawing.Size(32, 15);
            this.APKLabel.TabIndex = 0;
            this.APKLabel.Text = "APK:";
            // 
            // APK_Path
            // 
            this.APK_Path.Location = new System.Drawing.Point(50, 6);
            this.APK_Path.Name = "APK_Path";
            this.APK_Path.ReadOnly = true;
            this.APK_Path.Size = new System.Drawing.Size(277, 23);
            this.APK_Path.TabIndex = 1;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(333, 6);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(110, 22);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Select APK...";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // InstallButton
            // 
            this.InstallButton.Location = new System.Drawing.Point(449, 6);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(75, 23);
            this.InstallButton.TabIndex = 3;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(530, 6);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 4;
            this.TestButton.Text = "Test ADB";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // SetupButton
            // 
            this.SetupButton.Location = new System.Drawing.Point(611, 5);
            this.SetupButton.Name = "SetupButton";
            this.SetupButton.Size = new System.Drawing.Size(75, 23);
            this.SetupButton.TabIndex = 5;
            this.SetupButton.Text = "Setup";
            this.SetupButton.UseVisualStyleBackColor = true;
            this.SetupButton.Click += new System.EventHandler(this.SetupButton_Click);
            // 
            // MainHelpButton
            // 
            this.MainHelpButton.Location = new System.Drawing.Point(692, 5);
            this.MainHelpButton.Name = "MainHelpButton";
            this.MainHelpButton.Size = new System.Drawing.Size(75, 23);
            this.MainHelpButton.TabIndex = 6;
            this.MainHelpButton.Text = "Help";
            this.MainHelpButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 38);
            this.Controls.Add(this.MainHelpButton);
            this.Controls.Add(this.SetupButton);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.APK_Path);
            this.Controls.Add(this.APKLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APK Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label APKLabel;
        private System.Windows.Forms.TextBox APK_Path;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button SetupButton;
        private System.Windows.Forms.Button MainHelpButton;
    }
}


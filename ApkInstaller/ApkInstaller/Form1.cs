using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkInstaller {

    public partial class Form1 : Form {
        string File = string.Empty;
        string SubsystemAddress = string.Empty;
        bool IsTested = false;
        bool IsSetup = false;
        bool IsApkSelected = false;

        public Form1() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;   

        }
        void ChangeName( string NewName ) {
            this.Text = NewName;
        }

        private void SelectButton_Click( object sender, EventArgs e ) {
            using ( OpenFileDialog ApkSelector = new System.Windows.Forms.OpenFileDialog() ) {
                ApkSelector.InitialDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.UserProfile );
                ApkSelector.Filter = "APK Files (*.apk)|*.apk|All Files (*.*)|*.*";

                if( ApkSelector.ShowDialog() == DialogResult.OK ) {
                    APK_Path.Text = ApkSelector.SafeFileName;
                    File = ApkSelector.FileName;
                    IsApkSelected = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            /*
            if(
                MessageBox.Show(
                    "Please note: usage of this tool requires the Windows Subsystem for Android to be installed and for the Android SDK Platform Tools to be in the system path variable. You can test if the tools work with the Test ADB button. Would you like instructions for this?",
                    "APK Installer",
                    MessageBoxButtons.YesNo
                ) == DialogResult.Yes
            ) {
                MessageBox.Show("yes");
            }
            */
        }

        private void TestButton_Click( object sender, EventArgs e ) {
            System.Diagnostics.Process TestADB = new System.Diagnostics.Process();

            TestADB.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            TestADB.StartInfo.FileName = "cmd.exe";
            TestADB.StartInfo.Arguments = "/c adb";
            TestADB.StartInfo.UseShellExecute = false;
            TestADB.StartInfo.RedirectStandardOutput = true;

            TestADB.Start();
            string ADBOutput = TestADB.StandardOutput.ReadToEnd();
            TestADB.WaitForExit();

            //MessageBox.Show( ADBOutput );

            if( ADBOutput.Contains( "Android Debug Bridge version" ) || ADBOutput.Contains( "global options:" ) ) {
                MessageBox.Show( "Android SDK Tools are installed. The tool will work as expected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
                IsTested = true;
            } else
            {
                IsTested = false;
                MessageBox.Show( "Android SDK Tools are not installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        public void SetupForm() {
            System.Windows.Forms.Form Setup = new System.Windows.Forms.Form();

            Setup.MinimizeBox = false;
            Setup.MaximizeBox = false;
            Setup.FormBorderStyle = FormBorderStyle.FixedDialog;
            Setup.Size = new Size( 300, 100 );
            Setup.StartPosition = FormStartPosition.CenterScreen;
            Setup.Text = "Setup";

            WebBrowser WB1 = new WebBrowser();

            string HelpHTML =
@"
<html>
<style>
body {
    background: white;
    font-family: 'Verdana';
}
</style>

<body>
<h1>Setup Help Page</h1>

<p>
Setup will connect the ADB (Android Debug Bridge) to the Android Subsystem. Without this connection, apps cannot be installed.
</p>

<p>
Before beginning this guide, ensure that the Windows Subsystem for Android is installed. You can verify if it is installed by searching for its settings in Start.
</p>

</body>

</html>
";

            WB1.DocumentText = HelpHTML;
            WB1.Size = new Size( 600, 600 );
            WB1.Location = new Point( 0, 0 );

            Label InfoLabel = new Label();
            InfoLabel.Text = "Subsystem Developer IP:";
            InfoLabel.Location = new Point( 10, 10 );
            InfoLabel.Size = new Size( 140, 15 );

            TextBox SubsystemIP = new TextBox();
            SubsystemIP.Size = new Size( 125, 23 );
            SubsystemIP.Location = new Point( InfoLabel.Right + 5, 5 );
            
            Button FinishButton = new Button();
            FinishButton.Text = "Finish";
            FinishButton.Location = new Point( Setup.Right - 100, Setup.Bottom - 70 );
            
            Button HelpButton = new Button();
            HelpButton.Text = "Help";
            HelpButton.Location = new Point( FinishButton.Left - 80, Setup.Bottom - 70 );



            Setup.Controls.Add( InfoLabel );
            Setup.Controls.Add( SubsystemIP );
            Setup.Controls.Add( FinishButton );
            Setup.Controls.Add( HelpButton );

            
            void Help( object Sender, EventArgs E ) {
                Form HelpBox = new Form();

                HelpBox.Size = new Size( 600, 600 );
                HelpBox.MinimizeBox = false;
                HelpBox.MaximizeBox = false;
                HelpBox.FormBorderStyle = FormBorderStyle.FixedDialog;
                HelpBox.Text = "Help";
                
                HelpBox.Controls.Add( WB1 );
                
                HelpBox.ShowDialog();
            }

            void Finish( object Sender, EventArgs E ) {
                SubsystemAddress = SubsystemIP.Text;
                
                if( IsTested && SubsystemAddress != "" ) {
                    ChangeName( "APK Installer - " + SubsystemAddress );
                    IsSetup = true;
                } else if( SubsystemAddress == "" && IsTested ) {
                    MessageBox.Show( "You must provide an IP address to connect to the Subsystem. See Help for more info and instructions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                } else if( !IsTested ) {
                    MessageBox.Show( "You must test the adb tools before attempting to connect to a Subsystem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }

                Setup.Dispose();
            }

            HelpButton.Click += Help;
            FinishButton.Click += Finish;

            Setup.ShowDialog();
        }

        private void SetupButton_Click( object sender, EventArgs e ) {
            SetupForm();
        }

        private void InstallButton_Click( object sender, EventArgs e ) {
            if( IsSetup && IsApkSelected ) {
                MessageBox.Show( "Install" );
            } else if( !IsSetup ) {
                MessageBox.Show( "You must complete setup before installing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if( !IsApkSelected ) {
                MessageBox.Show( "No APK selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

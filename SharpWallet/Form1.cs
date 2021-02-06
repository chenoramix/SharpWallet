using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SharpWallet
{
    public partial class MainFrm : Form
    {
        CreateLoadConfig configFile;
        public MainFrm()
        {
            InitializeComponent();
            configFile = new CreateLoadConfig();

            string configFilename = "sharpwallet.xml";

            if(!File.Exists(configFilename))
            {
                configFile.setWindowSize(this.Width, this.Height);
                
                int windowPositionX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
                int windowPositionY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

                configFile.setWindowPosition(windowPositionX, windowPositionY);
                configFile.CreateConfigFile();
            }

            configFile.LoadConfig();
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            configFile.setWindowSize(this.Width, this.Height);
            configFile.setWindowPosition(this.Left, this.Top);
            configFile.CreateConfigFile();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(configFile.windowPositionX, configFile.windowPositionY);
            this.Width = configFile.windowWidth;
            this.Height = configFile.windowHeight;
        }
    }
}

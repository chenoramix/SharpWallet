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
        private string configFilename;
        private int windowWidth, windowHeight;
        private int windowPositionX, windowPositionY;

        public MainFrm()
        {
            InitializeComponent();

            configFilename = "sharpwallet.xml";

            if(!File.Exists(configFilename))
            {
                this.windowHeight = this.Height;
                this.windowWidth = this.Width;
                
                windowPositionX = Screen.PrimaryScreen.Bounds.Width / 2 - this.windowWidth / 2;
                windowPositionY = Screen.PrimaryScreen.Bounds.Height / 2 - this.windowHeight / 2;
                createConfigFile();
            }
        }

        // create the xml file
        private void createConfigFile()
        {
            using(XmlWriter writer = XmlWriter.Create(configFilename))
            {
                writer.WriteStartElement("database");
                writer.WriteElementString("windowHeight", Convert.ToString(windowHeight));
                writer.WriteElementString("windowWidth", Convert.ToString(windowWidth));
                writer.WriteElementString("windowPositionX", Convert.ToString(windowPositionX));
                writer.WriteElementString("windowPositionY", Convert.ToString(windowPositionY));
                writer.WriteEndElement();

                writer.Flush();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(windowPositionX, windowPositionY);
        }
    }
}

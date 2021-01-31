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
        private string databaseFileName;

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

                databaseFileName = Directory.GetCurrentDirectory() + "\\sharpwallet.json";
                CreateConfigFile();
            }

            LoadConfig();
        }

        // try to load xml
        private void LoadConfig()
        {
            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(configFilename);
                string element;
                bool windowHeight = false;
                bool windowWidth = false;
                bool windowPositionX = false;
                bool windowPositionY = false;
                bool databaseFileName = false;


                while (reader.Read())
                {
                    switch(reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            element = reader.Name;
                            if (element == "windowHeight")
                            {
                                windowHeight = true;
                            }
                            else if(element == "windowWidth")
                            {
                                windowWidth = true;
                            }
                            else if(element == "windowPositionX")
                            {
                                windowPositionX = true;
                            }
                            else if(element == "windowPositionY")
                            {
                                windowPositionY = true;
                            }
                            else if(element == "databaseFileName")
                            {
                                databaseFileName = true;
                            }
                            break;

                        case XmlNodeType.Text:
                            if (windowHeight)
                            {
                                windowHeight = false;
                                this.windowHeight = Convert.ToInt32(reader.Value);
                            }
                            else if (windowWidth)
                            {
                                windowWidth = false;
                                this.windowWidth = Convert.ToInt32(reader.Value);
                            }
                            else if (windowPositionX)
                            {
                                windowPositionX = false;
                                this.windowPositionX = Convert.ToInt32(reader.Value);
                            }
                            else if (windowPositionY)
                            {
                                windowPositionY = false;
                                this.windowPositionY = Convert.ToInt32(reader.Value);
                            }
                            else if (databaseFileName)
                            {
                                databaseFileName = false;
                                this.databaseFileName = reader.Value;
                            }
                            break;
                    }
                }

            } 
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }

        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.windowHeight = this.Height;
            this.windowWidth = this.Width;
            this.windowPositionX = this.Left;
            this.windowPositionY = this.Top;

            CreateConfigFile();
        }

        // create the xml file
        private void CreateConfigFile()
        {
            using(XmlWriter writer = XmlWriter.Create(configFilename))
            {
                writer.WriteStartElement("database");
                writer.WriteElementString("windowHeight", Convert.ToString(windowHeight));
                writer.WriteElementString("windowWidth", Convert.ToString(windowWidth));
                writer.WriteElementString("windowPositionX", Convert.ToString(windowPositionX));
                writer.WriteElementString("windowPositionY", Convert.ToString(windowPositionY));
                writer.WriteElementString("databaseFileName", databaseFileName);
                writer.WriteEndElement();

                writer.Flush();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(windowPositionX, windowPositionY);
            this.Width = windowWidth;
            this.Height = windowHeight;

        }
    }
}

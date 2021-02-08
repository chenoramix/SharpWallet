using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SharpWallet
{
    class CreateLoadConfig
    {
        public string configFilename { get; set; }
        public int windowWidth { get; set; }
        public int windowHeight { get; set; }
        public int windowPositionX { get; set; }
        public int windowPositionY { get; set; }
        public string databaseFileName { get; set; }

        public CreateLoadConfig()
        {
            configFilename = "sharpwallet.xml";
        }

        public void setWindowSize(int width, int height)
        {
            this.windowWidth = width;
            this.windowHeight = height;
        }

        public void setWindowPosition(int x, int y)
        {
            this.windowPositionX = x;
            this.windowPositionY = y;
        }

        // create the xml file
        public void CreateConfigFile()
        {
            using (XmlWriter writer = XmlWriter.Create(configFilename))
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
        // try to load xml
        public void LoadConfig()
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
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            element = reader.Name;
                            if (element == "windowHeight")
                            {
                                windowHeight = true;
                            }
                            else if (element == "windowWidth")
                            {
                                windowWidth = true;
                            }
                            else if (element == "windowPositionX")
                            {
                                windowPositionX = true;
                            }
                            else if (element == "windowPositionY")
                            {
                                windowPositionY = true;
                            }
                            else if (element == "databaseFileName")
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
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}

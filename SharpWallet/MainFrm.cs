using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SharpWallet
{
    public partial class MainFrm : Form
    {
        CreateLoadConfig configFile;
        Database database;
        public static string databaseFileName, password;

        public MainFrm()
        {
            InitializeComponent();
            configFile = new CreateLoadConfig();

            if(!File.Exists(configFile.configFilename))
            {
                configFile.setWindowSize(this.Width, this.Height);
                
                int windowPositionX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
                int windowPositionY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

                configFile.setWindowPosition(windowPositionX, windowPositionY);

                databaseFileName = Directory.GetCurrentDirectory() + "\\sharpwallet.db";

                CreateDBFile();
                
                configFile.databaseFileName = databaseFileName;
                configFile.CreateConfigFile();
            }

            configFile.LoadConfig();

            //check for missing db stuff,msg box about it

            database = new Database();
            
            string jsonText = File.ReadAllText(configFile.databaseFileName);
            database = JsonSerializer.Deserialize<Database>(jsonText);
        }

        //create the empty db file on disk, populate it with hash
        private void CreateDBFile()
        {
            //  it fills databaseFileName and password
            CreateDatabaseFile cdFile = new CreateDatabaseFile();
            cdFile.ShowDialog();

            // compute sha256 and fill database
            database = new Database();
            using (SHA256 sha256 = SHA256.Create())
            {
                string hash = GetHash(sha256, password);
                database.hashSha256 = hash;
                password = "";
            }

            //serialize as json
            string jsonString = JsonSerializer.Serialize(database);
            File.WriteAllText(configFile.databaseFileName, jsonString);
        }

        // compute sha256 hash
        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder stringBuilder = new StringBuilder();

            for(int a = 0; a < data.Length; a++)
            {
                stringBuilder.Append(data[a].ToString("x2"));
            }

            return stringBuilder.ToString();
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
            this.Text = "Sharpwallet v1.0";
        }
    }
}

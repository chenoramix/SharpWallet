﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SharpWallet
{
    public partial class CreateDatabaseFile : Form
    {
        public CreateDatabaseFile()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CreateDatabaseFile_Load(object sender, EventArgs e)
        {
            this.textFilePath.Text = Directory.GetCurrentDirectory() + "\\sharpwallet.db";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(textFilePath.Text.Length == 0)
            {
                MessageBox.Show("You need to enter path for database", "Error");
                return;
            }

            if(textBoxPassword1.Text.Length == 0 || textBoxPassword2.Text.Length == 0)
            {
                MessageBox.Show("You must enter a password", "Error");
                return;
            }

            if(textBoxPassword1.Text != textBoxPassword2.Text)
            {
                MessageBox.Show("Password didn't match, try again");
                return;
            }

            MainFrm.databaseFileName = textFilePath.Text;
            this.Close();
        }

        private void btnSaveDialog_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Database file (*.db)|*.db";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textFilePath.Text = saveFileDialog1.FileName;
            }
        }
    }
}

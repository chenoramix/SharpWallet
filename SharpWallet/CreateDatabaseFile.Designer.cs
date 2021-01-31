
namespace SharpWallet
{
    partial class CreateDatabaseFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDatabaseFile));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.btnSaveDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(519, 263);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(12, 269);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(423, 27);
            this.textFilePath.TabIndex = 1;
            // 
            // btnSaveDialog
            // 
            this.btnSaveDialog.Location = new System.Drawing.Point(441, 267);
            this.btnSaveDialog.Name = "btnSaveDialog";
            this.btnSaveDialog.Size = new System.Drawing.Size(62, 29);
            this.btnSaveDialog.TabIndex = 2;
            this.btnSaveDialog.Text = "...";
            this.btnSaveDialog.UseVisualStyleBackColor = true;
            // 
            // CreateDatabaseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 450);
            this.Controls.Add(this.btnSaveDialog);
            this.Controls.Add(this.textFilePath);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateDatabaseFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Button btnSaveDialog;
    }
}
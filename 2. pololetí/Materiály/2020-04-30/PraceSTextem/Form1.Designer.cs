namespace PraceSTextem
{
    partial class Form1
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
            this.openFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileNameTB = new System.Windows.Forms.TextBox();
            this.contentTB = new System.Windows.Forms.TextBox();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(12, 12);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(109, 23);
            this.openFileBtn.TabIndex = 0;
            this.openFileBtn.Text = "Načíst soubor";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // fileNameTB
            // 
            this.fileNameTB.Location = new System.Drawing.Point(12, 42);
            this.fileNameTB.Name = "fileNameTB";
            this.fileNameTB.Size = new System.Drawing.Size(776, 20);
            this.fileNameTB.TabIndex = 1;
            // 
            // contentTB
            // 
            this.contentTB.Location = new System.Drawing.Point(13, 69);
            this.contentTB.Multiline = true;
            this.contentTB.Name = "contentTB";
            this.contentTB.Size = new System.Drawing.Size(775, 369);
            this.contentTB.TabIndex = 2;
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Location = new System.Drawing.Point(127, 12);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(109, 23);
            this.saveFileBtn.TabIndex = 3;
            this.saveFileBtn.Text = "Uložit soubor";
            this.saveFileBtn.UseVisualStyleBackColor = true;
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.contentTB);
            this.Controls.Add(this.fileNameTB);
            this.Controls.Add(this.openFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox fileNameTB;
        private System.Windows.Forms.TextBox contentTB;
        private System.Windows.Forms.Button saveFileBtn;
    }
}


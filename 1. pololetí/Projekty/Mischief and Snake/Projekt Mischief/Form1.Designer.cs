namespace WinForm_Projekt
{
    partial class FormMain
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
            this.buttonLevel1 = new System.Windows.Forms.Button();
            this.buttonLevel2S = new System.Windows.Forms.Button();
            this.buttonLevel3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLevel1
            // 
            this.buttonLevel1.BackColor = System.Drawing.SystemColors.Info;
            this.buttonLevel1.Location = new System.Drawing.Point(129, 167);
            this.buttonLevel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLevel1.Name = "buttonLevel1";
            this.buttonLevel1.Size = new System.Drawing.Size(341, 34);
            this.buttonLevel1.TabIndex = 0;
            this.buttonLevel1.Text = "Dodge (WIP)";
            this.buttonLevel1.UseVisualStyleBackColor = false;
            this.buttonLevel1.Click += new System.EventHandler(this.buttonLevel1_Click);
            // 
            // buttonLevel2S
            // 
            this.buttonLevel2S.BackColor = System.Drawing.SystemColors.Info;
            this.buttonLevel2S.Location = new System.Drawing.Point(129, 209);
            this.buttonLevel2S.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLevel2S.Name = "buttonLevel2S";
            this.buttonLevel2S.Size = new System.Drawing.Size(341, 34);
            this.buttonLevel2S.TabIndex = 1;
            this.buttonLevel2S.Text = "Pong SinglePlayer (WIP)";
            this.buttonLevel2S.UseVisualStyleBackColor = false;
            this.buttonLevel2S.Click += new System.EventHandler(this.ButtonLevel2_Click);
            // 
            // buttonLevel3
            // 
            this.buttonLevel3.BackColor = System.Drawing.SystemColors.Info;
            this.buttonLevel3.Location = new System.Drawing.Point(129, 251);
            this.buttonLevel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLevel3.Name = "buttonLevel3";
            this.buttonLevel3.Size = new System.Drawing.Size(341, 34);
            this.buttonLevel3.TabIndex = 2;
            this.buttonLevel3.Text = "Snake (WIP)";
            this.buttonLevel3.UseVisualStyleBackColor = false;
            this.buttonLevel3.Click += new System.EventHandler(this.ButtonLevel3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(233, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mischief";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(579, 469);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLevel3);
            this.Controls.Add(this.buttonLevel2S);
            this.Controls.Add(this.buttonLevel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Main menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLevel1;
        private System.Windows.Forms.Button buttonLevel2S;
        private System.Windows.Forms.Button buttonLevel3;
        private System.Windows.Forms.Label label1;
    }
}


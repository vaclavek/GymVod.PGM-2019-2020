namespace GrafikGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.elipsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kružniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.čtverecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBTN = new System.Windows.Forms.Button();
            this.penWidth = new System.Windows.Forms.TrackBar();
            this.WH_radioButton = new System.Windows.Forms.RadioButton();
            this.YE_RadioButton = new System.Windows.Forms.RadioButton();
            this.RD_radioButton = new System.Windows.Forms.RadioButton();
            this.GR_radioButton = new System.Windows.Forms.RadioButton();
            this.BL_radioButton = new System.Windows.Forms.RadioButton();
            this.BK_radioButton = new System.Windows.Forms.RadioButton();
            this.drwInf = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elipsaToolStripMenuItem,
            this.kružniceToolStripMenuItem,
            this.čtverecToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // elipsaToolStripMenuItem
            // 
            this.elipsaToolStripMenuItem.Name = "elipsaToolStripMenuItem";
            this.elipsaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.elipsaToolStripMenuItem.Text = "Ellipse";
            this.elipsaToolStripMenuItem.Click += new System.EventHandler(this.elipsaToolStripMenuItem_Click);
            // 
            // kružniceToolStripMenuItem
            // 
            this.kružniceToolStripMenuItem.Name = "kružniceToolStripMenuItem";
            this.kružniceToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.kružniceToolStripMenuItem.Text = "Circle";
            this.kružniceToolStripMenuItem.Click += new System.EventHandler(this.kružniceToolStripMenuItem_Click);
            // 
            // čtverecToolStripMenuItem
            // 
            this.čtverecToolStripMenuItem.Name = "čtverecToolStripMenuItem";
            this.čtverecToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.čtverecToolStripMenuItem.Text = "Square";
            this.čtverecToolStripMenuItem.Click += new System.EventHandler(this.čtverecToolStripMenuItem_Click);
            // 
            // deleteBTN
            // 
            this.deleteBTN.Location = new System.Drawing.Point(617, 448);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(75, 23);
            this.deleteBTN.TabIndex = 1;
            this.deleteBTN.Text = "Delet This";
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // penWidth
            // 
            this.penWidth.BackColor = System.Drawing.SystemColors.Control;
            this.penWidth.Location = new System.Drawing.Point(191, 444);
            this.penWidth.Maximum = 25;
            this.penWidth.Minimum = 5;
            this.penWidth.Name = "penWidth";
            this.penWidth.RightToLeftLayout = true;
            this.penWidth.Size = new System.Drawing.Size(317, 45);
            this.penWidth.TabIndex = 3;
            this.penWidth.Value = 5;
            // 
            // WH_radioButton
            // 
            this.WH_radioButton.AutoSize = true;
            this.WH_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.WH_radioButton.Location = new System.Drawing.Point(21, 352);
            this.WH_radioButton.Name = "WH_radioButton";
            this.WH_radioButton.Size = new System.Drawing.Size(53, 17);
            this.WH_radioButton.TabIndex = 4;
            this.WH_radioButton.TabStop = true;
            this.WH_radioButton.Text = "White";
            this.WH_radioButton.UseVisualStyleBackColor = false;
            // 
            // YE_RadioButton
            // 
            this.YE_RadioButton.AutoSize = true;
            this.YE_RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.YE_RadioButton.Location = new System.Drawing.Point(21, 375);
            this.YE_RadioButton.Name = "YE_RadioButton";
            this.YE_RadioButton.Size = new System.Drawing.Size(56, 17);
            this.YE_RadioButton.TabIndex = 5;
            this.YE_RadioButton.TabStop = true;
            this.YE_RadioButton.Text = "Yellow";
            this.YE_RadioButton.UseVisualStyleBackColor = false;
            // 
            // RD_radioButton
            // 
            this.RD_radioButton.AutoSize = true;
            this.RD_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.RD_radioButton.Location = new System.Drawing.Point(21, 398);
            this.RD_radioButton.Name = "RD_radioButton";
            this.RD_radioButton.Size = new System.Drawing.Size(45, 17);
            this.RD_radioButton.TabIndex = 6;
            this.RD_radioButton.TabStop = true;
            this.RD_radioButton.Text = "Red";
            this.RD_radioButton.UseVisualStyleBackColor = false;
            // 
            // GR_radioButton
            // 
            this.GR_radioButton.AutoSize = true;
            this.GR_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.GR_radioButton.Location = new System.Drawing.Point(21, 421);
            this.GR_radioButton.Name = "GR_radioButton";
            this.GR_radioButton.Size = new System.Drawing.Size(54, 17);
            this.GR_radioButton.TabIndex = 7;
            this.GR_radioButton.TabStop = true;
            this.GR_radioButton.Text = "Green";
            this.GR_radioButton.UseVisualStyleBackColor = false;
            // 
            // BL_radioButton
            // 
            this.BL_radioButton.AutoSize = true;
            this.BL_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.BL_radioButton.Location = new System.Drawing.Point(21, 444);
            this.BL_radioButton.Name = "BL_radioButton";
            this.BL_radioButton.Size = new System.Drawing.Size(46, 17);
            this.BL_radioButton.TabIndex = 8;
            this.BL_radioButton.TabStop = true;
            this.BL_radioButton.Text = "Blue";
            this.BL_radioButton.UseVisualStyleBackColor = false;
            // 
            // BK_radioButton
            // 
            this.BK_radioButton.AutoSize = true;
            this.BK_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.BK_radioButton.Location = new System.Drawing.Point(22, 468);
            this.BK_radioButton.Name = "BK_radioButton";
            this.BK_radioButton.Size = new System.Drawing.Size(52, 17);
            this.BK_radioButton.TabIndex = 9;
            this.BK_radioButton.TabStop = true;
            this.BK_radioButton.Text = "Black";
            this.BK_radioButton.UseVisualStyleBackColor = false;
            // 
            // drwInf
            // 
            this.drwInf.AutoSize = true;
            this.drwInf.Location = new System.Drawing.Point(582, 39);
            this.drwInf.Name = "drwInf";
            this.drwInf.Size = new System.Drawing.Size(0, 13);
            this.drwInf.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 501);
            this.Controls.Add(this.drwInf);
            this.Controls.Add(this.BK_radioButton);
            this.Controls.Add(this.BL_radioButton);
            this.Controls.Add(this.GR_radioButton);
            this.Controls.Add(this.RD_radioButton);
            this.Controls.Add(this.YE_RadioButton);
            this.Controls.Add(this.WH_radioButton);
            this.Controls.Add(this.penWidth);
            this.Controls.Add(this.deleteBTN);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Malování";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem elipsaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kružniceToolStripMenuItem;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.TrackBar penWidth;
        private System.Windows.Forms.ToolStripMenuItem čtverecToolStripMenuItem;
        private System.Windows.Forms.RadioButton WH_radioButton;
        private System.Windows.Forms.RadioButton YE_RadioButton;
        private System.Windows.Forms.RadioButton RD_radioButton;
        private System.Windows.Forms.RadioButton GR_radioButton;
        private System.Windows.Forms.RadioButton BL_radioButton;
        private System.Windows.Forms.RadioButton BK_radioButton;
        private System.Windows.Forms.Label drwInf;
    }
}


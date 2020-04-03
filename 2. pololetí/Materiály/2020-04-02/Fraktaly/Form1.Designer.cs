namespace Fraktaly
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
            this.kresliciPanel = new System.Windows.Forms.Panel();
            this.angleNUD = new System.Windows.Forms.NumericUpDown();
            this.scaleNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.barvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.blackTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.blueTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.greenTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.lineWidthCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mandelbrotBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.angleNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNUD)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kresliciPanel
            // 
            this.kresliciPanel.Location = new System.Drawing.Point(138, 41);
            this.kresliciPanel.Name = "kresliciPanel";
            this.kresliciPanel.Size = new System.Drawing.Size(650, 426);
            this.kresliciPanel.TabIndex = 0;
            this.kresliciPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.kesliciPanel_Paint);
            // 
            // angleNUD
            // 
            this.angleNUD.Location = new System.Drawing.Point(15, 104);
            this.angleNUD.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.angleNUD.Name = "angleNUD";
            this.angleNUD.Size = new System.Drawing.Size(120, 20);
            this.angleNUD.TabIndex = 3;
            this.angleNUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.angleNUD.ValueChanged += new System.EventHandler(this.angleNUD_ValueChanged);
            // 
            // scaleNUD
            // 
            this.scaleNUD.DecimalPlaces = 2;
            this.scaleNUD.Location = new System.Drawing.Point(15, 57);
            this.scaleNUD.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.scaleNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleNUD.Name = "scaleNUD";
            this.scaleNUD.Size = new System.Drawing.Size(120, 20);
            this.scaleNUD.TabIndex = 2;
            this.scaleNUD.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.scaleNUD.ValueChanged += new System.EventHandler(this.scaleNUD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scale";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barvaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // barvaToolStripMenuItem
            // 
            this.barvaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redTSM,
            this.blackTSM,
            this.blueTSM,
            this.greenTSM});
            this.barvaToolStripMenuItem.Name = "barvaToolStripMenuItem";
            this.barvaToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.barvaToolStripMenuItem.Text = "Barva";
            // 
            // redTSM
            // 
            this.redTSM.Name = "redTSM";
            this.redTSM.Size = new System.Drawing.Size(180, 22);
            this.redTSM.Text = "Červená";
            this.redTSM.Click += new System.EventHandler(this.redTSM_Click);
            // 
            // blackTSM
            // 
            this.blackTSM.Name = "blackTSM";
            this.blackTSM.Size = new System.Drawing.Size(180, 22);
            this.blackTSM.Text = "Černá";
            this.blackTSM.Click += new System.EventHandler(this.blackTSM_Click);
            // 
            // blueTSM
            // 
            this.blueTSM.Name = "blueTSM";
            this.blueTSM.Size = new System.Drawing.Size(180, 22);
            this.blueTSM.Text = "Modrá";
            this.blueTSM.Click += new System.EventHandler(this.blueTSM_Click);
            // 
            // greenTSM
            // 
            this.greenTSM.Name = "greenTSM";
            this.greenTSM.Size = new System.Drawing.Size(180, 22);
            this.greenTSM.Text = "Zelená";
            this.greenTSM.Click += new System.EventHandler(this.greenTSM_Click);
            // 
            // lineWidthCB
            // 
            this.lineWidthCB.FormattingEnabled = true;
            this.lineWidthCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.lineWidthCB.Location = new System.Drawing.Point(11, 153);
            this.lineWidthCB.Name = "lineWidthCB";
            this.lineWidthCB.Size = new System.Drawing.Size(121, 21);
            this.lineWidthCB.TabIndex = 7;
            this.lineWidthCB.SelectedIndexChanged += new System.EventHandler(this.lineWidthCB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tloušťka linky";
            // 
            // mandelbrotBtn
            // 
            this.mandelbrotBtn.Location = new System.Drawing.Point(15, 440);
            this.mandelbrotBtn.Name = "mandelbrotBtn";
            this.mandelbrotBtn.Size = new System.Drawing.Size(75, 23);
            this.mandelbrotBtn.TabIndex = 9;
            this.mandelbrotBtn.Text = "Manderlbrot";
            this.mandelbrotBtn.UseVisualStyleBackColor = true;
            this.mandelbrotBtn.Click += new System.EventHandler(this.mandelbrotBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.mandelbrotBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lineWidthCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleNUD);
            this.Controls.Add(this.scaleNUD);
            this.Controls.Add(this.kresliciPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.angleNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNUD)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel kresliciPanel;
        private System.Windows.Forms.NumericUpDown angleNUD;
        private System.Windows.Forms.NumericUpDown scaleNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem barvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redTSM;
        private System.Windows.Forms.ToolStripMenuItem blackTSM;
        private System.Windows.Forms.ToolStripMenuItem blueTSM;
        private System.Windows.Forms.ToolStripMenuItem greenTSM;
        private System.Windows.Forms.ComboBox lineWidthCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button mandelbrotBtn;
    }
}


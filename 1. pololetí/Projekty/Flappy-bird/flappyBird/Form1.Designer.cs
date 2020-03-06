namespace flappyBird
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Background = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pipe1 = new System.Windows.Forms.PictureBox();
            this.pipe2 = new System.Windows.Forms.PictureBox();
            this.bird = new System.Windows.Forms.PictureBox();
            this.gmoverText = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.newGameText = new System.Windows.Forms.Label();
            this.pipe4 = new System.Windows.Forms.PictureBox();
            this.pipe3 = new System.Windows.Forms.PictureBox();
            this.Skore = new System.Windows.Forms.Label();
            this.startText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe3)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Background.BackgroundImage")));
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(1004, 441);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pipe1
            // 
            this.pipe1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pipe1.BackgroundImage")));
            this.pipe1.Location = new System.Drawing.Point(765, 0);
            this.pipe1.Name = "pipe1";
            this.pipe1.Size = new System.Drawing.Size(60, 131);
            this.pipe1.TabIndex = 1;
            this.pipe1.TabStop = false;
            // 
            // pipe2
            // 
            this.pipe2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pipe2.BackColor = System.Drawing.Color.Transparent;
            this.pipe2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pipe2.BackgroundImage")));
            this.pipe2.Location = new System.Drawing.Point(765, 263);
            this.pipe2.Name = "pipe2";
            this.pipe2.Size = new System.Drawing.Size(60, 400);
            this.pipe2.TabIndex = 2;
            this.pipe2.TabStop = false;
            // 
            // bird
            // 
            this.bird.BackColor = System.Drawing.Color.Black;
            this.bird.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bird.Image = ((System.Drawing.Image)(resources.GetObject("bird.Image")));
            this.bird.Location = new System.Drawing.Point(28, 234);
            this.bird.Name = "bird";
            this.bird.Size = new System.Drawing.Size(66, 54);
            this.bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bird.TabIndex = 3;
            this.bird.TabStop = false;
            // 
            // gmoverText
            // 
            this.gmoverText.AutoSize = true;
            this.gmoverText.BackColor = System.Drawing.Color.Black;
            this.gmoverText.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gmoverText.ForeColor = System.Drawing.Color.Red;
            this.gmoverText.Location = new System.Drawing.Point(397, 166);
            this.gmoverText.Name = "gmoverText";
            this.gmoverText.Size = new System.Drawing.Size(304, 36);
            this.gmoverText.TabIndex = 5;
            this.gmoverText.Text = "KONEC HRY! Score: ";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // newGameText
            // 
            this.newGameText.AutoSize = true;
            this.newGameText.BackColor = System.Drawing.Color.Black;
            this.newGameText.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameText.ForeColor = System.Drawing.Color.Red;
            this.newGameText.Location = new System.Drawing.Point(298, 224);
            this.newGameText.Name = "newGameText";
            this.newGameText.Size = new System.Drawing.Size(467, 36);
            this.newGameText.TabIndex = 6;
            this.newGameText.Text = "STISKNI ENTER PRO NOVOU HRU";
            // 
            // pipe4
            // 
            this.pipe4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pipe4.BackColor = System.Drawing.Color.Transparent;
            this.pipe4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pipe4.BackgroundImage")));
            this.pipe4.Location = new System.Drawing.Point(255, 311);
            this.pipe4.Name = "pipe4";
            this.pipe4.Size = new System.Drawing.Size(60, 130);
            this.pipe4.TabIndex = 7;
            this.pipe4.TabStop = false;
            // 
            // pipe3
            // 
            this.pipe3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pipe3.BackgroundImage")));
            this.pipe3.Location = new System.Drawing.Point(255, 0);
            this.pipe3.Name = "pipe3";
            this.pipe3.Size = new System.Drawing.Size(60, 172);
            this.pipe3.TabIndex = 8;
            this.pipe3.TabStop = false;
            // 
            // Skore
            // 
            this.Skore.AutoSize = true;
            this.Skore.BackColor = System.Drawing.SystemColors.Desktop;
            this.Skore.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Skore.ForeColor = System.Drawing.Color.Lime;
            this.Skore.Location = new System.Drawing.Point(490, 9);
            this.Skore.Name = "Skore";
            this.Skore.Size = new System.Drawing.Size(74, 23);
            this.Skore.TabIndex = 9;
            this.Skore.Text = "label1";
            // 
            // startText
            // 
            this.startText.AutoSize = true;
            this.startText.BackColor = System.Drawing.Color.Black;
            this.startText.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startText.ForeColor = System.Drawing.Color.Red;
            this.startText.Location = new System.Drawing.Point(413, 79);
            this.startText.Name = "startText";
            this.startText.Size = new System.Drawing.Size(242, 17);
            this.startText.TabIndex = 10;
            this.startText.Text = "POKLEPEJTE ZDE PRO ZAHÁJENÍ HRY";
            this.startText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.startText_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 441);
            this.Controls.Add(this.startText);
            this.Controls.Add(this.Skore);
            this.Controls.Add(this.pipe3);
            this.Controls.Add(this.pipe4);
            this.Controls.Add(this.newGameText);
            this.Controls.Add(this.gmoverText);
            this.Controls.Add(this.bird);
            this.Controls.Add(this.pipe2);
            this.Controls.Add(this.pipe1);
            this.Controls.Add(this.Background);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox bird;
        private System.Windows.Forms.Label gmoverText;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label newGameText;
        private System.Windows.Forms.Label Skore;
        public System.Windows.Forms.PictureBox pipe1;
        public System.Windows.Forms.PictureBox pipe2;
        public System.Windows.Forms.PictureBox pipe4;
        public System.Windows.Forms.PictureBox pipe3;
        private System.Windows.Forms.Label startText;
    }
}


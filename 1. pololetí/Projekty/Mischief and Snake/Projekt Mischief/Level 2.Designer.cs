namespace WinForm_Projekt
{
    partial class Level_2
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScoreNum2 = new System.Windows.Forms.Label();
            this.gameover2 = new System.Windows.Forms.Label();
            this.gameover1 = new System.Windows.Forms.Label();
            this.palka2 = new System.Windows.Forms.PictureBox();
            this.ScoreNum1 = new System.Windows.Forms.Label();
            this.mic = new System.Windows.Forms.PictureBox();
            this.palka1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palka2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palka1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(868, 546);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ScoreNum2);
            this.panel1.Controls.Add(this.gameover2);
            this.panel1.Controls.Add(this.gameover1);
            this.panel1.Controls.Add(this.palka2);
            this.panel1.Controls.Add(this.ScoreNum1);
            this.panel1.Controls.Add(this.mic);
            this.panel1.Controls.Add(this.palka1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 546);
            this.panel1.TabIndex = 1;
            // 
            // ScoreNum2
            // 
            this.ScoreNum2.AutoSize = true;
            this.ScoreNum2.BackColor = System.Drawing.Color.Transparent;
            this.ScoreNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreNum2.ForeColor = System.Drawing.Color.Black;
            this.ScoreNum2.Location = new System.Drawing.Point(2, 177);
            this.ScoreNum2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScoreNum2.Name = "ScoreNum2";
            this.ScoreNum2.Size = new System.Drawing.Size(37, 39);
            this.ScoreNum2.TabIndex = 10;
            this.ScoreNum2.Text = "0";
            // 
            // gameover2
            // 
            this.gameover2.AutoSize = true;
            this.gameover2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gameover2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.gameover2.ForeColor = System.Drawing.Color.Red;
            this.gameover2.Location = new System.Drawing.Point(116, 83);
            this.gameover2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameover2.Name = "gameover2";
            this.gameover2.Size = new System.Drawing.Size(245, 234);
            this.gameover2.TabIndex = 9;
            this.gameover2.Text = "You Win! \r\n\r\nR - New Game\r\nEsc - Exit\r\n\r\n\r\n";
            // 
            // gameover1
            // 
            this.gameover1.AutoSize = true;
            this.gameover1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gameover1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.gameover1.ForeColor = System.Drawing.Color.Red;
            this.gameover1.Location = new System.Drawing.Point(355, 83);
            this.gameover1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameover1.Name = "gameover1";
            this.gameover1.Size = new System.Drawing.Size(245, 234);
            this.gameover1.TabIndex = 8;
            this.gameover1.Text = "You Lose! \r\n\r\nR - New Game\r\nEsc - Exit\r\n\r\n\r\n";
            // 
            // palka2
            // 
            this.palka2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.palka2.Location = new System.Drawing.Point(277, 67);
            this.palka2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.palka2.Name = "palka2";
            this.palka2.Size = new System.Drawing.Size(112, 15);
            this.palka2.TabIndex = 7;
            this.palka2.TabStop = false;
            // 
            // ScoreNum1
            // 
            this.ScoreNum1.AutoSize = true;
            this.ScoreNum1.BackColor = System.Drawing.Color.Transparent;
            this.ScoreNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreNum1.ForeColor = System.Drawing.Color.Black;
            this.ScoreNum1.Location = new System.Drawing.Point(2, 312);
            this.ScoreNum1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScoreNum1.Name = "ScoreNum1";
            this.ScoreNum1.Size = new System.Drawing.Size(37, 39);
            this.ScoreNum1.TabIndex = 6;
            this.ScoreNum1.Text = "0";
            // 
            // mic
            // 
            this.mic.BackColor = System.Drawing.Color.Red;
            this.mic.Location = new System.Drawing.Point(334, 300);
            this.mic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mic.Name = "mic";
            this.mic.Size = new System.Drawing.Size(16, 16);
            this.mic.TabIndex = 3;
            this.mic.TabStop = false;
            // 
            // palka1
            // 
            this.palka1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.palka1.Location = new System.Drawing.Point(277, 508);
            this.palka1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.palka1.Name = "palka1";
            this.palka1.Size = new System.Drawing.Size(112, 15);
            this.palka1.TabIndex = 2;
            this.palka1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Level_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Level_2";
            this.Text = "Pong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level_2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palka2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palka1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox mic;
        private System.Windows.Forms.PictureBox palka1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label ScoreNum1;
        private System.Windows.Forms.PictureBox palka2;
        private System.Windows.Forms.Label gameover1;
        private System.Windows.Forms.Label gameover2;
        private System.Windows.Forms.Label ScoreNum2;
    }
}
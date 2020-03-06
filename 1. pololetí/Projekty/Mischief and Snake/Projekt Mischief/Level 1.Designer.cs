namespace WinForm_Projekt
{
    partial class Level_1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameover = new System.Windows.Forms.Label();
            this.labelPause = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelSec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // gameover
            // 
            this.gameover.AutoSize = true;
            this.gameover.BackColor = System.Drawing.Color.Transparent;
            this.gameover.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.gameover.ForeColor = System.Drawing.Color.DarkRed;
            this.gameover.Location = new System.Drawing.Point(265, 146);
            this.gameover.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameover.Name = "gameover";
            this.gameover.Size = new System.Drawing.Size(236, 48);
            this.gameover.TabIndex = 2;
            this.gameover.Text = "Game Over";
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.BackColor = System.Drawing.Color.Transparent;
            this.labelPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPause.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelPause.Location = new System.Drawing.Point(228, 326);
            this.labelPause.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(310, 20);
            this.labelPause.TabIndex = 3;
            this.labelPause.Text = "Game paused. Press \"Space\" to resume";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.BackColor = System.Drawing.Color.Transparent;
            this.labelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelMin.Location = new System.Drawing.Point(12, 9);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(64, 44);
            this.labelMin.TabIndex = 5;
            this.labelMin.Text = "00";
            // 
            // labelSec
            // 
            this.labelSec.AutoSize = true;
            this.labelSec.BackColor = System.Drawing.Color.Transparent;
            this.labelSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSec.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSec.Location = new System.Drawing.Point(120, 9);
            this.labelSec.Name = "labelSec";
            this.labelSec.Size = new System.Drawing.Size(64, 44);
            this.labelSec.TabIndex = 6;
            this.labelSec.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(82, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = ":";
            // 
            // Level_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(845, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSec);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPause);
            this.Controls.Add(this.gameover);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Level_1";
            this.Text = "Dodge";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Level_1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level_1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label gameover;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.Label label2;
    }
}
namespace DatoveTypy
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
            this.malaPismenaBtn = new System.Windows.Forms.Button();
            this.cisliceBtn = new System.Windows.Forms.Button();
            this.velkaPismenaBtn = new System.Windows.Forms.Button();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // malaPismenaBtn
            // 
            this.malaPismenaBtn.Location = new System.Drawing.Point(14, 12);
            this.malaPismenaBtn.Name = "malaPismenaBtn";
            this.malaPismenaBtn.Size = new System.Drawing.Size(130, 23);
            this.malaPismenaBtn.TabIndex = 0;
            this.malaPismenaBtn.Text = "Malá písmena";
            this.malaPismenaBtn.UseVisualStyleBackColor = true;
            this.malaPismenaBtn.Click += new System.EventHandler(this.malaPismenaBtn_Click);
            // 
            // cisliceBtn
            // 
            this.cisliceBtn.Location = new System.Drawing.Point(286, 12);
            this.cisliceBtn.Name = "cisliceBtn";
            this.cisliceBtn.Size = new System.Drawing.Size(130, 23);
            this.cisliceBtn.TabIndex = 1;
            this.cisliceBtn.Text = "Číslice";
            this.cisliceBtn.UseVisualStyleBackColor = true;
            this.cisliceBtn.Click += new System.EventHandler(this.cisliceBtn_Click);
            // 
            // velkaPismenaBtn
            // 
            this.velkaPismenaBtn.Location = new System.Drawing.Point(150, 12);
            this.velkaPismenaBtn.Name = "velkaPismenaBtn";
            this.velkaPismenaBtn.Size = new System.Drawing.Size(130, 23);
            this.velkaPismenaBtn.TabIndex = 2;
            this.velkaPismenaBtn.Text = "Velká písmena";
            this.velkaPismenaBtn.UseVisualStyleBackColor = true;
            this.velkaPismenaBtn.Click += new System.EventHandler(this.velkaPismenaBtn_Click);
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(14, 42);
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.Size = new System.Drawing.Size(402, 20);
            this.outputTB.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 88);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.velkaPismenaBtn);
            this.Controls.Add(this.cisliceBtn);
            this.Controls.Add(this.malaPismenaBtn);
            this.Name = "Form1";
            this.Text = "Datové typy - generování znaků";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button malaPismenaBtn;
        private System.Windows.Forms.Button cisliceBtn;
        private System.Windows.Forms.Button velkaPismenaBtn;
        private System.Windows.Forms.TextBox outputTB;
    }
}


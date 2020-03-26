namespace ToDoList_muj_
{
    partial class MainForm
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
            this.LBList = new System.Windows.Forms.ListBox();
            this.BPridat = new System.Windows.Forms.Button();
            this.BOdebrat = new System.Windows.Forms.Button();
            this.TBPolozka = new System.Windows.Forms.TextBox();
            this.DTPPolozka = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBList
            // 
            this.LBList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBList.FormattingEnabled = true;
            this.LBList.Location = new System.Drawing.Point(16, 15);
            this.LBList.Name = "LBList";
            this.LBList.Size = new System.Drawing.Size(589, 264);
            this.LBList.TabIndex = 0;
            // 
            // BPridat
            // 
            this.BPridat.Location = new System.Drawing.Point(0, 135);
            this.BPridat.Name = "BPridat";
            this.BPridat.Size = new System.Drawing.Size(235, 46);
            this.BPridat.TabIndex = 1;
            this.BPridat.Text = "OK";
            this.BPridat.UseVisualStyleBackColor = true;
            this.BPridat.Click += new System.EventHandler(this.BPridat_Click);
            // 
            // BOdebrat
            // 
            this.BOdebrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BOdebrat.Location = new System.Drawing.Point(370, 426);
            this.BOdebrat.Name = "BOdebrat";
            this.BOdebrat.Size = new System.Drawing.Size(235, 46);
            this.BOdebrat.TabIndex = 2;
            this.BOdebrat.Text = "Odebrat položku";
            this.BOdebrat.UseVisualStyleBackColor = true;
            this.BOdebrat.Click += new System.EventHandler(this.BOdebrat_Click);
            // 
            // TBPolozka
            // 
            this.TBPolozka.Location = new System.Drawing.Point(0, 49);
            this.TBPolozka.Name = "TBPolozka";
            this.TBPolozka.Size = new System.Drawing.Size(235, 20);
            this.TBPolozka.TabIndex = 3;
            // 
            // DTPPolozka
            // 
            this.DTPPolozka.Location = new System.Drawing.Point(0, 75);
            this.DTPPolozka.Name = "DTPPolozka";
            this.DTPPolozka.Size = new System.Drawing.Size(235, 20);
            this.DTPPolozka.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.TBPolozka);
            this.groupBox1.Controls.Add(this.DTPPolozka);
            this.groupBox1.Controls.Add(this.BPridat);
            this.groupBox1.Location = new System.Drawing.Point(12, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 200);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Přidat položku";
            // 
            // MainForm
            // 
            this.AcceptButton = this.BPridat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BOdebrat);
            this.Controls.Add(this.LBList);
            this.Name = "MainForm";
            this.Text = "Seznam";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBList;
        private System.Windows.Forms.Button BPridat;
        private System.Windows.Forms.Button BOdebrat;
        private System.Windows.Forms.TextBox TBPolozka;
        private System.Windows.Forms.DateTimePicker DTPPolozka;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
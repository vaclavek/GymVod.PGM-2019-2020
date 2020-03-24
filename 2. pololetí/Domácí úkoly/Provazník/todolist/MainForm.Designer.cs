namespace TodoList
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
            this.DateDTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.TextTB = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ListLB = new System.Windows.Forms.ListBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateDTP
            // 
            this.DateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateDTP.Location = new System.Drawing.Point(79, 6);
            this.DateDTP.Name = "DateDTP";
            this.DateDTP.Size = new System.Drawing.Size(119, 20);
            this.DateDTP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Poznámka:";
            // 
            // TextTB
            // 
            this.TextTB.Location = new System.Drawing.Point(204, 6);
            this.TextTB.Name = "TextTB";
            this.TextTB.Size = new System.Drawing.Size(416, 20);
            this.TextTB.TabIndex = 2;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(626, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "Přidat";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ListLB
            // 
            this.ListLB.FormattingEnabled = true;
            this.ListLB.Location = new System.Drawing.Point(12, 32);
            this.ListLB.Name = "ListLB";
            this.ListLB.Size = new System.Drawing.Size(608, 277);
            this.ListLB.TabIndex = 4;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(626, 33);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 5;
            this.DeleteBtn.Text = "Smazat";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 326);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.ListLB);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.TextTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateDTP);
            this.Name = "MainForm";
            this.Text = "Todo List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateDTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextTB;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.ListBox ListLB;
        private System.Windows.Forms.Button DeleteBtn;
    }
}


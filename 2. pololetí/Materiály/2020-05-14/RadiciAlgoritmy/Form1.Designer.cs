namespace _9RadiciAlgoritmy
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumbers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRndNumCount = new System.Windows.Forms.NumericUpDown();
            this.butRndNumGen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAlgorithm = new System.Windows.Forms.ComboBox();
            this.butSort = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRndNumCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zadejte čísla (oddělená mezerami):";
            // 
            // tbNumbers
            // 
            this.tbNumbers.Location = new System.Drawing.Point(12, 32);
            this.tbNumbers.Multiline = true;
            this.tbNumbers.Name = "tbNumbers";
            this.tbNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNumbers.Size = new System.Drawing.Size(256, 76);
            this.tbNumbers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nebo vygeneruj náhodně x čísel:";
            // 
            // nudRndNumCount
            // 
            this.nudRndNumCount.Location = new System.Drawing.Point(12, 134);
            this.nudRndNumCount.Name = "nudRndNumCount";
            this.nudRndNumCount.Size = new System.Drawing.Size(158, 22);
            this.nudRndNumCount.TabIndex = 3;
            // 
            // butRndNumGen
            // 
            this.butRndNumGen.Location = new System.Drawing.Point(176, 130);
            this.butRndNumGen.Name = "butRndNumGen";
            this.butRndNumGen.Size = new System.Drawing.Size(92, 28);
            this.butRndNumGen.TabIndex = 4;
            this.butRndNumGen.Text = "Vygeneruj";
            this.butRndNumGen.UseVisualStyleBackColor = true;
            this.butRndNumGen.Click += new System.EventHandler(this.butRndNumGen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seřaď čísla algoritmem:";
            // 
            // cbAlgorithm
            // 
            this.cbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgorithm.FormattingEnabled = true;
            this.cbAlgorithm.Items.AddRange(new object[] {
            "Bubble sort",
            "Insert sort",
            "Select sort"});
            this.cbAlgorithm.Location = new System.Drawing.Point(12, 180);
            this.cbAlgorithm.Name = "cbAlgorithm";
            this.cbAlgorithm.Size = new System.Drawing.Size(158, 24);
            this.cbAlgorithm.TabIndex = 6;
            // 
            // butSort
            // 
            this.butSort.Location = new System.Drawing.Point(176, 177);
            this.butSort.Name = "butSort";
            this.butSort.Size = new System.Drawing.Size(92, 28);
            this.butSort.TabIndex = 7;
            this.butSort.Text = "Seřaď";
            this.butSort.UseVisualStyleBackColor = true;
            this.butSort.Click += new System.EventHandler(this.butSort_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seřazená čísla:";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 227);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(256, 76);
            this.tbOutput.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 313);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butSort);
            this.Controls.Add(this.cbAlgorithm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butRndNumGen);
            this.Controls.Add(this.nudRndNumCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNumbers);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudRndNumCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRndNumCount;
        private System.Windows.Forms.Button butRndNumGen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAlgorithm;
        private System.Windows.Forms.Button butSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOutput;
    }
}


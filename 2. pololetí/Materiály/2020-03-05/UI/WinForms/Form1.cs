using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stavAplikaceLabel.Text = "Uživatel klikl";
            if(jmenoTextbox.Text == "")
            {
                MessageBox.Show("Musíš zadat jméno!", "Chyba", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Ahoj " + jmenoTextbox.Text, "", MessageBoxButtons.YesNo);

            webBrowser1.Url = new Uri("http://www.google.com");

            var soubor = openFileDialog1.ShowDialog();
            var barva = colorDialog1.ShowDialog();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Narozeniny potřebujeme znát kvůli ověření věku.", "Narozeniny", MessageBoxButtons.OK); 
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 95)
            {
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.Value = progressBar1.Value + 5;
            }
        }
    }
}

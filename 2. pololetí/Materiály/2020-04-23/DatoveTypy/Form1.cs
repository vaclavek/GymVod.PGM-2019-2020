using System;
using System.Windows.Forms;

namespace DatoveTypy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        private void malaPismenaBtn_Click(object sender, EventArgs e)
        {
            int cislo = rnd.Next(97, 123);
            char znak = (char)cislo;
            outputTB.Text += znak;
        }

        private void velkaPismenaBtn_Click(object sender, EventArgs e)
        {
            int cislo = rnd.Next(65, 91);
            char znak = (char)cislo;
            outputTB.Text += znak;
        }

        private void cisliceBtn_Click(object sender, EventArgs e)
        {
            int cislo = rnd.Next(0, 10);
            outputTB.Text += cislo.ToString();
        }
    }
}

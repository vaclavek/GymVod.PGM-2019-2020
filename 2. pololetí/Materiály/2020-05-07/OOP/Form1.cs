using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<ITvar> seznamTvaru = new List<ITvar>();
            for (int i = 0; i < 20; i++)
            {
                int cislo = rnd.Next(0, 3);
                ITvar tvar = null;
                switch (cislo)
                {
                    case 0:
                        tvar = new Kruh(5);
                        break;
                    case 1:
                        tvar = new Čtverec(5);
                        break;
                    case 2:
                        tvar = new Obdelnik(5, 8);
                        break;
                }
                seznamTvaru.Add(tvar);
            }

            foreach(ITvar polozka in seznamTvaru)
            {                               
                string vysledek = polozka.VratInformace() + ", obsah je " + polozka.VypoctiObsah();
                textBox1.Text += vysledek + Environment.NewLine;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kulicka
{
    public partial class Form1 : Form
    {
        float x; // souřadnice kuličky
        float y; // souřadnice kuličky

        float vx, vy; // rychlost

        const int diameter = 10; // průměr kuličky

        public Form1()
        {
            InitializeComponent();

            x = (ClientSize.Width - diameter) / 2;
            y = (ClientSize.Height - diameter) / 2;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;

            var random = new Random();
            vx = random.Next(-15, 15);
            vy = random.Next(-15, 15);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.FillEllipse(Brushes.Blue, x, y, diameter, diameter);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            x = x + vx;
            y = y + vy;

            // test na pravý okraj
            var overflowX = (x + diameter) - ClientSize.Width;
            if (overflowX > 0)
            {
                vx = -vx;
                x = ClientSize.Width - overflowX - diameter;
            }

            // test na levý okraj
            if (x < 0)
            {
                vx = -vx;
                x = -x;
            }

            // test na dolní okraj
            var overflowY = (y + diameter) - ClientSize.Height;
            if (overflowY > 0)
            {
                vy = -vy;
                y = ClientSize.Height - overflowY - diameter;
            }

            // test na horní okraj
            if (y < 0)
            {
                vy = -vy;
                y = -y;
            }

            Refresh();
        }
    }
}

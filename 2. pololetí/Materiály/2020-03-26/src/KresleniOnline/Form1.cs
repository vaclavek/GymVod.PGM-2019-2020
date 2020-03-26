using System;
using System.Drawing;
using System.Windows.Forms;

namespace KresleniOnline
{
    public partial class Form1 : Form
    {
        private Graphics kresliciPlocha;

        public Form1()
        {
            InitializeComponent();
            kresliciPlocha = panel.CreateGraphics();
        }

        private void btnTvary_Click(object sender, EventArgs e)
        {
            var form = new PaintForm();
            form.ShowDialog();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void endBtn_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            Shape shape = (Shape)random.Next(0, 4);

            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);
            Color color = Color.FromArgb(red, green, blue);

            var pen = new Pen(color, 1);

            int width = random.Next(0, 100);
            int height = random.Next(0, 100);

            int x = random.Next(0, panel.Width - width);
            int y = random.Next(0, panel.Height - height);

            bool fillled = random.Next(0, 2) == 0;

            if (shape == Shape.Ellipse)
            {
                if (fillled)
                {
                    Brush brush = new SolidBrush(color);
                    kresliciPlocha.FillEllipse(brush, x, y, width, height);
                }
                else
                {
                    kresliciPlocha.DrawEllipse(pen, x, y, width, height);
                }
            }
            else if (shape == Shape.Rectangle)
            {
                if (fillled)
                {
                    Brush brush = new SolidBrush(color);
                    kresliciPlocha.FillRectangle(brush, x, y, width, height);
                }
                else
                {
                    kresliciPlocha.DrawRectangle(pen, x, y, width, height);
                }
            }
            else if (shape == Shape.Line)
            {
                // kreslí to správně?
                kresliciPlocha.DrawLine(pen, x, y, x + width, y + height);
            }
            else if (shape == Shape.String)
            {
                Font font = new Font("Arial", 14);
                Brush brush = new SolidBrush(color);
                kresliciPlocha.DrawString("Hello kitty!", font, brush, x, y);
            }
        }

        enum Shape
        {
            Ellipse,
            Rectangle,
            Line,
            String,
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fraktaly
{
    public partial class MandelbrotForm : Form
    {
        private static double pXmax;
        private static double pYmax;
        private static double pXmin;
        private static double pYmin;

        public MandelbrotForm()
        {
            InitializeComponent();
        }

        private void MandelbrotForm_Load(object sender, EventArgs e)
        {
            Bitmap pic = Mandelbrotset(pictureBox1, 2, -2, 2, -2);
            pictureBox1.Image = pic;
        }

        static Bitmap Mandelbrotset(PictureBox pictureBox1, double Xmax, double Xmin, double Ymax, double Ymin)
        {
            pXmax = Xmax;
            pYmax = Ymax;
            pXmin = Xmin;
            pYmin = Ymin;

            Bitmap pic = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            double zx = 0;
            double zy = 0;
            double cx = 0;
            double cy = 0;
            double xzoom = ((Xmax - Xmin) / Convert.ToDouble(pic.Width));
            double yzoom = ((Ymax - Ymin) / Convert.ToDouble(pic.Height));
            double tempzx = 0;

            int loopgo = 0;
            for (int x = 0; x < pic.Width; x++)
            {
                cx = (xzoom * x) - Math.Abs(Xmin);
                for (int y = 0; y < pic.Height; y++)
                {
                    zx = 0;
                    zy = 0;
                    cy = (yzoom * y) - Math.Abs(Ymin);
                    loopgo = 0;

                    while (zx * zx + zy * zy <= 4 && loopgo < 1000)
                    {
                        loopgo++;
                        tempzx = zx;
                        zx = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * tempzx * zy) + cy;
                    }

                    if (loopgo != 1000)
                        pic.SetPixel(x, y, Color.FromArgb(loopgo % 128 * 2, loopgo % 32 * 7, loopgo % 16 * 14));
                    else
                        pic.SetPixel(x, y, Color.Black);

                }
            }

            return pic;

        }
    }
}

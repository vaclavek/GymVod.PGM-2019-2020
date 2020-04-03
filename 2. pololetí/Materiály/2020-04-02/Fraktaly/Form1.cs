using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Fraktaly
{
    public partial class Form1 : Form
    {
        float scale = 3;
        double angle = 30;
        Color color = Color.Red;
        int lineWidth = 1;

        public Form1()
        {
            InitializeComponent();

            // trik = zapnutí Double Bufferingu pomocí reflexe, aby nám panel neblikal (to si nesnažte zapamatovat)
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, kresliciPanel, new object[] { true });

            lineWidthCB.Items.Clear();
            for (int i = 1; i < 20; i++)
            {
                lineWidthCB.Items.Add(i);
            }
        }

        private void kesliciPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            double angleRad = angle * Math.PI / 180;
            DrawBranch(graphics, new PointF(this.Width / 2, this.Height - 50), new PointF(0, -200), angleRad, scale);
        }

        private void scaleNUD_ValueChanged(object sender, System.EventArgs e)
        {
            scale = Convert.ToSingle(scaleNUD.Value);
            if (scale <= 1.3)
            {
                scale = 1.3f;
            }
            kresliciPanel.Refresh();
        }

        private void angleNUD_ValueChanged(object sender, System.EventArgs e)
        {
            angle = Convert.ToDouble(angleNUD.Value);
            kresliciPanel.Refresh();
        }

        void DrawBranch(Graphics g, PointF o, PointF v, double a, float s)
        {
            float tempX, tempY;

            Pen pen = new Pen(color, lineWidth);
            g.DrawLine(pen, o, new PointF(o.X = o.X + v.X, o.Y = o.Y + v.Y));

            if (Math.Abs(v.X) + Math.Abs(v.Y) > 2)
            {
                tempX = v.X;
                tempY = v.Y;
                v.X = Convert.ToSingle(Math.Cos(a) * tempX - Math.Sin(a) * tempY) / s;
                v.Y = Convert.ToSingle(Math.Sin(a) * tempX + Math.Cos(a) * tempY) / s;
                DrawBranch(g, o, v, a, s);

                v.X = Convert.ToSingle(Math.Cos(-a) * tempX - Math.Sin(-a / 2) * tempY) / s;
                v.Y = Convert.ToSingle(Math.Sin(-a) * tempX + Math.Cos(-a / 2) * tempY) / s;
                DrawBranch(g, o, v, a, s);

                //if (state > 0)
                //{
                //    v.X = tempX / s;
                //    v.Y = tempY / s;
                //    branch(g, o, v, a, s);
                //    if (state > 1)
                //    {
                //        v.X = Convert.ToSingle((Math.Cos(a * 2) * tempX) - (Math.Sin(a * 2) * tempY)) / s;
                //        v.Y = Convert.ToSingle((Math.Sin(a * 2) * tempX) + (Math.Cos(a * 2) * tempY)) / s;
                //        branch(g, o, v, a, s);
                //        v.X = Convert.ToSingle((Math.Cos(-a * 2) * tempX) - (Math.Sin(-a * 2) * tempY)) / s;
                //        v.Y = Convert.ToSingle((Math.Sin(-a * 2) * tempX) + (Math.Cos(-a * 2) * tempY)) / s;
                //        branch(g, o, v, a, s);
                //    }
                //}

            }

        }

        private void redTSM_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            kresliciPanel.Refresh();
        }

        private void blackTSM_Click(object sender, EventArgs e)
        {
            color = Color.Black;
            kresliciPanel.Refresh();
        }

        private void blueTSM_Click(object sender, EventArgs e)
        {
            color = Color.Blue;
            kresliciPanel.Refresh();
        }

        private void greenTSM_Click(object sender, EventArgs e)
        {
            color = Color.Green;
            kresliciPanel.Refresh();
        }

        private void lineWidthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineWidth = Convert.ToInt32(lineWidthCB.SelectedItem);
            kresliciPanel.Refresh();
        }

        private void mandelbrotBtn_Click(object sender, EventArgs e)
        {
            var f = new MandelbrotForm();
            f.ShowDialog();
        }
    }
}

using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KresleniOnline
{
    public partial class PaintForm : Form
    {
        private List<PointWithColor> Points = new List<PointWithColor>();

        private Color SelectedColor = Color.Red;

        public PaintForm()
        {
            InitializeComponent();

            // trik = zapnutí Double Bufferingu pomocí reflexe, aby nám panel neblikal (to si nesnažte zapamatovat)
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                PointWithColor pointWithColor = new PointWithColor();
                pointWithColor.Point = e.Location;
                pointWithColor.Color = SelectedColor;
                Points.Add(pointWithColor);
                panel.Refresh();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            var kresliciPlocha = e.Graphics;

            // starts with 1 !!!
            for (int i = 1; i < Points.Count; i++)
            {
                var pen = new Pen(Points[i].Color);
                kresliciPlocha.DrawLine(pen, Points[i - 1].Point, Points[i].Point);
            }
        }

        private void colorBtn_Click(object sender, System.EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SelectedColor = colorDialog.Color;
            }
        }

        private class PointWithColor
        {
            public Point Point { get; set; }
            public Color Color { get; set; }
        }
    }
}

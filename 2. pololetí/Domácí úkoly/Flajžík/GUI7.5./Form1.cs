using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafikGUI
{
    public partial class Form1 : Form
    {
        byte shapeType;
        /* elipsa - 0
         * kružnice - 1
         * čtverec - 2*/
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            
        }

        byte colorValue()
        {
            /* bílá - 0
             * žlutá - 1
             * červená - 2
             * zelená - 3
             * modrá - 4
             * černá - 5
             */



            if (WH_radioButton.Checked)
            {
                return 0;

            }
            if (YE_RadioButton.Checked)
            {
                return 1;

            }
            if (RD_radioButton.Checked)
            {
                return 2;

            }
            if (GR_radioButton.Checked)
            {
                return 3;

            }
            if (BL_radioButton.Checked)
            {
                return 4;

            }
            if (BK_radioButton.Checked)
            {
                return 5;

            }
            // Když nic nevyberu, kreslím náhodnou barvou
            else

                return (byte)rnd.Next(0, 5);

        }
        private void elipsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 0;
            drwInf.Text = "Teď kreslíte elipsu.";
        }

        private void kružniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 1;
            drwInf.Text = "Teď kreslíte kružnici.";
        }

        private void čtverecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeType = 2;
            drwInf.Text = "Teď kreslíte čtverec.";
        }




        enum Colors
        {
            White,
            Yellow,
            Red,
            Green,
            Blue,
            Black

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            

            string colorName = Enum.GetName(typeof(Colors), colorValue());
            Color c = Color.FromName(colorName);

            float radius = (float)rnd.Next(10, 50);
            float XPos = (float)rnd.Next((int)radius, 720 - (int)radius);
            float YPos = (float)rnd.Next((int)radius, 540 - (int)radius);

            Pen pen = new Pen(c, penWidth.Value);
            switch (shapeType)
            {
                case 0:
                    g.DrawEllipse(pen, XPos, YPos, radius, 75 - radius);
                    break;
                case 1:
                    g.DrawEllipse(pen, XPos, YPos, radius, radius);
                    break;
                case 2:
                    g.DrawRectangle(pen, XPos, YPos, radius, radius);
                    break;
            }

        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
    
   
    

   
}

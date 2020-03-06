using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Projekt
{
    public partial class Level_2 : Form
    {
        public int speed_left = 5;
        public int speed_top = 3;
        public int points1 = 0;
        public int points2 = 0;
        

        public Level_2()
        {
            InitializeComponent();
            timer2.Enabled = true;


            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            palka1.Top = panel1.Bottom - (panel1.Bottom / 10);  //palka1 = hrac
            palka2.Top = panel1.Top - (panel1.Top / 10);        //palka2 = Bot

            gameover1.Left = (panel1.Width / 2) - (gameover1.Width / 2);    //gameover1 = prohra 
            gameover1.Top = (panel1.Height / 2) - (gameover1.Height / 2);
            gameover1.Visible = false;

            gameover2.Left = (panel1.Width / 2) - (gameover2.Width / 2);    //gamover2 = vyhra 
            gameover2.Top = (panel1.Height / 2) - (gameover2.Height / 2);
            gameover2.Visible = false;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            palka1.Left = Cursor.Position.X - (palka1.Width / 2); //ovladani palky1

            mic.Left += speed_left;
            mic.Top += speed_top;          
            if (mic.Bottom >= palka1.Top && mic.Bottom <= palka1.Bottom && mic.Left >= palka1.Left && mic.Right <= palka1.Right) // odrazeni o palku1
            {

                speed_top = -speed_top;
                points1 += 1;
                ScoreNum1.Text = points1.ToString();

                Random r = new Random();
                panel1.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
            }

            if (mic.Top <= palka2.Bottom && mic.Top >= palka2.Top && mic.Left >= palka2.Left && mic.Right <= palka2.Right) //odrazeni o palku2
            {
                points2 += 1;
                ScoreNum2.Text = points2.ToString();
                
                speed_top = -speed_top;

            }
                
                if (mic.Left <= panel1.Left) //odrazeni o strany
            {
                speed_left = -speed_left;
            }
            if (mic.Right >= panel1.Right)
            {
                speed_left = -speed_left;
            }
            if (mic.Top <= panel1.Top) //kdyz gameover
            {
                timer2.Enabled = false;
                gameover2.Visible = true;
                points1 += 1;
            }
            if (mic.Bottom >= panel1.Bottom) //kdyz gameover
            {
                timer2.Enabled = false;
                gameover1.Visible = true;
                points2 += 1;
            }
            if(mic.Location.X+(mic.Size.Width/2) > palka2.Location.X+(palka2.Size.Width/2)) //pohyb AI
            {
                palka2.Location = new Point(palka2.Left += 4);
            }
            if (mic.Location.X + (mic.Size.Width / 2) < palka2.Location.X + (palka2.Size.Width / 2))
            {
                palka2.Location = new Point(palka2.Left -= 4);
            }
            }


        private void Level_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            

            if (e.KeyCode == Keys.R)
            {
                mic.Top = 50;
                mic.Left = 50;
                speed_left = 4;
                speed_top = 4;
                timer2.Enabled = true;
                gameover1.Visible = false;
                gameover2.Visible = false;
                panel1.BackColor = Color.White;
            }
        }
    }
}

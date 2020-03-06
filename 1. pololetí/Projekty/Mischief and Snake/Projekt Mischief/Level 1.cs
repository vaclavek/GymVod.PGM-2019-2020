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
    public partial class Level_1 : Form
    {   //x je vlevo/vpravo, y je nahoru/dolu
        int pX = 290, pY = 205;    //startovací pozice hráče
        bool upPressed, downPressed, leftPressed, rightPressed;
        int[] entities = {200,50,20,20,6,6,  10,300,15,15,6,8,  150,150,20,20,10,10,    700,300,22,22,7,4, 400,320,15,15,10,1 }; //pole pro entity: 2 entity prodluž na 12 pozic, pro 3 na 18 pozic, .... Pozice po sobě jsou: (x, y, xSize, ySize, xMove, yMove)
        //note: Jestli chcete přehlednější pole, vytvořte tady pole pro každou entitu a ty pak postupně přidávejte do hlavního
        bool gameIsOver = false;
        bool paused = true; //hra začíná pauznuta

        

        public Level_1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.WindowState = FormWindowState.Normal;
            KeyPreview = true;
            gameover.Visible = false;
         
        }

        private void Level_1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.CadetBlue, pX, pY, 30, 30);
            for (int i = 0; i < entities.Length; i += 6)
            {
                g.FillEllipse(Brushes.Red, entities[i], entities[i+1], entities[i+2], entities[i+3]);
            }

        }


        private void Level_1_Load(object sender, EventArgs e)
        {
            enablePause();
            //CasMin = 0;
            //CasSek = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            //Detekce kolize pro kuličku, i->x i+1->y i+2->xSize i+3->ySize  hodnoty 30 pro hráče
            for (int i = 0; i < entities.Length; i += 6)
            {
                if (entities[i] < pX + 30 && entities[i] > pX && entities[i+1] < pY + 30 && entities[i+1] > pY)
                {
                    timer1.Stop();
                    gameover.Show();
                    gameIsOver = true;
                }
                if (entities[i] + entities[i+2] < pX + 30 && entities[i] + entities[i+2] > pX && entities[i+1] < pY + 30 && entities[i+1] > pY)
                {
                    timer1.Stop();
                    gameover.Show();
                    gameIsOver = true;
                }
                if (entities[i] < pX + 30 && entities[i] > pX && entities[i+1] + entities[i+3] < pY + 30 && entities[i+1] + entities[i+3] > pY)
                {
                    timer1.Stop();
                    gameover.Show();
                    gameIsOver = true;
                }
                if (entities[i] + entities[i+2] < pX + 30 && entities[i] + entities[i+2] > pX && entities[i+1] + entities[i+3] < pY + 30 && entities[i+1] + entities[i+3] > pY)
                {
                    timer1.Stop();
                    gameover.Show();
                    gameIsOver = true;
                }

                entities[i] += entities[i + 4];
                entities[i + 1] += entities[i + 5];

                if (entities[i + 1] + entities[i + 3] >= this.Height)
                {
                    entities[i + 5] = -entities[i + 5];
                }
                if (entities[i] + entities[i + 2] >= this.Width)
                {
                    entities[i + 4] = -entities[i + 4];
                }
                if (entities[i] <= 0)
                {
                    entities[i + 4] = -entities[i + 4];
                }
                if (entities[i + 1] <= 0)
                {
                    entities[i + 5] = -entities[i + 5];
                }
                

            }
            int pVX = 0, pVY = 0;
            //pod tímto-načítání kláves
            if (upPressed)
            {
                pVY -= 8;
            }
            if(downPressed)
            {
                pVY += 8;
            }
            if(rightPressed)
            {
                pVX += 8;
            }
            if(leftPressed)
            {
                pVX -= 8;
            }
            pX += pVX;
            pY += pVY;


            if(pX<0)
                { pX = 0; }
            if(pY<0)
                { pY = 0; }
            if(pY>this.Height-30)
                { pY = this.Height - 30; }
            if (pX > this.Width - 30)
                { pX = this.Width - 30;  }
            


            Refresh();
        }

        private void Level_1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape) this.Close();

            if (e.KeyCode == Keys.W || e.KeyCode==Keys.Up)
            {
                downPressed = false;
                leftPressed = false;
                rightPressed = false;
                upPressed = true;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                upPressed = false;
                downPressed = false;
                rightPressed = false;
                leftPressed = true;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                upPressed =false ;
                leftPressed =false ;
                rightPressed =false;
                downPressed = true; }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                upPressed = false;
                downPressed = false;
                leftPressed = false;
                rightPressed = true;
            }


            if (e.KeyCode==Keys.Space)
            {
                if (gameIsOver == false)
                {
                    enablePause();
                }
            }
            

       }
        //keydown- kulička akceleruje 20 ticků na max vx? Zkuste, bude nám driftovat :D
        private void enablePause()
        {
            if (paused ==false)
            {
                labelPause.Hide();
                timer1.Enabled = true;
                paused = true;

            }
            else
            {
                labelPause.Show();
                timer1.Enabled = false;
                paused = false;

            }







        }
       
    }
}

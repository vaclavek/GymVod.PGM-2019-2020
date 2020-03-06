using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;



namespace flappyBird
{

    public partial class Form1 : Form
    {

        // Hraje hudbu
        private SoundPlayer soundPlayer;
        

        bool smrt = true;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            timer2.Enabled = false;
        }
        private void startText_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            if (e.Button == MouseButtons.Left)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                startText.Visible = false;
            }
        }

        //náhodné číslo
        Random rnd = new Random();
        


        private void Form1_Load(object sender, EventArgs e)
        {

            gmoverText.Visible = false;

            
            startText.Visible = true;

        }
        




        private void timer1_Tick(object sender, EventArgs e)
        {

            int x = rnd.Next(50, 330);
            
            gmoverText.Visible = false;
            newGameText.Visible = false;
            if (pipe4.Left >= 0)
            {
                int speed = 30;
                if (score > 5)
                {
                    speed = speed + 20;
                }
                if (score > 25)
                {
                    speed = speed + 50;
                }
                pipe4.Left -= speed;
                pipe3.Left -= speed;


            }
            else
            {
                pipe4.Left += 1020;
                pipe4.Height = 280 - x;
                pipe3.Left += 1020;
                pipe3.Height = x;
                pipe4.Top = 441-pipe4.Height;
                score++;
            }

            if (pipe2.Left >= 0)
            {
                int speed = 30;
                if (score >5)
                {
                    speed = speed + 20;
                }
                if (score > 25)
                {
                    speed = speed + 50;
                }
                pipe1.Left -= speed;
                pipe2.Left -= speed;
              
            }
            else
            {
                pipe2.Left += 1020;
                pipe2.Height = 280 - x;
                pipe1.Left += 1020;
                pipe1.Height = x;
                pipe2.Top = 441 - pipe2.Height;
                score++;

            }
            
            EndGame();

            Skore.Text = score.ToString();


        }
        // Padání ptáka
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (bird.Top <= 366)
            {
                bird.Top += 10;
            }


        }
        // skákání 


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bird.Top -= 50;
                
            }
            else if (e.KeyCode == Keys.Enter && smrt == false)
            {
                
                
                Application.Restart();
            }
        }

        private void EndGame()
        {
            soundPlayer = new SoundPlayer("Roblox Death Sound - OOF Sound Effect.wav");
            if (bird.Bounds.IntersectsWith(pipe1.Bounds) || bird.Bounds.IntersectsWith(pipe2.Bounds) || bird.Top >= 366 || bird.Bottom < 107)
            {
                timer1.Stop();
                timer2.Stop();
                gmoverText.Text = "Vaše skore je: " + score;
                gmoverText.Visible = true;
                newGameText.Visible = true;

                smrt = false;
                soundPlayer.Play();
                


            }
            if (bird.Bounds.IntersectsWith(pipe3.Bounds) || bird.Bounds.IntersectsWith(pipe4.Bounds))
            {
                timer1.Stop();
                timer2.Stop();
                gmoverText.Text = "Vaše skore je:  " + score;
                gmoverText.Visible = true;
                newGameText.Visible = true;
                smrt = false;
                soundPlayer.Play();
            }

        }

        
    }
    }






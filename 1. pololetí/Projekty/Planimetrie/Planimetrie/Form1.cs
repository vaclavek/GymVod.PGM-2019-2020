using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planimetrie
{
    public partial class Form1 : Form
    {
        double? a;
        double? b;
        double? c;
        double? alfa;
        double? beta;
        double? gama;
        Point BodA;
        Point BodB;
        Point BodC;
        // ? umožní přiřadit do proměnné null
        bool platnyVypocet = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            platnyVypocet = false;
            try
            {
                ValidujAKonvertuj();
                HledaniVety();
                VypocetSouradnic(panelZobrazeni.Width, panelZobrazeni.Height, 10);
                platnyVypocet = true;
                tabControl1.SelectedTab = tabPage1;

                textBox1.AppendText("a = " + a.ToString() + "\r\n");
                textBox1.AppendText("b = " + b.ToString() + "\r\n");
                textBox1.AppendText("c = " + c.ToString() + "\r\n");
                textBox1.AppendText("alfa = " + alfa.ToString() + "\r\n");
                textBox1.AppendText("beta = " + beta.ToString() + "\r\n");
                textBox1.AppendText("gama = " + gama.ToString() + "\r\n");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                if(ex is System.OverflowException)
                {
                    s = "Zadaný trojúhelník nemá řešení!";
                }
                textBox1.AppendText("Něco se nepovedlo :(\r\n" + s);
                tabControl1.SelectedTab = tabPage2;
            }
            panelZobrazeni.Invalidate();
        }

        private double? ValidujAKonvertujTextBox(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return null;
            }

            double vysledek;
            bool PovedloSe = Double.TryParse(text, out vysledek);

            if (PovedloSe)
            {
                return vysledek;
            }

            throw new Exception("Chybný vstup!!! Jsi debil.");

        }

        private void ValidujAKonvertuj()
        {
            try
            {
                a = ValidujAKonvertujTextBox(StranaA.Text);
                b = ValidujAKonvertujTextBox(StranaB.Text);
                c = ValidujAKonvertujTextBox(StranaC.Text);
                alfa = ValidujAKonvertujTextBox(UhelAlfa.Text);
                beta = ValidujAKonvertujTextBox(UhelBeta.Text);
                gama = ValidujAKonvertujTextBox(UhelGama.Text);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private double RadToDeg (double uhel)
        {
            return uhel * 180 / Math.PI;
        }

        private double DegToRad (double uhel)
        {
            return uhel * Math.PI / 180;
        }

        private void HledaniVety()
        {
            //3 strany
            if (a != null && b != null && c != null)
            {
                VypocetTriStrany(a.Value, b.Value, c.Value, ref alfa, ref beta, ref gama);
            }
            //2 strany a úhel mezi
            else if (a != null && b != null && gama != null)
            {
                VypocetDveStranyAUhelMezi(a.Value, b.Value, ref c, ref alfa, ref beta, gama.Value);
            }
            else if (c != null && b != null && alfa != null)
            {
                VypocetDveStranyAUhelMezi(c.Value, b.Value, ref a, ref gama, ref beta, alfa.Value);
            }
            else if (a != null && c != null && beta != null)
            {
                VypocetDveStranyAUhelMezi(a.Value, c.Value, ref b, ref alfa, ref gama, beta.Value);
            }
            //2 strany a úhel vedle
            else if (a != null && b != null && alfa != null)
            {
                VypocetDveStranyAUhelVedle(a.Value, b.Value, ref c, alfa.Value, ref beta, ref gama);
            }
            else if (a != null && b != null && beta != null)
            {
                VypocetDveStranyAUhelVedle(b.Value, a.Value, ref c, beta.Value, ref alfa, ref gama);
            }
            else if (b != null && c != null && beta != null)
            {
                VypocetDveStranyAUhelVedle(b.Value, c.Value, ref a, beta.Value, ref gama, ref alfa);
            }
            else if (c != null && b != null && gama != null)
            {
                VypocetDveStranyAUhelVedle(c.Value, b.Value, ref a, gama.Value, ref beta, ref alfa);
            }
            else if (c != null && a != null && alfa != null)
            {
                VypocetDveStranyAUhelVedle(a.Value, c.Value, ref b, alfa.Value, ref gama, ref beta);
            }
            else if (a != null && c != null && gama != null)
            {
                VypocetDveStranyAUhelVedle(c.Value, a.Value, ref b, gama.Value, ref alfa, ref beta);
            }
            //2 úhly a strana mezi
            else if (a != null && beta != null && gama != null)
            {
                DvaUhlyAStranaMezi(a.Value, ref b, ref c, ref alfa, beta.Value, gama.Value);
            }
            else if (b != null && gama != null && alfa != null)
            {
                DvaUhlyAStranaMezi(b.Value, ref a, ref c, ref beta, alfa.Value, gama.Value);
            }
            else if (c != null && alfa != null && beta != null)
            {
                DvaUhlyAStranaMezi(c.Value, ref a, ref b, ref gama, alfa.Value, beta.Value);
            }
            //2 úhly a strana vedle
            else if (a != null && beta != null && alfa != null)
            {
                DvaUhlyAStranaVedle(a.Value, ref b, ref c, alfa.Value, beta.Value, ref gama);
            }
            else if (alfa != null && b != null && beta != null)
            {
                DvaUhlyAStranaVedle(b.Value, ref a, ref c, beta.Value, alfa.Value, ref gama);
            }
            else if (gama != null && c != null && beta != null)
            {
                DvaUhlyAStranaVedle(c.Value, ref b, ref a, gama.Value, beta.Value, ref alfa);
            }
            else if (b != null && beta != null && gama != null)
            {
                DvaUhlyAStranaVedle(b.Value, ref c, ref a, beta.Value, gama.Value, ref alfa);
            }
            else if (gama != null && a != null && alfa != null)
            {
                DvaUhlyAStranaVedle(a.Value, ref c, ref b, alfa.Value, gama.Value, ref beta);
            }
            else if (alfa != null && c != null && gama != null)
            {
                DvaUhlyAStranaVedle(c.Value, ref a, ref b, gama.Value, alfa.Value, ref beta);
;            }
            else
            {
                throw new Exception("Špatně zadané hodnoty!");
            }
        }

        private double CosinovaVetaUhel(double strana1, double strana2, double strana3)
        {
            return RadToDeg(Math.Acos((strana1 * strana1 + strana2 * strana2 - strana3 * strana3) / (2 * strana1 * strana2)));     
        }

        private double CosinovaVetaStrana(double strana1, double strana2, double uhel3)
        {
            return Math.Sqrt(strana1 * strana1 + strana2 * strana2 - 2 * strana1 * strana2 * Math.Cos(DegToRad(uhel3)));
        }

        //pocitam uhel od strana1
        //strana1 = a, strana2 = b, uhel2 = beta
        private double SinovaVetaUhel (double strana1, double strana2, double uhel2)
        {
            return RadToDeg(Math.Asin(Math.Sin(DegToRad(uhel2)) * strana1 / strana2));
        }

        private double SinovaVetaStrana (double strana2, double uhel1, double uhel2)
        {
            return strana2 * Math.Sin(DegToRad(uhel1)) / Math.Sin(DegToRad(uhel2));
        }

        private double TriUhly (double uhel1, double uhel2)
        {
            return 180 - uhel1 - uhel2;
        }

        private double ZkontrolujANastav(double? puvodni, double nova)
        {
            nova = Math.Round(nova, 2);
            if (puvodni == null)
            {
                return nova;
            }
            if (Math.Round(puvodni.Value, 2) == nova)
            {               
                return nova;
            }
            else
            {
                throw new Exception("Nekorespondující hodnoty!!");
            }
        }

        private void VypocetTriStrany(double a, double b, double c, 
            ref double? alfa, ref double? beta, ref double? gama)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new Exception("Neplatí trojúhelníková nerovnost!");
            }

            gama = ZkontrolujANastav(gama, CosinovaVetaUhel(a, b, c));
            beta = ZkontrolujANastav(beta, CosinovaVetaUhel(a, c, b));
            alfa = ZkontrolujANastav(alfa, CosinovaVetaUhel(b, c, a));

            if(!(gama.HasValue && beta.HasValue &&alfa.HasValue))
            {
                throw new Exception("Zadaný trojúhelník nemá řešení!");
            }
        } 

        private void VypocetDveStranyAUhelMezi (double a, double b, ref double? c, 
            ref double? alfa, ref double? beta, double gama)
        {
            if (gama >= 180)
            {
                throw new Exception("Špatný úhel!");
            }

            c = ZkontrolujANastav(c, CosinovaVetaStrana(a, b, gama));
            alfa = ZkontrolujANastav(alfa, CosinovaVetaUhel(b, c.Value, a));
            beta = ZkontrolujANastav(beta, CosinovaVetaUhel(a, c.Value, b));

            if (!(c.HasValue && beta.HasValue && alfa.HasValue))
            {
                throw new Exception("Zadaný trojúhelník nemá řešení!");
            }
        }

        private void VypocetDveStranyAUhelVedle (double a, double b, ref double? c, 
            double alfa, ref double? beta, ref double? gama)
        {
            if (alfa >= 180)
            {
                throw new Exception("Špatný úhel!!");
            }

            beta = ZkontrolujANastav(beta, SinovaVetaUhel(b, a, alfa));
            gama = ZkontrolujANastav(gama, TriUhly(alfa, beta.Value));
            c = ZkontrolujANastav(c, CosinovaVetaStrana(a, b, gama.Value));

            if (!(gama.HasValue && beta.HasValue && c.HasValue))
            {
                throw new Exception("Zadaný trojúhelník nemá řešení!");
            }
        }

        private void DvaUhlyAStranaMezi(double a, ref double? b, ref double? c, 
            ref double? alfa, double beta, double gama)
        {
            if (beta >= 180 || gama >= 180 || beta + gama >= 180)
            {
                throw new Exception("Špatně zadaný úhel!");
            }
            alfa = ZkontrolujANastav(alfa, TriUhly(beta, gama));
            b = ZkontrolujANastav(b, SinovaVetaStrana(a, beta, alfa.Value));
            c = ZkontrolujANastav(c, SinovaVetaStrana(a, gama, alfa.Value));

            if (!(c.HasValue && b.HasValue && alfa.HasValue))
            {
                throw new Exception("Zadaný trojúhelník nemá řešení!");
            }
        }

        private void DvaUhlyAStranaVedle(double a, ref double? b, ref double? c, 
            double alfa, double beta, ref double? gama)
        {
            if (alfa >= 180 || beta >= 180 || alfa + beta >= 180)
            {
                throw new Exception("Špatný úhel!!");
            }

            b = ZkontrolujANastav(b, SinovaVetaStrana(a, beta, alfa));
            gama = ZkontrolujANastav(gama, TriUhly(alfa, beta));
            c = ZkontrolujANastav(c, CosinovaVetaStrana(a, b.Value, gama.Value));

            if (!(gama.HasValue && b.HasValue && c.HasValue))
            {
                throw new Exception("Zadaný trojúhelník nemá řešení!");
            }
        }

        private void VypocetSouradnic(int sirka, int vyska, int okraj)
        {
            double vyskaTrojuhelniku = b.Value * Math.Sin(DegToRad(alfa.Value));
            double sirkaTrojuhelniku;
            double posunBoduA = 0;
            if (alfa <= 90 && beta <= 90)
            {
                sirkaTrojuhelniku = c.Value;
            }
            else if (alfa > 90)
            {
                sirkaTrojuhelniku = a.Value * Math.Cos(DegToRad(beta.Value));
                posunBoduA = sirkaTrojuhelniku - c.Value;
            }
            else
            {
                sirkaTrojuhelniku = b.Value * Math.Cos(DegToRad(alfa.Value));
            }

            double koefX = (sirka - 2 * okraj) / sirkaTrojuhelniku;
            double koefY = (vyska - 2 * okraj) / vyskaTrojuhelniku;
            double koef = Math.Min(koefX, koefY);

            BodA = new Point(Convert.ToInt32(posunBoduA * koef) + okraj, vyska - okraj);
            BodB = new Point(BodA.X + Convert.ToInt32(c.Value * koef), vyska - okraj);
            BodC = new Point(BodA.X + Convert.ToInt32(b.Value * koef * Math.Cos(DegToRad(alfa.Value))),
                BodA.Y - Convert.ToInt32(vyskaTrojuhelniku * koef));
            //souřadnice x
            /*
            textBox1.Text += "vyska trojuhelniku = " + vyskaTrojuhelniku.ToString() + "\r\n";
            textBox1.Text += "sirka trojuhelniku = " + sirkaTrojuhelniku.ToString() + "\r\n";
            textBox1.Text += "posun bodu A = " + posunBoduA.ToString() + "\r\n";
            textBox1.Text += "A = " + BodA.ToString() + "\r\n";
            textBox1.Text += "B = " + BodB.ToString() + "\r\n";
            textBox1.Text += "C = " + BodC.ToString() + "\r\n";
            */
        }

        private void PanelZobrazeni_Paint(object sender, PaintEventArgs e)
        {
            if (!platnyVypocet)
            {
                return;
            }
            var g = e.Graphics;
            var p = new Pen(Color.Black);

            g.DrawLine(p, BodA.X, BodA.Y, BodB.X, BodB.Y);
            g.DrawLine(p, BodB.X, BodB.Y, BodC.X, BodC.Y);
            g.DrawLine(p, BodA.X, BodA.Y, BodC.X, BodC.Y);
        }
    }
}

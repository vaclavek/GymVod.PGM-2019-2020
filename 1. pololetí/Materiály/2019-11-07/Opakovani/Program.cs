using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opakovani
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> cisla = new List<double>();
            cisla.Add(7.32);    // vloží prvek na konec
            cisla.Insert(0, 3); // vloží prvek na danou pozici (číslováno od nuly!)

            cisla.Add(2);
            cisla.Add(-7);
            cisla.Add(20145);
            cisla.Add(0);
            cisla.Add(777);

            cisla.Remove(7.32); // odebere prvek, který mu řekneme
            cisla.RemoveAt(1);  // odebere prvek na dané pozici (číslováno od nuly!)

            cisla.Clear();       // smaže všechny prvky
            double[] poleCisel = cisla.ToArray(); // převede List<> na pole

            List<double> druhyList = poleCisel.ToList();    // převede pole na List<>


            StringBuilder sb = new StringBuilder();
            for (int i = 97; i <= 122; i++)
            {
                char znak = (char)i;
                sb.Append(znak);
            }
            sb.Clear();

            for (char znak = (char)97; znak <= 122; znak++)
            {
                sb.Append(znak);
            }
            sb.Clear();

            for (char znak = 'a'; znak <= 'z'; znak++)
            {
                sb.Append(znak);

                // "Aktuálně generuji písmenko XXXXXX"
                sb.Append("Aktuálně generuji písmenko " + znak + "\n"); // špatné kvůli spojování stringů

                // lepší
                sb.Append("Aktuálně generuji písmenko ");
                sb.Append(znak);
                sb.Append("\n");

                // ještě lepší 
                sb.Append("Aktuálně generuji písmenko ");
                sb.Append(znak);
                sb.AppendLine();  // nový řádek nemusí být vždy jen \n, .NET se postará sám ...

                // ještě lepší
                sb.AppendFormat("Aktuálně generuji písmenko {0}", znak);
                sb.AppendLine();
                // ekvivalent to sb.AppendLine()
                sb.Append(Environment.NewLine);

                // nejlepší
                sb.AppendLine($"Aktuálně generuji písmenko {znak}");
            }
            sb.Clear();

            double pi = Math.PI;
            string piString2 = $"Pí na 2 desetinná místa je {pi:f2}";
            string piString3 = $"Pí na 3 desetinná místa je {pi:f3}";

            string piString2_stejne = string.Format("Pí na 2 desetinná místa je {0:f2}", pi);
            string piString3_stejne = string.Format("Pí na 3 desetinná místa je {0:f3}", pi);

            int cislo255 = 255;
            cislo255 = 0xFF;
            string textHexa = $"{cislo255:X}";

            sb.Clear();

            DateTime dnes = DateTime.Now;
            sb.Append("Dnes je ");
            sb.Append($"{dnes:F}");
            sb.Clear();

            sb.Append("Dnes je ");
            sb.Append(dnes.ToString("F"));
            sb.Clear();

            sb.Append("Today is ");
            sb.Append(dnes.ToString("F", System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            sb.Clear();

            sb.Append("Dnes je (zjednodušená čínština) ");
            sb.Append(dnes.ToString("F", System.Globalization.CultureInfo.GetCultureInfo("zh-CN")));

        }
    }
}

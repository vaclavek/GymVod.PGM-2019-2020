using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraceSeStringy
{
    class Program
    {
        static void Main(string[] args)
        {
            // PouzivaniStringBuilder();
            // DeklaracePole();
            // PouzivaniListu();
            // PraceSeSouborem();
            PraceSeStringem();

            Console.ReadKey();
        }

        static void PouzivaniStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ahoj");
            sb.Append(" světe");
            sb.Append(", jmenuji se");

            string text = sb.ToString();
            Console.WriteLine(text);
        }

        static void DeklaracePole()
        {
            int[] cisla = new int[10];
            for (int i = 0; i < 10; i++)
            {
                cisla[i] = (int)Math.Pow(3, i);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(cisla[i]);
            }

            if (System.IO.File.Exists("cisla.txt"))
            {
                System.IO.File.Delete("cisla.txt");
            }
            foreach (int cislo in cisla)
            {
                System.IO.File.AppendAllText("cisla.txt", cislo.ToString() + "\n");
            }
        }

        static void PouzivaniListu()
        {
            List<string> texty = new List<string>();
            while (true)
            {
                Console.Write("Napište jméno (nebo KONEC): ");
                string jmeno = Console.ReadLine();
                if (jmeno == "KONEC")
                {
                    break;
                }

                texty.Add(jmeno);
                // přidat do "pole" texty jméno, které uživatel zadal
            }

            int delkaPole = texty.Count;  // Zjistím délku pole

            int nahodneCislo = new Random().Next(0, delkaPole);
            Console.WriteLine(texty[nahodneCislo]);

            string[] textyJakoPole = texty.ToArray(); // převod na pole
        }

        static void PraceSeSouborem()
        {
            string[] obsahSouboru = System.IO.File.ReadAllLines(@"H:\Semin\CSH\_spol\vaclavek\2019-10-31\kalibrace_frekvence_data.txt");
            System.IO.File.WriteAllLines(@"C:\Temp\mojedata.txt", obsahSouboru);
        }

        static void PraceSeStringem()
        {
            string text = "Hello world!";
            char prvniZnak = text[0];   // přístup k řetězci jako ke znakům
            if (prvniZnak == 'A')
            {
                Console.WriteLine("Začátek abecedy.");
            }

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Text je prázdný");
            }

            string cislaSCarkou = "1,2,3,4,5,6";
            string[] poleCisel = cislaSCarkou.Split(',');

            string smezerami = " můj text s mezerami okolo \n\t";
            string bezmezer = smezerami.Trim(); // ořízne všechny bílé znaky

            string malymiPismeny = text.ToLower();
            string velkymiPismeny = text.ToUpper();

            string textMezi = text.Substring(3, 4);
            string formatovanyText = string.Format("Ahoj {0}, jmenuji se {1}, a je mi {2} let.",
                "počítači", "Ondra", 20);

        }
    }
}

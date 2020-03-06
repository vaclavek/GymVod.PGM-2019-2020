using Colorful;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace VanocniStromecek
{
    class Program
    {
        static void Main(string[] args)
        {
            string stromecek1 = System.IO.File.ReadAllText("stromecek.txt");
            string stromecek2 = System.IO.File.ReadAllText("stromecek2.txt");
            string stromecek3 = System.IO.File.ReadAllText("stromecek3.txt");
            string stromecek4 = System.IO.File.ReadAllText("stromecek4.txt");
            string[] stromecky = new string[4]
            {
                stromecek1,
                stromecek2,
                stromecek3,
                stromecek4
            };

            int poradi = 0;
            bool blika = false;
            while (true)
            {
                Console.Clear(); // vymazat obsah konzole

                // vypsat stromeček do konzole
                foreach (var znak in stromecky[poradi])
                {
                    Console.Write(znak, GetColor(znak, blika));
                }

                System.Threading.Thread.Sleep(1000); // 1 sekundu počkat
                blika = !blika;
                poradi++;
                if (poradi >= 4)
                {
                    poradi = 0;
                }
            }
        }

        private static Color GetColor(char znak, bool blika)
        {
            switch (znak)
            {
                case '/':
                case '\\':
                case '%':
                    return Color.Green;
                case '-':
                case '_':
                case 'I':
                    return Color.DarkGreen;
                case '|':
                    return Color.Brown;
                case 'o':
                case 'O':
                case 'X':
                    if (blika)
                    {
                        return Color.Yellow;
                    }
                    return Color.Red;
                case '*':
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }
    }
}

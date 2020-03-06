using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvocislo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napište číslo");
            string vstup;
            vstup = Console.ReadLine();

            int cislo;
            bool JeToCislo = int.TryParse(vstup, out cislo);
            if (!JeToCislo)
            {
                Console.WriteLine("Řikal jsem číslo!!");
                Console.ReadKey();
                return;
            }

            if (cislo < 0)
            {
                Console.WriteLine("Na záporný to nefunguje :(");
                Console.ReadKey();
                return;
            }

            int Delim = 2;
            for (int i = 2; i < cislo; i++)
            {
                if (cislo % i == 0)
                {
                    Console.WriteLine("Tohle není prvočíslo!! Je dělitelné " + Delim + ". A možná i něčím dalším :)");
                    Console.ReadKey();
                    return; 
                }
                Delim++;
            }

            Console.WriteLine("Je to prvočíslo!!");

            Console.ReadKey(); 
        }
    }
}

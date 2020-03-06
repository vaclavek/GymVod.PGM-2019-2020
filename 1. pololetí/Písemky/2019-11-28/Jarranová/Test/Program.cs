using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napiš číslo.");
            string cislouzivatele = Console.ReadLine();
            int cislo = Convert.ToInt32(cislouzivatele);

            Delitelnost(cislo);

            if (vysledek == 0)
            {
                Console.WriteLine("Tvé číslo není prvočíslo.");
            }
            else
            {
                Console.WriteLine("Tvé číslo je prvočíslo.");
            }
            

            Console.ReadKey();

        }
        static int Delitelnost(int cislo)
        {
            for (int i = 2; i < cislo; i++)
            {
                int vysledek = cislo % i;
            }
            return vysledek;
        }
    }
}

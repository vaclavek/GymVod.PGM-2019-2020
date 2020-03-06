using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvadratickaRovnice
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = NactiCislo("a");
            int b = NactiCislo("b");
            int c = NactiCislo("c");

            int diskriminant = b * b - 4 * a * c;
            if (diskriminant < 0)
            {
                Console.WriteLine("Rovnice nemá řešení v reálných číslech");
                return;
            }

            if (diskriminant == 0)
            {
                double x = (-b + Math.Sqrt(diskriminant)) / 2 * a;
                Console.WriteLine("Rovnice má jeden dvojnásobný kořen " + x);
                ZkontrolujKoren(a, b, c, x);
                return;
            }
            double x1 = (-b + Math.Sqrt(diskriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(diskriminant)) / (2 * a);

            Console.WriteLine("Rovnice má dva kořeny {0} a {1} ", x1, x2);
            ZkontrolujKoren(a, b, c, x1);
            ZkontrolujKoren(a, b, c, x2);

            Console.ReadLine();
        }

        static void ZkontrolujKoren(int a, int b, int c, double x = 7)
        {
            double vysledek1 = a * x * x + b * x + c;
            if (Math.Abs(vysledek1) < 0.0000000000000000000000001)
            {
                Console.WriteLine("Kořen je správně!");
            }
            else
            {
                Console.WriteLine("Někde je chyba!");
            }
        }

        static int NactiCislo(string jmeno)
        {
            Console.WriteLine("Zadej " + jmeno + ":");

            int cislo;
            string vstup = Console.ReadLine();
            bool jeCislo = int.TryParse(vstup, out cislo);

            while (!jeCislo)
            {
                Console.WriteLine("Toto není číslo!");

                vstup = Console.ReadLine();
                jeCislo = int.TryParse(vstup, out cislo);
            }

            return cislo;
        }
    }
}

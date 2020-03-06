using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napiš číslo a já zjistím jestli je to prvočíslo:");
            int vstup = int.Parse(Console.ReadLine());
            Prvocislo(vstup);
            if (Prvocislo(vstup)==true)
            {
                Console.WriteLine("Číslo je prvočíslo");
            }
            else if (Prvocislo(vstup) == false)
            {
                Console.WriteLine("Číslo není prvočíslo");
            }
           
            Console.ReadKey();
        }

        static bool Prvocislo(int cislo)

        {
            int vysledek = cislo % 2;

            if (vysledek != 0)
            {

                return true;
            }
            else return false;
        }
    }
}

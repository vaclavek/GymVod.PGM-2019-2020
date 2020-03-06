using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testprvocislo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej celé číslo:");
            int cislo = int.Parse(Console.ReadLine());
            int vysledek = JePrvocislo(cislo);
            if (vysledek == 0) Console.WriteLine("Toto není prvočíslo");
            else
                Console.WriteLine("Toto je prvočíslo");


        }
        static int JePrvocislo(int x)
        {
            

            if (x == 1) return 1;
            
            for(int i = 2;i<=Math.Sqrt(x);i++)
            {
                if (x % i == 0) return 0;                    
            }
            return x;
        }
    }
}

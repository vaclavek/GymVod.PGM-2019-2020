using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekurze
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            for (int i = 0; i < 10; i++)
            {

            }

            bool jeSplneno = true;
            while (jeSplneno)
            {
                // sdfsd
            }

            do
            {

            } while (jeSplneno);


            var collection = new List<int>();
            foreach (var item in collection)
            {

            }

            var cislo = 5;
            var text = "ahoj";
            var objekt = new object();
            var pismeno = 'X';
            var datum = new DateTime();
            */
            //int cisloPet = VratCislo(5);
            //ulong faktorial = Faktorial(7);
            Console.WriteLine(Euler(1, 4));
            Console.ReadLine();
        }

        static int VratCislo(int n)
        {
            if (n == 10)
            {
                return 3;
            }
            return VratCislo(n + 1);
        }

        // n! = n * (n - 1)!
        static ulong Faktorial(ulong n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Faktorial(n - 1);
        }

        static uint SumaN3Suda(uint n)
        {
            if (n % 2 == 1)
                return 0;
            if (n == 0)
                return 0;
            else
                return (uint)Math.Pow(n, 3) + SumaN3Suda(n - 2);
        }

        // x = Suma od 1 do n ( n^3)
        static uint SumaN3(uint n)
        {
            if (n == 0)
                return 0;
            else
                return (uint)Math.Pow(n, 3) + SumaN3(n - 1);
        }

        static double Euler(double x, int n)
        {
            if (n == 0)
            {
                return x;
            }
            double aktualniPrvek = Math.Pow(x, n) / Faktorial((uint)n);
            double predchoziPrvek = Euler(x, n - 1);
            return aktualniPrvek + predchoziPrvek;
        }
    }
}

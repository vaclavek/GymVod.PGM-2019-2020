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
            while (true)
            {
                Console.WriteLine("Napiš číslo");

                long n;

                while (!long.TryParse(Console.ReadLine(), out n))
                    Console.WriteLine("Koni!");
                
                var passed = true;

                for(int i = 2; i <= n / 2; i++)
                {
                    if (n % i == 0)
                    {
                        passed = false;
                        break;
                    }
                }

                Console.WriteLine($"{(passed ? "Je" : "Není")} to prvočíslo");
                Console.WriteLine("[Enter] = další číslo [cokoliv] = odchod");

                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
        }
    }
}

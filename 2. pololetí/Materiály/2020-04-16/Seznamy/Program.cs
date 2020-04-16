using System;
using System.Collections.Generic;
namespace Seznamy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Obsah C: ");
            Random rand = new Random();

            int[] c = new int[50];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = rand.Next(1, 50);
                Console.Write(c[i] + " ");
            }

            List<int> p = new List<int>();
            int sp = 0, sc = 0;

            Console.WriteLine("Obsah P:  ");
            foreach (int cislo in c)
            {
                if (JePrvocislo(cislo))
                {
                    p.Add(cislo);
                    Console.Write(cislo + " ");
                    sp += cislo;
                }
                sc += cislo;
            }

            int[] pList = p.ToArray(); // ukázka, jak převést List na pole
            Console.WriteLine(" ");
            Console.WriteLine("SP je: " + sp);
            Console.WriteLine("SC je: " + sc);

        }

        private static bool JePrvocislo(int c)
        {
            bool promenna = true;
            if (c <= 1)
            {
                return false;
            }
            for (int i = 2; i <= c / 2; i++)
            {
                if (c % i == 0)
                {
                    promenna = false;
                    break;
                }
            }
            return promenna;
        }
    }
}

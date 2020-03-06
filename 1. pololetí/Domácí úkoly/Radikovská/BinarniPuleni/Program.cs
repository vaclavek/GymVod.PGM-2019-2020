using System;

namespace BinarniPuleni
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 100;
            int min = 0;
            Console.WriteLine("Mysli si číslo od " + min + " do " + max);
            max++;
            int hadam = 0;

            while (true)
            {
                int OldHadam = hadam;
                hadam = (max + min) / 2;
                if (OldHadam == hadam)
                {
                    Console.WriteLine("Kecáš mi, nemluvim s tebou");
                    break;
                }
                Console.WriteLine("Já si myslim " + hadam + ". Co ty na to? (< > ok)");
                string odpoved = Console.ReadLine();
                if (odpoved == ">")
                {
                    min = hadam;
                }
                else if (odpoved == "<")
                {
                    max = hadam;
                }
                else if (odpoved.ToUpper() == "OK")
                {
                    Console.WriteLine("Hádané číslo je " + hadam);
                    break;
                }
                else
                {
                    Console.WriteLine("Já nemluvit tvou řecí");
                    break;
                }
            }

            Console.ReadKey();

        }
    }
}

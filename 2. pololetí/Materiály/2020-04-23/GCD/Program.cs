using System;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "sdfsdf" + uint.MaxValue + "xcvxvcx" + 6 + "sdfsdf";
            //string b = string.Format("sdfsdf{0}xcvxvcx{1}sdfsdf", uint.MaxValue, 6);
            //string c = $"sdfsdf{uint.MaxValue}xcvxvcx{6}sdfsdf";

            Console.WriteLine($"Zadej celá čísla X a Y v intervalu <1, {uint.MinValue}>. Já spočítám největšího společného dělitele a jejich počet.");
            string x = Console.ReadLine();
            string y = Console.ReadLine();

            if (!uint.TryParse(x, out uint xCislo))
            {
                Console.WriteLine("X není číslo.");
                return;
            }

            if (!uint.TryParse(y, out uint yCislo))
            {
                Console.WriteLine("Y není číslo.");
                return;
            }

            if (xCislo <= 0)
            {
                Console.WriteLine("X není kladné číslo.");
                return;
            }

            if (yCislo <= 0)
            {
                Console.WriteLine("Y není kladné číslo.");
                return;
            }

            Console.WriteLine("X i Y jsou kladná celá čísla INT.");

            uint mensi = Math.Min(xCislo, yCislo);
            uint nejvetsiSpolecnyDelitel = 0;
            int pocetSpolecnychDelitelu = 0;
            for (uint i = mensi; i >= 1; i--)
            {
                if (xCislo % i == 0 && yCislo % i == 0)
                {
                    pocetSpolecnychDelitelu++;
                    if (nejvetsiSpolecnyDelitel == 0)
                    {
                        nejvetsiSpolecnyDelitel = i;
                    }
                }
            }

            Console.WriteLine($"Největší společný dělitel X a Y je {nejvetsiSpolecnyDelitel}.");
            Console.WriteLine($"Počet je {pocetSpolecnychDelitelu}.");
        }
    }
}

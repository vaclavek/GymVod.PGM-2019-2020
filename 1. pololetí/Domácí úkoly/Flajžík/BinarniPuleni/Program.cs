using System;

namespace BinarniPuleni
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte číslo, které chcete, aby počítač uhodl");
            int cislo;
            string vstup = Console.ReadLine();
            bool jeCislo = int.TryParse(vstup, out cislo);

            while (!jeCislo && (cislo < 1) && (cislo > 100))
            {
                Console.WriteLine("Nezadal jste číslo, nebo jste zadal číslo, které neleží v intervalu 1-100");

                vstup = Console.ReadLine();
                jeCislo = int.TryParse(vstup, out cislo);
            }
            if (cislo > 1 && cislo < 100)
            {
                Hadani(cislo);
            }

            Console.ReadKey();


        }
        static void Hadani(int cislo)
        {
            int min = 1;
            int max = 100;
            int pulka = 50;

            while (pulka != cislo)
            {
                Console.WriteLine("Počítač hádá:" + pulka);
                pulka = (min + max) / 2;


                if (pulka > cislo)
                {
                    max = pulka;
                }
                else if (pulka < cislo)
                {
                    min = pulka + 1;
                }

            }
            Console.WriteLine("Počítač uhádl, je  to číslo: " + pulka);



        }
    }
}

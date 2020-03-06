using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvocislo_OB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hledač prvočísel");
            string confirmer= "Y";
            while (confirmer!="n")
            {
                HlavniCast();
                Console.WriteLine("Přejete si ukončit program? Napište 'n' pro ukončení, cokoliv jiného pro pokračování");
                confirmer = Console.ReadLine();
                confirmer.ToLower();
            }
            Console.WriteLine("Ukončuji program. Zmáčkni tlačítko pro ukončení");


        }

        private static void HlavniCast()
        {
            int cislo;
            bool jeCislo;
            string vstup;
            do
            {
                Console.WriteLine("Zadej číslo");

                vstup = Console.ReadLine();
                jeCislo = int.TryParse(vstup, out cislo);
                if (jeCislo == false)
                {
                    Console.WriteLine("POZOR, není číslem. Piš číslo!");
                }
            }
            while (jeCislo == false);
            bool delitelne = false;
            int maxDelit = cislo / 2;
            for (int i = maxDelit; i >= 2; i--)
            {
                if (cislo % i == 0)
                {
                    Console.WriteLine("Dělitelné číslem : " + i);
                    delitelne = true;

                }

            }
            if (delitelne == true)
            {
                Console.WriteLine("Číslo je dělitelné čísly nad tímto textem");
            }
            else
            {
                Console.WriteLine("Číslo je prvočíslem");
            }
            Console.ReadKey();
        }
    }
}

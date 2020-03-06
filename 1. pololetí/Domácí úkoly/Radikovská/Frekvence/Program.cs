using System;
using System.Collections.Generic;

namespace Frekvence
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] DataZeSouboru =
            System.IO.File.ReadAllLines(@"c:\SVN\Jinsoft\GIT\GymVod\_DU\kalibrace_frekvence_data.txt");
            //ReadAllLines ukládá do pole
            //ReadAllText ukládá do stringu
            int vysledek = 0;
            int PocetOpakovani = 1;
            List<int> soucty = new List<int>();
            int vysledekDvakrat = 0;
            while (vysledekDvakrat == 0)
            {
                foreach (string cislo in DataZeSouboru)
                {
                    int cisloInt = Convert.ToInt32(cislo);
                    vysledek = vysledek + cisloInt;
                    //hledá stejný číslo
                    if (soucty.Contains(vysledek))
                    {
                        vysledekDvakrat = vysledek;
                        break;
                    }
                    else
                    {
                        soucty.Add(vysledek);
                    }
                }
                if (PocetOpakovani == 1)
                {
                    Console.WriteLine("Výsledke je " + vysledek);
                }
                PocetOpakovani++;
            }
            Console.WriteLine(PocetOpakovani);
            Console.WriteLine(vysledekDvakrat);
            Console.ReadKey();
        }
    }
}

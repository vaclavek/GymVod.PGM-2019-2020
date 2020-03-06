using System;
using System.Collections.Generic;

namespace OOP_Zaklady
{
    class Program
    {
        static void Main(string[] args)
        {
            Clovek pepa = new Clovek(new DateTime(1990, 5, 3), "Pepa", true, false);
            pepa.Skoc();
            pepa.Napis("Ahoj!");
            string pepyJmeno = pepa.JakSeJmenujes();
            Console.WriteLine("jméno: " + pepyJmeno);
            Console.WriteLine(pepa.Vek);
            Console.WriteLine("------------------------");

            Ucitel anna = new Ucitel(new DateTime(2002, 3, 7), "Anna");
            Console.WriteLine(anna.JakSeJmenujes());
            Console.WriteLine(anna.Vek);
            Console.WriteLine("------------------------");

            Programator franta = new Programator(new DateTime(2004, 12, 12), "Franta");
            Console.WriteLine("Jméno: " + franta.JakSeJmenujes());
            Console.WriteLine("Věk: " + franta.Vek);
            Console.WriteLine("Je učitel: " + franta.JeUcitel);
            Console.WriteLine("Je programátor: " + franta.JeProgramator);
            Console.WriteLine("------------------------");

            List<Clovek> seznamLidiNaPles = new List<Clovek>();
            seznamLidiNaPles.Add(pepa);
            seznamLidiNaPles.Add(anna);
            seznamLidiNaPles.Add(franta);

            foreach (var clovekNaPlese in seznamLidiNaPles)
            {
                clovekNaPlese.Skoc();
            }
        }
    }
}

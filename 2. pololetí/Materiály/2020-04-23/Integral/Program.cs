using System;

namespace Integral
{
    class Program
    {
        static void Main(string[] args)
        {
            // Spočítejte určitý integrál funkce cos (x) na intervalu <a, b>, kde hodnoty a a b zadá uživatel. 
            // Jak lze upravit přesnost?
            Console.WriteLine("Aplikace spočítá určitý integrál funkce cos(x) na intervalu <a, b> s přesností p, kterou zadáte.");
            Console.Write("Zadejte a: ");
            string aInput = Console.ReadLine();

            Console.Write("Zadejte b: ");
            string bInput = Console.ReadLine();

            Console.Write("Zadejte p: ");
            string pInput = Console.ReadLine();

            double a, b;

            if (aInput.Equals("pi", StringComparison.InvariantCulture))
            {
                a = Math.PI;
            }
            else
            {
                if (!double.TryParse(aInput, out a))
                {
                    Console.WriteLine("a není desetinné číslo.");
                    return;
                }
            }

            if (bInput.Equals("pi", StringComparison.InvariantCultureIgnoreCase))
            {
                b = Math.PI;
            }
            else
            {
                if (!double.TryParse(bInput, out b))
                {
                    Console.WriteLine("b není desetinné číslo.");
                    return;
                }
            }

            if (!ulong.TryParse(pInput, out ulong pocetKroku))
            {
                Console.WriteLine("p není nezáporné číslo.");
                return;
            }

            if (pocetKroku == 0)
            {
                Console.WriteLine("p musí být kladné číslo.");
                return;
            }

            double vysledek = 0;
            double velikostDilku = (b - a) / pocetKroku;

            for (double i = a; i < b; i += velikostDilku)
            {
                double spodniSoucet = Math.Cos(i) * velikostDilku;
                double horniSoucet = Math.Cos(i + velikostDilku) * velikostDilku;

                vysledek += (spodniSoucet + horniSoucet) / 2;
            }

            Console.WriteLine($"Integrál je {vysledek:N2}");
        }
    }
}

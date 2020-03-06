using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvodDatoveTypy
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo = 5;
            string retezec = "text";
            float desetinnecislo;

            // následující řádky jsou stejné
            cislo++;
            cislo += 1;
            cislo = cislo + 1;  // Do proměnné cislo přiřadím hodnotu, 
                                // která je v proměnné cislo a přičtu 1

            cislo--;

            Console.WriteLine("Hodnota proměnné cislo je " + cislo);
            Console.Write("Zadejte STEJNÉ číslo: ");

            string vstupOdUzivatele = Console.ReadLine();

            int petka = 5;
            int sedmicka = 7;
            bool petkaJeSedmicka = (petka == sedmicka);
            bool petkaNeniSedmicka = (petka != sedmicka);

            Console.WriteLine("Petka je sedmicka? " + petkaJeSedmicka);
            Console.WriteLine("Petka neni sedmicka? " + petkaNeniSedmicka);

            /*
             více
             řádkový 
             komentář
            */
            int vstupOdUzivateleJakoCislo;
            bool jeVstupCislo = int.TryParse(vstupOdUzivatele, out vstupOdUzivateleJakoCislo);
            if (!jeVstupCislo)
            {
                Console.WriteLine("Úplně špatně! Měl jsi zadat číslo!");
                Console.ReadLine();
                return;
            }

            if (cislo != vstupOdUzivateleJakoCislo)
            {
                Console.WriteLine("Špatně! Měl jsi zadat STEJNÉ číslo.");
            }
            else
            {
                Console.WriteLine("SUPER!");
            }

            Console.Write("Zadej datum narození: ");
            string vstupDatumNarozeni = Console.ReadLine();

            DateTime datumNarozeni;
            bool jeVstupDatumNarozeniDatum = DateTime.TryParse(vstupDatumNarozeni, out datumNarozeni);
            if (!jeVstupDatumNarozeniDatum)
            {
                Console.WriteLine("Špatně! Nezadal jsi datum.");
                Console.ReadLine();
                return;
            }

            DateTime aktualniDatum = DateTime.Today;
            var vekVeDnech = aktualniDatum.Subtract(datumNarozeni).TotalDays;
            Console.WriteLine("Je ti " + vekVeDnech + " dnů");

            Console.WriteLine("Je ti " + Math.Floor(vekVeDnech / 365) + " let");

            Console.ReadLine();
        }
    }
}

using System;

namespace BinarniPuleni
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mysli si celé číslo od 0 do 100. Já ho budu hádat.");

            int mensi = 0;
            int vetsi = 101;
            int uprostred;
            uprostred = (mensi + vetsi) / 2;

            Console.WriteLine("Je to číslo " + uprostred + "?");
            int pocetpokusu = 1;
            
            while(true) // smyčka je ukončená příkazem break
            {
                Console.WriteLine("Napiš MENSI, VETSI nebo ANO.");

                string oduzivatele = Console.ReadLine();
                if (oduzivatele == "MENSI")
                {
                    vetsi = uprostred;
                    uprostred = (mensi + vetsi) / 2;
                    pocetpokusu++;
                    Console.WriteLine("Je to číslo " + uprostred + "?");
                }
                else if (oduzivatele == "VETSI")
                {
                    mensi = uprostred;
                    uprostred = (mensi + vetsi) / 2;
                    pocetpokusu++;
                    Console.WriteLine("Je to číslo " + uprostred + "?");
                }
                else if (oduzivatele == "ANO")
                {
                    Console.WriteLine("Trefa, uhodl jsem to. Číslo je " + uprostred + " a trvalo mi to " + pocetpokusu + " pokusů.");
                    break;
                }
                else
                {
                    Console.WriteLine("Nepiš nesmysly.");
                }
            }

            Console.ReadKey();

        }

    }
}

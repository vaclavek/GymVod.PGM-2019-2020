using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciselne_Soustavy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {
                Console.WriteLine("Teď převedeme desítkovou soustavu na dvojkovou, zadejte desítkové číslo: ");
                string vstup = Console.ReadLine();
                int cislo;
                bool jeCislo = int.TryParse(vstup, out cislo);


                while (!jeCislo)
                {
                    Console.WriteLine("Toto není validní číslo, Zkuste to znovu");
                    vstup = Console.ReadLine();
                    jeCislo = int.TryParse(vstup, out cislo);

                }

                Prevedeni1 (cislo);
                Console.WriteLine("Teď převedeme číslo z dvojkové do desítkové:");
                string vstup2 = Console.ReadLine();

                Prevedeni2(vstup2);
                

                Console.ReadKey();
            }

             void Prevedeni1 (int cislo)
             {
                string vysledek;
                vysledek = null;

                while (cislo  > 1)
                {
                     
                    
                    int zbytek = cislo % 2;

                    vysledek =  zbytek.ToString() + vysledek;
                     cislo = cislo/ 2;
                    //Console.Write(vysledek);


                }

                vysledek = cislo.ToString() + vysledek;
                Console.WriteLine("Vaše číslo v binární soustavě: " + vysledek);
             }

            void Prevedeni2(string vstup2)
            {
                int cislo2 = int.Parse(vstup2);

                int desitkovecislo =0 ;
                int prvninasobek = 1;// 2**0


               while(cislo2 > 0)
                {
                    int zbytek = cislo2 % 10;
                    desitkovecislo += zbytek * prvninasobek;
                    prvninasobek = prvninasobek * 2;
                   cislo2 =  cislo2 / 10;


                }
                //Console.Write(desitkovecislo);

                Console.WriteLine("Vaše číslo v desítkové soustavě je:  " + desitkovecislo);
                
                    
            }

        }
    }
}

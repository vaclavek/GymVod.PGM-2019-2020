using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPrvocisla
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte vaše číslo, u kterého chcete určit, zda je prvočíslo:");

            string vstup = Console.ReadLine();
            int cislo;
            bool jeCislo = Int32.TryParse(vstup, out cislo);
            // ověří, že uživatel zadal číslo
            while(!jeCislo)
            {
                Console.WriteLine("Nezadal jste číslo");
                vstup = Console.ReadLine();
                jeCislo = Int32.TryParse(vstup, out cislo);


            }

            Prvocislo(cislo);
            


            Console.ReadKey();

        }

        static void Prvocislo(int cislo)
        {
            
            for(int i = 2; i < cislo; i++)
            {
                int vysledek = cislo % i;
                Console.WriteLine(vysledek);
                if(vysledek == 0)
                {
                    Console.WriteLine("Číslo není prvočíslo"); break;
                }
                
                else
                {
                    Console.WriteLine("Číslo je prvočíslo");
                    
                }
              
            }
            


        }


    }
}

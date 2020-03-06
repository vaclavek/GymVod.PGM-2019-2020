using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadejte přirozené číslo: ");
            uint cislo;
            while (!uint.TryParse(Console.ReadLine(), out cislo) || cislo == 0)
                Console.Write("Chyba - zadejte prosím PŘIROZENÉ ČÍSLO: ");
            
            int pocetDelitelu = 0;

            for(int i = 1; i <= cislo; i++)
            {
                if (cislo % i == 0)
                    pocetDelitelu++;
            }

            if (pocetDelitelu != 2) // prvocislo ma prave 2 delitele - 1 a samo sebe
                Console.WriteLine("Nejedná se o prvočíslo - číslo {0} je dělitelné {1} přirozenými čísly.", cislo, pocetDelitelu);
            else
                Console.WriteLine("Jedná se o prvočíslo - číslo {0} je dělitelné pouze jedničkou a samo sebou.", cislo);
            Console.ReadKey();
        }
    }
}

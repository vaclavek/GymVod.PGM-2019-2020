using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matice1 = new int[3,3];
            int[,] matice2 = new int[3,3];

            // Přiřadí náhodná čísla 0-10 do matic, které se se vynásobí:
          

            Random random = new Random();

            Console.WriteLine("První matice: ");

            for(int i = 0; i < matice1.GetLength(0); i++)
            {
                for(int j = 0; j< matice1.GetLength(1); j++)
                {
                    matice1[i, j] = random.Next(1, 10);

                    matice1[i, j].ToString();
                   Console.Write(matice1[i, j] + " ");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("Druhá matice: ");

            for(int i = 0; i <matice2.GetLength(0); i++)
            {
                for(int j = 0; j < matice2.GetLength(1); j++)
                {
                    matice2[i, j] = random.Next(1, 10);

                    matice2[i, j].ToString();
                    Console.Write(matice2[i, j]+" ");

                }
                Console.WriteLine(" ");
            }
            
             // Výsledná matice:
            int[,] vysledek = new int[3, 3];

            Console.WriteLine("Výsledná matice: ");
            for (int i = 0; i < matice1.GetLength(0); i++)
            {
                for (int j = 0; j < matice1.GetLength(1); j++)
                {
                    vysledek[i, j] = matice1[i,j] * matice2[i,j];
                    vysledek[i, j].ToString();

                   
                    Console.Write(vysledek[i, j]+" ");
                }
                Console.WriteLine(" ");
            }

              Console.ReadKey();
          }
     }


}

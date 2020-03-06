using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasobeniMatic
{
    class Program
    {
        static void Main(string[] args)
        {
            var matice1 = new int[2, 3];
            var matice2 = new int[3, 2];

            NaplnMatici(matice1);
            NaplnMatici(matice2);
            Console.Write("Matice 1: ");
            vypisMatice(matice1);
            Console.Write("Matice 2. ");
            vypisMatice(matice2);
            var maticeVysledek = NasobMatice(matice1, matice2);
            vypisMatice(maticeVysledek);

            Console.Write()

        }

        static void  NaplnMatici(int [,] matice)
        {
            for (int x = 0; x < matice.GetLength(0); x++)
            {
                for(int y = 0; y < matice.GetLength(1); y++)
                {
                    matice[x, y] = rnd.Next(-10, 11);
                }
            }
        }

        static int[,] NasobMatice(int [,] matice1, int[,] matice2)
        {
            if (matice1.GetLength(1) != matice2.GetLength(0))
                throw new Exception("Matice nelze vynásobit: počet řádků matice neodpovídá počtu sloupců druhé matice.");
                var maticeVysledek = new int[2, 2];
                {
                    for (int x = 0; x < matice1.GetLength(0); x++)
                    {
                        for (int y = 0;  y < matice1.GetLength(0); y++)
                        {
                            maticeVysledek[x, y] = SpoctiPrvekMatice(matice1, matice2, x, y);
                        }
                    }
                }
            return maticeVysledek;
        }

        static int SpoctiPrvekMatice(int[,] matice1, int[,] matice2, int x, int y)
        {
            int scitani = 0;
            for(int k = 0; k < matice1.GetLength(1); k++)
            {//k, sloupec, se mění!
                scitani += matice1[x, k] * matice2[k, y];
            }
            return scitani;
        }

        static void vypisMatice(int[,] matice)
        {
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                for (int j = 0; j < matice.GetLength(0); j++)
                {
                    Console.WriteLine();
                }
            }
        }

        }
    }
}

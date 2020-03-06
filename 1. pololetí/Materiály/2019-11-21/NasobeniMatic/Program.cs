using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasobeniMatic
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            var matice1 = new int[2, 3];
            var matice2 = new int[3, 2];

            ZadejMatici(matice1);
            //NaplnMatici(matice1);
            NaplnMatici(matice2);
            //ZadejMatici(matice2);
            Console.WriteLine("Matice 1: ");
            VypisMatici(matice1);
            Console.WriteLine("Matice 2: ");
            VypisMatici(matice2);
            var maticeVysledek = NasobMatice(matice1, matice2);

            Console.WriteLine("Matice 1 x Matice 2: ");
            VypisMatici(maticeVysledek);
        }

        static void ZadejMatici(int[,] matice)
        {
            Console.WriteLine("Zadej do konzole matice: ");
            for (int x = 0; x < matice.GetLength(0); x++)
            {
                for (int y = 0; y < matice.GetLength(1); y++)
                {
                    string vstup = Console.ReadLine();
                    int cislo = int.Parse(vstup);
                    matice[x, y] = cislo;
                    
                }
            }
        }

        static void NaplnMatici(int[,] matice)
        {
            for (int x = 0; x < matice.GetLength(0); x++)
            {
                for (int y = 0; y < matice.GetLength(1); y++)
                {
                    matice[x, y] = rnd.Next(-10, 11);
                }
            }
        }

        static int[,] NasobMatice(int[,] matice1, int[,] matice2)
        {
            if (matice1.GetLength(1) != matice2.GetLength(0))
                throw new Exception("Matice nelze vynásobit: počet řádků první matice neodpovídá počtu sloupců druhé matice.");
            var vysledek = new int[2, 2];

            for (int x = 0; x < matice1.GetLength(0); x++)
            {
                for (int y = 0; y < matice1.GetLength(0); y++)
                {
                    vysledek[x, y] = SpoctiPrvekMatice(matice1, matice2, x, y);

                }
            }
            return vysledek;

        }
        static int SpoctiPrvekMatice(int[,] matice1, int[,] matice2, int x, int y)
        {
            int scitani = 0;
            for (int k = 0; k < matice1.GetLength(1); k++)
            {
                scitani += matice1[x, k] * matice2[k, y];
            }
            return scitani;
        }

        static void VypisMatici(int[,] matice)
        {
            for(int i = 0; i < matice.GetLength(0); i++)
            {
                for(int j = 0; j < matice.GetLength(1); j++)
                {
                    Console.Write(matice[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

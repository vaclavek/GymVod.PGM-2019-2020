
using System;
using System.Collections.Generic;

namespace MaticeVMatice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[,] maticeVMatice =
            {
                {1, 2, 0},
                {3, 5, 6},
                {7, 0, 1}
            };

            int[,] maticeJenTak =
            {
                {3, 5},
                {1, 11},
                {2, 3},
                {7, 9}
            };

            int[,] maticeMimoMatiku =
            {
                {3, 5, 1},
                {6, 5, 6},
                {0, 9, 0}
            };

            int[,] maticeVsude =
            {
                {2, 3, 1},
                {1, 5, 9}
            };

            int[,] maticeA =
            {
                {1, 2, 3},
                {4, 5, 6}
            };

            int[,] maticeB =
            {
                {1, 2},
                {3, 4},
                {5, 6}
            };

            if (TrySoucetMatic(out int[,] vysledek, maticeVMatice, maticeMimoMatiku))
                VypisMatice(vysledek);
            Console.WriteLine();
            if (TrySoucinMatic(out int[,] vysledek2, maticeJenTak, maticeVsude))
                VypisMatice(vysledek2);
            Console.WriteLine();
            if (TrySoucinMatic(out int[,] vysledek3, maticeA, maticeB))
                VypisMatice(vysledek3);
        }

        static bool TrySoucetMatic(out int[,] vystup, int[,] a, int[,] b)
        {
            if((a.GetLength(0) == b.GetLength(0)) && (a.GetLength(1) == b.GetLength(1)))
            {
                vystup = new int[a.GetLength(0), a.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        vystup[i, j] = a[i, j] + b[i, j];
                return true;
            }
            else
            {
                vystup = new int[1,1];
                return false;
            }
        }

        static bool TrySoucinMatic(out int[,] vystup, int[,] a, int[,] b)
        {
            if(a.GetLength(1) == b.GetLength(0))
            {
                vystup = new int[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++) // prochází novou matici řádek po řádku
                    for (int j = 0; j < b.GetLength(1); j++) // prochází všechny buňky v řádku nové matice
                        for (int k = 0; k < a.GetLength(1); k++) // prochází zároveň sloupce 1. matice a řádky 2. matice
                            vystup[i, j] += a[i, k] * b[k, j];
                return true;
            }
            else
            {
                vystup = null;
                return false;
            }
        }

        static void VypisMatice(int[,] matice) {
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                for (int j = 0; j < matice.GetLength(1); j++)
                    Console.Write($"{matice[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}

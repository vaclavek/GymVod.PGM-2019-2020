using System;

namespace Matice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] maticeA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            int[,] maticeB = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            
            VypisMatici(NasMatic(maticeA, maticeB));
        }
        static int[,] NasMatic(int[,] maticeA, int[,] maticeB)
        {
            int[,] vyslednaMatice = new int[maticeA.GetLength(0), maticeB.GetLength(1)];
            for (int radek = 0; radek < maticeA.GetLength(0); radek++)
            {
                for (int sloupec = 0; sloupec < maticeB.GetLength(1); sloupec++)
                {
                    for (int operace = 0; operace < maticeA.GetLength(1); operace++)
                    {
                        vyslednaMatice[radek, sloupec] += maticeA[radek, operace] * maticeB[operace, sloupec];
                    }
                }
            }
            return vyslednaMatice;
        }
        static void VypisMatici(int[,] matice)
        {
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                for (int j = 0; j < matice.GetLength(1); j++)
                {
                    Console.Write(matice[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

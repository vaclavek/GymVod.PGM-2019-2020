using System;

namespace NasobeniMatic
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] maticeTest = NapisMatici();

            int[,] maticeA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            int[,] maticeB = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            VypisMatici(maticeA);
            VypisMatici(maticeB);
            Console.WriteLine("--------------");
            VypisMatici(NasobMatice(maticeA, maticeB));

        }
        static int[,] NasobMatice(int[,] maticeA, int[,] maticeB)
        {
            int[,] temp = new int[maticeA.GetLength(0), maticeB.GetLength(1)];

            for (int radek = 0; radek < maticeA.GetLength(0); radek++)
            {
                for (int sloupec = 0; sloupec < maticeB.GetLength(1); sloupec++)
                {
                    temp[radek, sloupec] = 0;
                    for (int operace = 0; operace < maticeA.GetLength(1); operace++)
                    {
                        temp[radek, sloupec] += maticeA[radek, operace] * maticeB[operace, sloupec];
                    }
                }
            }
            return temp;
        }
        static int[,] NapisMatici()
        {
            Console.Write("Zadejte počet řádků matice: ");
            int radku = Convert.ToInt32(Console.ReadLine());
            Console.Write("Zadejte počet sloupců matice: ");
            int sloupcu = Convert.ToInt32(Console.ReadLine());

            int[,] temp = new int[radku, sloupcu];

            for (int i = 0; i < radku; i++)
            {
                for (int j = 0; j < sloupcu; j++)
                {
                    Console.Write("Pozice [{0},{1}]: ", i, j);
                    temp[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return temp;
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

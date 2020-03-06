using System;


namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neserazenepole = { 3, 44, 38, 5, 47, 15, 26, 27 };
            int[] serazenepole = SeradInsertSort(neserazenepole);

            for (int i = 0; i < serazenepole.Length; i++)
            {
                Console.Write(serazenepole[i] + " ");
            }

            Console.ReadKey();
        }

        static int[] SeradInsertSort(int[] neserazenepole)
        {
            for (int i = 1; i < neserazenepole.Length; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (neserazenepole[j] < neserazenepole[j - 1])
                    {
                        int temp = neserazenepole[j - 1];
                        neserazenepole[j - 1] = neserazenepole[j];
                        neserazenepole[j] = temp;  //na pozici j-1 chci dát číslo z pozice j a naopak
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return neserazenepole;
        }
    }
}

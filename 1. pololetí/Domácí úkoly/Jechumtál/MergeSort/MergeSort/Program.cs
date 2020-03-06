using System;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neserazenePole = new int[10] { 11, 4, 21, 0, 49, 25, 6, 70, 10, -5 };
            Console.WriteLine("Neseřazené pole:");
            VypisPole(neserazenePole);

            int[] serazenePole = MergeSort(neserazenePole);
            Console.WriteLine("A nyní už je seřazené :-)");
            VypisPole(serazenePole);
        }
        static void VypisPole(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] MergeSort(int[] neserazenePole)
        {
            if (neserazenePole.Length <= 1)
            {
                return neserazenePole;
            }
            int polovinaPole = neserazenePole.Length / 2;
            int[] leva = new int[polovinaPole];
            int[] prava = new int[neserazenePole.Length - polovinaPole];
            for (int i = 0; i < polovinaPole; i++)
            {
                leva[i] = neserazenePole[i];
            }
            for (int j = polovinaPole; j < neserazenePole.Length; j++)
            {
                prava[j - polovinaPole] = neserazenePole[j];
            }
            MergeSort(leva);
            MergeSort(prava);
            return SpojovaniPoli(neserazenePole, leva, prava);
        }
        static int[] SpojovaniPoli(int[] serazenePole, int[] leva, int[] prava)
        {
            int i = 0;
            int j = 0;
            while (i < leva.Length && j < prava.Length)
            {
                if (leva[i] < prava[j])
                {
                    serazenePole[i + j] = leva[i];
                    i++;
                }
                else
                {
                    serazenePole[i + j] = prava[j];
                    j++;
                }
            }
            if (i < leva.Length)
            {
                while (i < leva.Length)
                {
                    serazenePole[i + j] = leva[i];
                    i++;
                }
            }
            else
            {
                while (j < prava.Length)
                {
                    serazenePole[i + j] = prava[j];
                    j++;
                }
            }
            return serazenePole;
        }
    }
}

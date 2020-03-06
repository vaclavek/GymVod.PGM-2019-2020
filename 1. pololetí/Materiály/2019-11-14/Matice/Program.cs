using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matice
{
    class Program
    {
        const int rozmerMaticeM = 4;
        const int rozmerMaticeN = 2;

        static void Main(string[] args)
        {
            int[,] maticeA = VygenerujMaticiA();
            int[,] maticeB = VygenerujMaticiB();

            int[,] maticeSoucet = SectiMatice(maticeA, maticeB);

            VypisNaObrazovku(maticeSoucet);

            int[][] polePoli;

            List<List<int>> list = new List<List<int>>();

            List<int> prvniRadek = new List<int>();
            prvniRadek.Add(1);
            prvniRadek.Add(3);
            list.Add(prvniRadek);

            List<int> druhyRadek = new List<int>();
            druhyRadek.Add(7);
            list.Add(druhyRadek);
            
        }

        private static int[,] SectiMatice(int[,] maticeA, int[,] maticeB)
        {
            int[,] maticeSoucet = new int[rozmerMaticeM, rozmerMaticeN];

            for (int i = 0; i < rozmerMaticeM; i++)
            {
                for (int j = 0; j < rozmerMaticeN; j++)
                {
                    maticeSoucet[i, j] = maticeA[i, j] + maticeB[i, j];
                }
            }

            return maticeSoucet;
        }

        private static int[,] VygenerujMaticiB()
        {
            int[,] maticeB = new int[rozmerMaticeM, rozmerMaticeN];
            maticeB[0, 0] = 0;
            maticeB[0, 1] = 1;
            maticeB[0, 2] = 3;
            maticeB[1, 0] = 5;
            maticeB[1, 1] = 1;
            maticeB[1, 2] = 0;
            maticeB[2, 0] = 1;
            maticeB[2, 1] = 0;
            maticeB[2, 2] = 0;
            return maticeB;
        }

        private static int[,] VygenerujMaticiA()
        {
            int[,] maticeA = new int[rozmerMaticeM, rozmerMaticeN];
            maticeA[0, 0] = 1;
            maticeA[0, 1] = 2;
            maticeA[0, 2] = 0;
            maticeA[1, 0] = 3;
            maticeA[1, 1] = 5;
            maticeA[1, 2] = 6;
            maticeA[2, 0] = 7;
            maticeA[2, 1] = 0;
            maticeA[2, 2] = 1;
            return maticeA;
        }

        static void VypisNaObrazovku(int[,] matice)
        {
            for (int i = 0; i < rozmerMaticeM; i++)
            {
                for (int j = 0; j < rozmerMaticeN; j++)
                {
                    Console.Write(matice[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        static int TestovaciMetoda(int druhy, string treti, object[] ctvrty)
        {
            return 42;
        }
    }
}

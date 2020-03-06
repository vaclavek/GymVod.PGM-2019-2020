using System;
using System.IO;

namespace Frekvence
{
    class Program
    {
        static void Main(string[] args)
        {
            string nacist = File.ReadAllText(@"c:\SVN\Jinsoft\GIT\GymVod\_DU\kalibrace_frekvence_data.txt");// relativní cesta na školnim počítači
            nacist = nacist.Replace("\r\n", " ");
            string[] frekvence = nacist.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int soucet = 0;

            //int[] cisla = new int[frekvence.Length];
            for (int i = 0; i < frekvence.Length; i++)
            {
                string fr = frekvence[i];
                int cislo = Convert.ToInt32(fr);
                soucet += cislo;

            }

            Console.Write(soucet);
            Console.ReadKey();


        }
    }
}

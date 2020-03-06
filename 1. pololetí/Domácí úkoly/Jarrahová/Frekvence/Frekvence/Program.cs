using System;

namespace Frekvence
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] obsahsouboru =
            System.IO.File.ReadAllLines(@"c:\SVN\Jinsoft\GIT\GymVod\_DU\kalibrace_frekvence_data.txt");
            int cislo = 0;
            foreach (string cislovestringu in obsahsouboru)
            {
                Console.WriteLine(cislovestringu);
                int cislovintu = Convert.ToInt32(cislovestringu);
                cislo = cislo + cislovintu;
            }
            Console.WriteLine("Výsledná kalibrace je " + cislo);
            Console.ReadKey();
        }
    }
}

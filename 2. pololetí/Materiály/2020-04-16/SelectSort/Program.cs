using System;

namespace SelectSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] pole = new int[15];

            Console.WriteLine("Pole neserazene: ");
            for (int i = 0; i < pole.Length; i++)
            {
                pole[i] = rand.Next(30);
                Console.Write(" " + pole[i] + ";");
            }

            SelectSort(pole);
        }
        private static void SelectSort(int[] vstupniPole)
        {
            int serazene = 0;
            do
            {
                int ulozenaPoz = serazene;
                for (int i = serazene; i < vstupniPole.Length; i++)
                {
                    if (vstupniPole[ulozenaPoz] > vstupniPole[i])
                    {
                        ulozenaPoz = i;
                    }
                }
                int temp = vstupniPole[serazene];
                vstupniPole[serazene] = vstupniPole[ulozenaPoz];
                vstupniPole[ulozenaPoz] = temp;
                serazene++;
            }
            while (serazene != vstupniPole.Length);

            Console.WriteLine("Serazene: ");
            foreach (int cislo in vstupniPole)
            {
                Console.Write(" " + cislo + ";");
            }
        }
    }
}

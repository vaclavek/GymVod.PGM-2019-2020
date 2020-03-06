using System;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolik čísel mám vygenerovat?");
            int pocetCisel = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int[] poleCisel = new int[pocetCisel];
            for(int i = 0; i < poleCisel.Length; i++)
            {
                poleCisel[i] = rnd.Next(0,100);
            }
            //InsertSortRazeni razeni = new InsertSortRazeni();
            BubbleSortRazeni razeni = new BubbleSortRazeni();
            int[] serazenePoleCisel = razeni.Serad(poleCisel);
            Console.Write("Serazena cisla:");
            for (int i = 0; i < pocetCisel; i++)
            {
                Console.Write(serazenePoleCisel[i]);
                Console.Write(" ");
            }
                         
           
        }
    }
}

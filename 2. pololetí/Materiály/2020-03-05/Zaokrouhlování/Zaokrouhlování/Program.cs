using System;

namespace Zaokrouhlování
{
    class Program
    {
        static void Main(string[] args)
        {
            double c1 = 0.5;
            double c2 = 1.5;
            double c3 = 2.5;
            double c4 = 3.5;

            double r1 = Math.Round(c1);
            double r2 = Math.Round(c2);
            double r3 = Math.Round(c3);
            double r4 = Math.Round(c4);

            Console.WriteLine(c1 + " zaokrouhleno je " + r1);
            Console.WriteLine(c2 + " zaokrouhleno je " + r2);
            Console.WriteLine(c3 + " zaokrouhleno je " + r3);
            Console.WriteLine(c4 + " zaokrouhleno je " + r4);

        }
    }
}

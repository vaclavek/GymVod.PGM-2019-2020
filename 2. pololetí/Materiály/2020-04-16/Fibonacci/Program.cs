using System;

namespace Fibonacci
{
    class Program
    {
        // Pole používáme pro optimalizaci algoritmu - ukládáme do něj již spočítaná čísla
        static ulong[] pole;
        static void Main(string[] args)
        {
            Console.WriteLine("Napiš, kolikátou fibonacciho posloupnost chceš");
            ulong fibonacciCislo = ulong.Parse(Console.ReadLine());

            pole = new ulong[fibonacciCislo + 1];
            pole[0] = 1;
            pole[1] = 1;

            Console.WriteLine(Fibonacci(fibonacciCislo));
        }
        private static ulong Fibonacci(ulong rad)
        {
            if (pole[rad] != 0)
            {
                return pole[rad];
            }
            else
            {
                pole[rad] = Fibonacci(rad - 1) + Fibonacci(rad - 2);
                return pole[rad];
            }
        }
    }
}

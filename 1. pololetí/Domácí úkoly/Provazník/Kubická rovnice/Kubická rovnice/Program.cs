using System;
using System.Numerics;

namespace Kubická_rovnice
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d;
            do
            {
            gotojespatne:
                Console.WriteLine("zadejte postupne koeficienty kubicke rovnice ax^3 + bx^2 + cx + d = 0 oddelene enterem");
                try
                {
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());
                    c = double.Parse(Console.ReadLine());
                    d = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("spatny format vstupu, znovu!");
                    goto gotojespatne;
                }
            } while (a == 0);
            b /= a;
            c /= a;
            d /= a;
            //viz wikipedia cubic equation
            double d0 = b * b - 3 * a * c;
            double d1 = 2 * b * b * b - 9 * a * b * c + 27 * a * a * d;
            Complex C = Complex.Pow(d1 / 2 + Complex.Sqrt(d1 * d1 - 4 * d0 * d0 * d0) / 2, 1.0 / 3.0);
            Complex C2 = Complex.Pow(d1 / 2 - Complex.Sqrt(d1 * d1 - 4 * d0 * d0 * d0) / 2, 1.0 / 3.0);

            for (int k = 0; k < 3; k++)
            {
                Complex fnj = -1.0 / 2.0 + Complex.Sqrt(-3) / 2.0;
                Complex x = -1 / (3 * a) * (b + C * Complex.Pow(fnj, k) + d0 / (Complex.Pow(fnj, k) * C));
                Complex x2 = -1 / (3 * a) * (b + C2 * Complex.Pow(fnj, k) + d0 / (Complex.Pow(fnj, k) * C2));
                if (x.Imaginary < 0.00001)
                    Console.WriteLine($"x{k} = {Math.Round(x.Real, 5)}");
                else
                {
                    char sign = '+';
                    if (Math.Sign(x.Imaginary) == -1)
                    {
                        sign = '-';
                    }
                    Console.WriteLine($"x{k} = {Math.Round(x.Real, 5)} {sign} {Math.Round(x.Imaginary, 5)}i");
                }
            }


        }

    }
}

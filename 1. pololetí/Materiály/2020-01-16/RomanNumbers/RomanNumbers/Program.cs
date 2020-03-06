using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumbers
{
    class Program
    {
        public static void Main()
        {
            var roman = new Prevodnik();
            Console.WriteLine(roman.Preved(598));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumbers
{
    class Prevodnik
    {
        public readonly Dictionary<short, string> symboly = new Dictionary<short, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

        public string Preved(int number)
        {
            var vystup = new StringBuilder();

            foreach (var prvekSlovniku in symboly)
            {
                while (number >= prvekSlovniku.Key)
                {
                    vystup.Append(prvekSlovniku.Value);
                    number -= prvekSlovniku.Key;
                }
            }
            return vystup.ToString();
        }
    }
}
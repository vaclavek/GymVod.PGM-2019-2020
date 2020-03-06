using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Tvary
{
    class Kruh : ITvar
    {
        private readonly double polomer;

        public Kruh(double polomer)
        {
            this.polomer = polomer;
        }

        public double Obsah()
        {
            // Pi krát r na druhou
            return Math.PI * Math.Pow(polomer, 2);
        }
    }
}

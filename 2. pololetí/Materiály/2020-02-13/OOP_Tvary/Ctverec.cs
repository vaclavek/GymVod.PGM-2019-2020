using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Tvary
{
    class Ctverec : ITvar
    {
        private readonly double hrana;

        public event EventHandler SpocitalJsemObsah;

        public Ctverec(double a)
        {
            hrana = a;
        }

        public double Obsah()
        {
            var obsah = hrana * hrana;
            
            if (SpocitalJsemObsah != null)
            {
                SpocitalJsemObsah(null, null);
            }

            return obsah;
        }
    }
}

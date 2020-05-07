using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Kruh : ITvar
    {
        public Kruh(decimal polomer)
        {
            this.polomer = polomer;
        }

        public decimal polomer { get; set; }
        public string VratInformace()
        {
            return "Ahoj, jsem kruh o poloměru " + polomer;
        }

        public decimal VypoctiObsah()
        {
            return Convert.ToDecimal(Math.PI) * polomer * polomer;
        }
    }
}

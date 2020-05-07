using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Obdelnik : ITvar
    {
        public Obdelnik(int stranaA, int stranaB)
        {
            this.stranaA = stranaA;
            this.stranaB = stranaB;
        }

        public int stranaA { get; set; }
        public int stranaB { get; set; }
        public virtual string VratInformace()
        {
            return $"Ahoj, jsem obdélník se stranami {stranaA} a {stranaB}";
        }

        public decimal VypoctiObsah()
        {
            return stranaA * stranaB;
        }
    }
}

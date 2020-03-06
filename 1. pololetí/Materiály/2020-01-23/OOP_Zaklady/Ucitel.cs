using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Zaklady
{
    class Ucitel : Clovek
    {
        public int DelkaKantorskePraxe { get; set; }

        public Ucitel(DateTime datumNarozeni, string jmeno) : base(datumNarozeni, jmeno)
        {
            JeUcitel = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Zaklady
{
    interface IClovek
    {
        DateTime DatumNarozeni { get; }
        int Vek { get; }
        string Jmeno { get; }

        void Napis(string comamrict);
    }
}

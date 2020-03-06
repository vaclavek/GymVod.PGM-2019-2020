using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Zaklady
{
    class Programator : Clovek
    {
        public string[] ZnalostProgramovacichJazyku { get; set; }

        public Programator(DateTime datumNarozeni, string jmeno) : base(datumNarozeni, jmeno)
        {
            JeProgramator = true;
        }
    }
}

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

        public void Naprogramuj(string conaprogramovat)
        {
            // něco programuji
        }

        public override void Napis(string comamrict)
        {
            // cokoli
            System.IO.File.WriteAllText("x.txt", comamrict);
            
            // ještě zavoláme bázovou metodu
            base.Napis(comamrict);

            // něco za tím
        }

        public override string CoDelasVPraci()
        {
            return "programuji";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Zaklady
{
    class Clovek
    {
        public DateTime DatumNarozeni { get; private set; }
        public int Vek { get { return (int)Math.Floor(DateTime.Now.Subtract(DatumNarozeni).TotalDays / 365); } }
        public string Jmeno { get; private set; }
        public bool JeProgramator { get; protected set; }
        public bool JeUcitel { get; protected set; }

        public Clovek(DateTime datumNarozeni, string jmeno, bool jeProgramator, bool jeUcitel)
        {
            DatumNarozeni = datumNarozeni;
            Jmeno = jmeno;
            JeProgramator = jeProgramator;
            JeUcitel = jeUcitel;
        }

        public Clovek(DateTime datumNarozeni, string jmeno)
        {
            DatumNarozeni = datumNarozeni;
            Jmeno = jmeno;
        }

        public void Skoc()
        {
            Console.WriteLine("HOP!");
        }

        public void Napis(string comamrict)
        {
            Console.WriteLine("Píšu: " + comamrict);
        }

        public string JakSeJmenujes()
        {
            return Jmeno;
        }

    }
}

using System;

namespace OOP_Tvary
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctverec = new Ctverec(10);
            ctverec.SpocitalJsemObsah += VypisUdalostDoKonzole;

            var ctverec2 = new Ctverec(7);
            ctverec2.SpocitalJsemObsah += VypisUdalostDoKonzole;

            ITvar[] tvary = new ITvar[]
            {
                ctverec,
                ctverec2,
                new Kruh(5),
                new Kruh(2)
            };

            foreach (ITvar tvar in tvary)
            {
                double obsah = tvar.Obsah();
                Console.WriteLine("Obsah tvaru je " + obsah);
            }
        }

        private static void VypisUdalostDoKonzole(object sender, EventArgs e)
        {
            Console.WriteLine("Obsah je spočítaný.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrciPrvocisloTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool pokracuj = true;
            do
            {
                Console.WriteLine("Napište číslo o kterém si myslíte že je prvočíslo.");
                int num;
                if (!Int32.TryParse(Console.ReadLine(), out num))
                    Console.WriteLine("Neplatná hodnota");

                Console.WriteLine(JePrvocislo(num) ? "Zadané číslo je prvočíslo" : "Zadané číslo není prvočíslo");
                Console.Write("Přejete si pokračovat Y/N?");
                pokracuj = Console.ReadLine() == "Y" ? true : false;
            } while (pokracuj);
        }
        static bool JePrvocislo(int num)
        {
            for(int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}

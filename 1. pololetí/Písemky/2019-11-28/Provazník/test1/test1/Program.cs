using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static bool isPrime(int x)
        {
         for(int i = 2; i < x / 2 + 1; i++)
            {
                if (x%i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
           int x = int.Parse(Console.ReadLine());
            if (isPrime(x))
            {
                Console.WriteLine("je prvocislo");
            }else
            {
                Console.WriteLine("neni prvocislo");
            }
            Console.ReadKey();
         
           
        }
    }
}

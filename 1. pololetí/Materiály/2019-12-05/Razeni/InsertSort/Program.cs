using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neserazenePole = { 3, 44, 38, 5, 47, 15, 26, 27 };
            int[] serazenePole = SeradInsertSort(neserazenePole);
            Console.Write("Seřazené pole je: " + string.Join(" ", serazenePole));            
        }

        static int[] SeradInsertSort(int[] neserazenePole)
        {
            int[] serazenePole = new int[neserazenePole.Length];

            // prochází všechny prvky pole postupně od prvního
            for (int i = 0; i < neserazenePole.Length; i++)
            {
                // umístím ho do serazenePole *
                // * na správné místo =  


            }

            
            return serazenePole;
        }
    }
}

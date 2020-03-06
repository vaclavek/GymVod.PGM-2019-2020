using System;
using System.Collections.Generic;
using System.Text;

namespace InsertSort
{
    class BubbleSortRazeni
    {
        public int[] Serad(int[] neserazene)
        {
            int[] pole = new int[neserazene.Length];
            Array.Copy(neserazene, 0, pole, 0, pole.Length);

            for(int i = 0; i < pole.Length; i++)
            {
                int max;
                max = pole[0];
                for(int j = 1; j < pole.Length - i; j++)
                {
                    if(pole[j] >= max)
                    {
                        max = pole[j];
                    }
                    else
                    {
                        int tmp = pole[j - 1];
                        pole[j - 1] = pole[j];
                        pole[j] = tmp;
                    }

                }

            }
            return pole;
        }
    }
}

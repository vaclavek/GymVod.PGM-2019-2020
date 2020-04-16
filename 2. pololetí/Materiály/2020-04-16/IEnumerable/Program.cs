using System.Collections.Generic;

namespace IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var pole = new int[4]
            {
                1,2,3,4
            };

            var seznam = new List<int>()
            {
                1,2,3,4
            };

            bool poleSude = JsouVsechnaCislaSuda(pole);
            bool seznamSude = JsouVsechnaCislaSuda(seznam);


        }

        static bool JsouVsechnaCislaSuda(IEnumerable<int> pole)
        {
            foreach (var prvek in pole)
            {
                if (prvek % 2 == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

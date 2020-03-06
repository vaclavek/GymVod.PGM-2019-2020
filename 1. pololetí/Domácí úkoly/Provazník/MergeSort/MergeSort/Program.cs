using System;

namespace Merge
{
    class Program
    {
        static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
                return arr;

            int midpoint = arr.Length / 2;
            var left = new int[midpoint];
            var right = new int[arr.Length - midpoint];
            for (int i = 0; i < midpoint; i++)
                left[i] = arr[i];

            for (int i = 0; i < arr.Length - midpoint; i++)
                right[i] = arr[midpoint + i];

            left = MergeSort(left);
            right = MergeSort(right);

            int l = 0;
            int r = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (l >= left.Length)
                {
                    arr[i] = right[r];
                    r++;
                }
                else if (r >= right.Length)
                {
                    arr[i] = left[l];
                    l++;
                }
                else if (right[r] < left[l])
                {
                    arr[i] = right[r];
                    r++;
                }
                else if (right[r] >= left[l])
                {
                    arr[i] = left[l];
                    l++;
                }
            }

            return arr;
        }
        static void Main(string[] args)
        {
            int[] arr = { 3, 2, 6, 7, 3, 4, 5, 67, 8, 34, 32, 254, 345, 37, 4, 73, 45 };
            Console.WriteLine(string.Join(" ", MergeSort(arr)));
        }
    }
}
using System;
namespace Immutables
{
    public class Heap
    {
        public static void Insert(int[] H, int n)
        {
            int i = n, temp = H[i];

            while (i > 1 && temp > H[i / 2])
            {
                H[i] = H[i / 2];
                i = i / 2;
            }

            H[i] = temp;
        }
    }
}

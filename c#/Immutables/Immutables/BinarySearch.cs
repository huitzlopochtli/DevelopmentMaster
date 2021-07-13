using System;
namespace Immutables
{
    public class BinarySearch
    {
        static bool binarySearch(int[] arr, int l, int r, int value)
        {
            if (r >= 1)
            {
                int mid = (r + l) / 2;
                if (arr[mid] == value || arr[l] == value || arr[r] == value)
                    return true;
                else if (value < arr[mid])
                {
                    r = mid - 1;
                    return binarySearch(arr, l, r, value);
                }
                else if (value > arr[mid])
                {
                    l = mid + 1;
                    return binarySearch(arr, l, r, value);
                }
            }

            return false;
        }
    }
}

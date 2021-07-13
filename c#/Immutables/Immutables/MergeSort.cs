using System;
namespace Immutables
{
    public static class MergeSort
    {
        public static void In_PlaceSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = start + (end - start) / 2;

                In_PlaceSort(arr, start, mid);
                In_PlaceSort(arr, mid + 1, end);

                In_PlaceMerge(arr, start, mid, end);

            }
        }

        private static void In_PlaceMerge(int[] arr, int start, int mid, int end)
        {
            int start2 = mid + 1;

            // One extra check:  can we SKIP the merge? Yes, return
            if (arr[mid] <= arr[start2])
                return;

            // Two pointers to maintain start 
            // of both arrays to merge
            while (start <= mid && start2 <= end)
            {
                // // Select from left:  no change, just advance left
                if (arr[start] <= arr[start2])
                {
                    start++;
                }
                else
                {
                    int value = arr[start2];
                    int index = start2;

                    // Select from right:  rotate [left..right] and correct
                    // shift value from right to left 
                    while (index != start)
                    {
                        arr[index] = arr[index - 1];
                        index--;
                    }
                    // left value to right
                    arr[start] = value;

                    // Update all the pointers 
                    start++;
                    mid++;
                    start2++;
                }

            }
        }

        //public static void Sort(int[] arr,)
    }
}

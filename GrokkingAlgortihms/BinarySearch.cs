using System;

namespace GrokkingAlgortihms
{
    public static class BinarySearch
    {
        public static int Search(int[] arr, int v)
        {
            int cnt = 0;
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int middle = (high - low) / 2 + low;
                if (arr[middle] == v)
                {
                    Console.WriteLine("Number of cycles was " + cnt);
                    return middle + 1;
                }
                else if (arr[middle] < v)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
                cnt++;
            }

            Console.WriteLine("Number of cycles was " + cnt);
            return -1;
        }
    }
}
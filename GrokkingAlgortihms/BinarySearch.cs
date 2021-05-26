namespace GrokkingAlgortihms
{
    public static class BinarySearch
    {
        public static int Search(int[] arr, int v)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int middle = (high - low) / 2 + low;
                if (arr[middle] == v)
                    return middle + 1;
                else if (arr[middle] < v)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }

            return -1;
        }
    }
}
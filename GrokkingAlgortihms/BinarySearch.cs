namespace GrokkingAlgortihms
{
    public static class BinarySearch
    {
        public static int Search(int[] arr, int v)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (true)
            {
                int middle = (high - low) / 2 + low;
                if (arr[middle] == v)
                    return middle;
                else if (arr[middle] < v)
                {
                    if (low == middle || high == middle)
                        break;
                    low = middle;
                }
                else
                {
                    if (low == middle || high == middle)
                        break;
                    high = middle;
                }
            }

            return -1;
        }
    }
}

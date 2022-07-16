namespace BinarySearch
{
    public static class BinarySearcher
    {
        public static int Search(int[] array, int valueToFind)
        {
            //1 find median
            //2 check if median is value if yes return true and finish
            //3 if value less than median, move tail to median - 1, if value more than median, move head to median + 1
            //4 run until head and tail not same

            var headIndex = 0;
            var tailIndex = array.Length - 1;

            while (headIndex != tailIndex)
            {
                var medianIndex = Median(headIndex, tailIndex);
                if (array[medianIndex] == valueToFind)
                    return medianIndex;

                if (valueToFind < array[medianIndex])
                {
                    tailIndex = medianIndex - 1;
                }
                else
                {
                    headIndex = medianIndex + 1;
                }

                if (headIndex == tailIndex)
                {
                    if (array[headIndex] == valueToFind)
                        return headIndex;

                    return -1;
                }
            }

            return -1;
        }

        private static int Median(int headIndex, int tailIndex)
        {
            return headIndex + (tailIndex - headIndex) / 2;
        }
    }
}
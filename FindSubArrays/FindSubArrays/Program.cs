var arr = new int[] { 7, 2, -5, 1, 1, -1, 5, -5 };
var k = 5;

var subArrayFinder = new SubArrayFinderSimple();
var appropriateArrays = subArrayFinder.Find(arr, k);
foreach (var range in appropriateArrays)
	Console.WriteLine($"Lower: {range.Lower}, Upper: {range.Upper}");

Console.ReadLine();

public class Range
{
	public int Upper { get; set; }
	public int Lower { get; set; }
}

public class SubArrayFinderSimple
{
	public List<Range> Find(int[] arr, int k)
	{
		var ranges = new List<Range>();

		for (int i = 0; i < arr.Length; i++)
			for (int j = arr.Length - 1; j >= i; j--)
			{
				if (Sum(arr, i, j) == k)
					ranges.Add(new Range() { Lower = i, Upper = j });
			}

		return ranges;
	}

	private int Sum(int[] arr, int i, int j)
	{
		int sum = 0;
		for (; i <= j; i++)
			sum += arr[i];
		return sum;
	}
}
var arr = new int[3000];
Random random = new Random();

for (int i = 0; i < arr.Length; i++)
	arr[i] = random.Next(-10, 10);

var k = 5;

Console.WriteLine($"SubArrayFinderSimple");
var subArrayFinderSimple = new SubArrayFinderSimple();
var appropriateArrays = subArrayFinderSimple.Find(arr, k);
//foreach (var range in appropriateArrays)
//	Console.WriteLine($"Lower: {range.Lower}, Upper: {range.Upper}");
Console.WriteLine($"results amount = {appropriateArrays.Count}");

Console.WriteLine($"SubArrayFinder");
var subArrayFinder = new SubArrayFinder();
appropriateArrays = subArrayFinder.Find(arr, k);
//foreach (var range in appropriateArrays)
//	Console.WriteLine($"Lower: {range.Lower}, Upper: {range.Upper}");
Console.WriteLine($"results amount = {appropriateArrays.Count}");

Console.WriteLine($"SubArrayFinderWithHash");
var subArrayFinderWithHash = new SubArrayFinderWithHash();
var cnt = subArrayFinderWithHash.Find(arr, k);
//foreach (var range in appropriateArrays)
//	Console.WriteLine($"Lower: {range.Lower}, Upper: {range.Upper}");
Console.WriteLine($"results amount = {cnt}");


Console.ReadLine();

public class SubArrayFinderWithHash
{
	public int Find(int[] arr, int k)
	{
		DateTime start = DateTime.Now;
		Dictionary<int, int> hash = new Dictionary<int, int>();
		hash.Add(0, 1);

		var subArrays = 0;
		var prevSum = 0;

		for (int i = 0; i < arr.Length; i++)
		{
			prevSum += arr[i];
			if (!hash.ContainsKey(prevSum))
				hash.Add(prevSum, 0);

			hash[prevSum]++;

			if (hash.ContainsKey(prevSum - k))
				subArrays += hash[prevSum - k];
		}

		DateTime stop = DateTime.Now;
		Console.WriteLine((stop - start).TotalMilliseconds);

		return subArrays;
	}

	private int Sum(int[] arr, int i, int j)
	{
		int sum = 0;
		for (; i <= j; i++)
			sum += arr[i];
		return sum;
	}
}

public class SubArrayFinder
{
	public List<Range> Find(int[] arr, int k)
	{
		DateTime start = DateTime.Now;

		var ranges = new List<Range>();
		var prevSum = 0;

		for (int i = 0; i < arr.Length; i++)
		{
			prevSum = 0;
			for (int j = i; j < arr.Length; j++)
			{
				prevSum += arr[j];

				if (prevSum == k)
					ranges.Add(new Range() { Lower = i, Upper = j });
			}
		}

		DateTime stop = DateTime.Now;
		Console.WriteLine((stop - start).TotalMilliseconds);

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


public class SubArrayFinderSimple
{
	public List<Range> Find(int[] arr, int k)
	{
		DateTime start = DateTime.Now;

		var ranges = new List<Range>();

		for (int i = 0; i < arr.Length; i++)
			for (int j = i; j < arr.Length; j++)
			{
				if (Sum(arr, i, j) == k)
					ranges.Add(new Range() { Lower = i, Upper = j });
			}

		DateTime stop = DateTime.Now;
		Console.WriteLine((stop - start).TotalMilliseconds);

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

public class Range
{
	public int Upper { get; set; }
	public int Lower { get; set; }
}

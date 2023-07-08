using System.Linq;

var hindexFinder = new HIndexFinder();
var publications = new int[] { 7, 13, 0, 6, 1, 5 };

Console.WriteLine($"H index of [{String.Join(", ", publications)}] is {hindexFinder.FindHVer1(publications)}");
Console.WriteLine($"H index of [{String.Join(", ", publications)}] is {hindexFinder.FindHVer2(publications)}");


Console.ReadLine();

public class HIndexFinder
{
	//Complexity O(n^n)
	internal int FindHVer1(int[] publications)
	{
		int cnt = 0;

		//size of h
		for (int h = 1; h < publications.Length; h++)
		{
			cnt = 0;
			//check how much h we have;
			for (int j = 0; j < publications.Length; j++)
				if (publications[j] >= h)
				{
					cnt++;
					if (cnt >= h)
						break;
				}

			if (cnt < h)
				return h - 1;
		}
		return -1;
	}

	//Complexity O(n*log(n) + n) = O(n*log(n))
	internal int FindHVer2(int[] publications)
	{
		Array.Sort(publications);
		var n = publications.Length;
		for (int h = 1; h < n; h++)
		{
			if (publications[n - h] < h)
				return h - 1;
		}
		return -1;
	}
}
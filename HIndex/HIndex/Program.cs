using System.Linq;

var hindexFinder = new HIndexFinder();
var publications = new int[] { 3, 0, 6, 1, 5 };

Console.WriteLine($"H index of [{String.Join(", ", publications)}] is {hindexFinder.FindHVer1(publications)}");

Console.ReadLine();

public class HIndexFinder
{
	internal int FindHVer1(int[] publications)
	{
		int h = 0;
		int cnt = 0;

		//size of h
		for (h = 1; h < publications.Length; h++, cnt = 0)
		{
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
}
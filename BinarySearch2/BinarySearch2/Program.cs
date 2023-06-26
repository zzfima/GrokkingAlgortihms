List<int> ints = new List<int> { 1, 2, 3, 17, 33, 55, 67, 88, 345, 4234 };
var searcher = new BinarySearcher();

Console.WriteLine(searcher.SearchItem(ints, 70));
foreach (var i in ints)
{
	Console.WriteLine(searcher.SearchItem(ints, i));
}


Console.ReadLine();

// 1, 2, 3, 17, 33, 55, 67, 88, 345, 4234
// 0  1  2   3   4   5   6   7    8     9

public class BinarySearcher
{
	public int SearchItem(List<int> items, int itemToSearch)
	{
		var leftIndex = 0;
		var rightIndex = items.Count - 1;
		var centerIndex = FindCenterIndex(leftIndex, rightIndex);

		while (leftIndex <= rightIndex)
		{
			if (items[centerIndex] == itemToSearch)
				return centerIndex;
			else if (itemToSearch > items[centerIndex])
				leftIndex = centerIndex + 1;
			else if (itemToSearch < items[centerIndex])
				rightIndex = centerIndex - 1;

			centerIndex = FindCenterIndex(leftIndex, rightIndex);
		}

		return -1;
	}

	private int FindCenterIndex(int leftIndex, int rightIndex)
	{
		return (int)(Math.Round((double)((rightIndex + leftIndex) / 2)));
	}
}
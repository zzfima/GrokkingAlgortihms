var qsort = new QSort();
foreach (var i in qsort.Sort(new List<int> { 56, 9, 3, 7, 4, 6, 2, 1, 8 }))
	Console.WriteLine(i);

Console.ReadLine();

public class QSort
{
	public List<int> Sort(List<int> ints)
	{
		if (ints.Count < 2)
			return ints;

		if (ints.Count == 2)
		{
			if (ints[0] > ints[1])
			{
				var tmp = ints[1];
				ints[1] = ints[0];
				ints[0] = tmp;
			}
			return ints;
		}

		//select pivot
		var pivotIndex = ints.Count / 2;
		var pivot = ints[pivotIndex];
		var leftArray = new List<int>();
		var rightArray = new List<int>();

		for (int i = 0; i < ints.Count; i++)
		{
			if (i == pivotIndex)
				continue;

			if (ints[i] < pivot)
				leftArray.Add(ints[i]);
			else rightArray.Add(ints[i]);
		}

		var l = Sort(leftArray);
		var r = Sort(rightArray);

		var res = new List<int>();
		res.AddRange(l);
		res.Add(pivot);
		res.AddRange(r);
		return res;
	}
}

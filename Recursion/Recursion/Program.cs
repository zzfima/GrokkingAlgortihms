int sum = 0;
Console.WriteLine(ArraySum(new List<int> { 1, 2, 3, 4 }));
Console.WriteLine(ArraySum1(new List<int> { 1, 2, 3, 4 }));
Console.WriteLine(ArraySum2(new List<int> { 1, 2, 3, 4 }, 4));
Console.ReadLine();


int ArraySum(List<int> arr)
{
	if (arr.Count == 0)
		return sum;
	else
	{
		sum += arr[0];
		arr.RemoveAt(0);
		return ArraySum(arr);
	}
}

int ArraySum1(List<int> arr)
{
	if (arr.Count == 0)
		return 0;

	var tmp = arr[0];
	arr.RemoveAt(0);
	return tmp + ArraySum1(arr);
}

int ArraySum2(List<int> arr, int n)
{
	if (n <= 0)
		return 0;

	return arr[n - 1] + ArraySum2(arr, n - 1);
}
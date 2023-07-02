var minSquareFinder = new MinimumSquareFinder();
Console.WriteLine(minSquareFinder.Find(1680, 640));

var sumArray = new SumArray();
Console.WriteLine(sumArray.Sum(new List<int> { 1, 1, 5, 3 }));

var calcArrayLength = new CalcArrayLength();
Console.WriteLine(calcArrayLength.Calc(new List<int> { 1, 1, 5, 3, 6, 7, 8, 98 }));

var calcMaxNumber = new CalcMaxNumber();
Console.WriteLine(calcMaxNumber.Calc(new List<int> { 1, 1, 5, 356, 6, 7, 867, 98 }));


Console.ReadLine();

public class MinimumSquareFinder
{
	internal int Find(int width, int height)
	{
		Console.WriteLine($"Width: {width}, Heigth: {height}");

		//base case
		if (width >= height && width % height == 0)
			return height;
		else if (height >= width && height % width == 0)
			return width;

		//recursive case
		if (width >= height)
			return Find(width - (width / height) * height, height);
		else
			return Find(width, height - (height / width) * width);
	}
}

public class SumArray
{
	public int Sum(List<int> array)
	{
		if (array.Count == 1)
			return array[0];

		var a = array[0];
		array.RemoveAt(0);
		return a + Sum(array);
	}
}

public class CalcArrayLength
{
	public int Calc(List<int> array)
	{
		if (array.Count == 1)
			return 1;

		array.RemoveAt(0);
		return 1 + Calc(array);
	}
}

public class CalcMaxNumber
{
	public int Calc(List<int> array, int num = int.MinValue)
	{
		if (array.Count == 0)
			return num;

		var a1 = array[0];
		array.RemoveAt(0);
		var a2 = Calc(array);

		if (a1 > a2)
			return a1;
		return a2;
	}
}
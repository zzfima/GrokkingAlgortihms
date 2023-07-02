var minSquareFinder = new MinimumSquareFinder();
Console.WriteLine(minSquareFinder.Find(1680, 640));

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

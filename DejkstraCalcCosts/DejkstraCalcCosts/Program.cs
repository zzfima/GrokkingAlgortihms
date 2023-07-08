var piano = new Product("Piano");
var guitar = new Product("Guitar");
var drum = new Product("Drum");
var disk = new Product("Disk");
var poster = new Product("Poster");
var book = new Product("Book");

drum.Neighbours.Add(piano, 10);

guitar.Neighbours.Add(piano, 20);

disk.Neighbours.Add(guitar, 15);
disk.Neighbours.Add(drum, 20);

poster.Neighbours.Add(guitar, 30);
poster.Neighbours.Add(drum, 35);

book.Neighbours.Add(disk, 5);
book.Neighbours.Add(poster, 0);

DistancesFinder distancesFinder = new DistancesFinder();
foreach (var item in distancesFinder.Find(book))
{
	Console.WriteLine($"Until {item.Key} distance is {item.Value}");
}

Console.ReadLine();

public class DistancesFinder
{
	public Dictionary<String, int> Find(Product root)
	{
		var distances = new Dictionary<String, int>();

		//1. put all products to distances table
		var productsQueue = new Queue<Product>();
		productsQueue.Enqueue(root);
		while (productsQueue.Count > 0)
		{
			var product = productsQueue.Dequeue();
			if (!distances.ContainsKey(product.Name))
				distances.Add(product.Name, int.MaxValue);

			foreach (var item in product.Neighbours)
				productsQueue.Enqueue(item.Key);
		}

		//2. Init
		List<string> calculatedProducts = new List<string>() { root.Name };
		var currentProduct = string.Empty;

		//3. Main cycle until all products calculated
		productsQueue.Enqueue(root);
		while (productsQueue.Count > 0)
		{
			var product = productsQueue.Dequeue();
			currentProduct = root.Name;
			foreach (var item in root.Neighbours)
			{
				if (distances[item.Key.Name] == int.MaxValue)
				{
					distances[item.Key.Name] = item.Value;
				}
				else
				{

				}
			}

		}

		while (calculatedProducts.Count <= distances.Count)
		{

		}

		return distances;
	}
}

public class Product
{
	public Product(string name)
	{
		Name = name;
	}

	public string Name { get; }
	public Dictionary<Product, int> Neighbours { get; set; } = new Dictionary<Product, int>();
}
var anudj = new Seller("anudj") { IsSellMango = true };
var peggi = new Seller("peggi");
var jonni = new Seller("jonni");
var tom = new Seller("tom");

var bob = new Seller("bob");
bob.Friends.Add(anudj);
bob.Friends.Add(peggi);

var alisa = new Seller("alisa");
alisa.Friends.Add(peggi);

var clar = new Seller("clar");
clar.Friends.Add(jonni);
clar.Friends.Add(tom);

var me = new Seller("me");
me.Friends.Add(bob);
me.Friends.Add(alisa);
me.Friends.Add(clar);

var bfs = new BFS();
Seller? seller = bfs.FindWhoSellMango(me);
if (seller != null)
	Console.WriteLine(seller.Name);

Console.ReadLine();

public class BFS
{
	internal Seller? FindWhoSellMango(Seller me)
	{
		Queue<Seller> queue = new Queue<Seller>();
		queue.Enqueue(me);

		while (queue.Count > 0)
		{
			var s = queue.Dequeue();
			if (s.IsSellMango)
				return s;

			foreach (var item in s.Friends)
				queue.Enqueue(item);
		}


		return null;
	}
}

public class Seller
{
	public Seller(string name)
	{
		Name = name;
	}
	public bool IsSellMango { get; set; } = false;
	public List<Seller> Friends { get; set; } = new List<Seller>();
	public string Name { get; }
}
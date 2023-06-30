var ll = new LinkedList();
ll.Add(55);
ll.Add(66);
ll.Add(77);
ll.Add(88);

ll.PrintAll();

Console.Read();


public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
}

public class LinkedList
{
	Node? _head = null;
	Node? _tail = null;

	public LinkedList()
	{
		_head = null;
		_tail = null;
	}

	public void Add(int value)
	{
		if (_head == null)
		{
			_head = new Node() { Data = value };
		}
		else if (_head.Next == null)
		{
			_tail = new Node() { Data = value };
			_head.Next = _tail;
		}
		else
		{
			var newNode = new Node() { Data = value };
			_tail.Next = newNode;
			_tail = newNode;
		}

	}

	public void PrintAll()
	{
		var tmp = _head;

		while (tmp.Next != null)
		{
			Console.WriteLine(tmp.Data);
			tmp = tmp.Next;
		}
		Console.WriteLine(tmp.Data);
	}
}
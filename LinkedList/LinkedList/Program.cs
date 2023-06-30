using System.Collections;

var ll = new LinkedList<int>();
ll.Add(55);
ll.Add(66);
ll.Add(77);
ll.Add(88);
ll.Add(99);
ll.PrintAll();
Console.WriteLine("************");

ll.RemoveHead();
ll.PrintAll();
Console.WriteLine("************");

ll.Remove(77);
ll.PrintAll();
Console.WriteLine("************");

foreach (int i in ll)
	Console.WriteLine(i);

Console.Read();


public class Node<T>
{
	public T Data { get; set; }
	public Node<T> Next { get; set; }
}

public class LinkedList<T> : IEnumerable
{
	Node<T>? _head = null;
	Node<T>? _tail = null;

	public LinkedList()
	{
		_head = null;
		_tail = null;
	}

	public void Add(T value)
	{
		if (_head == null)
		{
			_head = new Node<T>() { Data = value };
		}
		else if (_head.Next == null)
		{
			_tail = new Node<T>() { Data = value };
			_head.Next = _tail;
		}
		else
		{
			var newNode = new Node<T>() { Data = value };
			_tail.Next = newNode;
			_tail = newNode;
		}

	}

	public IEnumerator GetEnumerator()
	{
		var tmp = _head;
		while (tmp != null)
		{
			yield return tmp.Data;
			tmp = tmp.Next;
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

	public void Remove(T v)
	{
		Node<T> curr = _head;
		Node<T> prev = null;

		while (!curr.Data.Equals(v) && curr.Next != null)
		{
			prev = curr;
			curr = curr.Next;
		}

		prev.Next = curr.Next;
	}

	public void RemoveHead()
	{
		_head = _head.Next;
	}
}
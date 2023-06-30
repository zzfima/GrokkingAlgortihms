using System.Collections;

var ll = new NodeList<int>();
ll.AddLast(55);
ll.AddLast(66);
ll.AddLast(77);
ll.AddLast(88);
ll.AddLast(99);
ll.PrintAll((i) => Console.WriteLine(i));
Console.WriteLine("************");

ll.RemoveHead();
ll.PrintAll((i) => Console.WriteLine(i));
Console.WriteLine("************");

ll.Remove(77);
ll.PrintAll((i) => Console.WriteLine(i));
Console.WriteLine("************");

foreach (int i in ll)
	Console.WriteLine(i);

Console.Read();


public class Node<T>
{
	public T Data { get; set; }
	public Node<T> Next { get; set; }
}

public class NodeList<T> : IEnumerable
{
	Node<T>? _head = null;
	Node<T>? _tail = null;

	public NodeList()
	{
		_head = null;
		_tail = null;
	}

	public void AddLast(T value)
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

	public void PrintAll(Action<T> action)
	{
		var tmp = _head;

		while (tmp != null)
		{
			action(tmp.Data);
			tmp = tmp.Next;
		}
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
using System.Xml.Linq;

var phoneBook = new PhoneBook();
phoneBook.AddNumber("mama", "1-333-444-555");
phoneBook.AddNumber("luna", "2-66-444-555");
phoneBook.AddNumber("tata", "3-333-444-555");
phoneBook.AddNumber("zaza", "4-66-444-555");
phoneBook.AddNumber("haha", "5-333-444-555");
phoneBook.AddNumber("gaga", "6-66-444-555");
phoneBook.AddNumber("mama1", "11-333-444-555");
phoneBook.AddNumber("luna1", "12-66-444-555");
phoneBook.AddNumber("tata1", "13-333-444-555");
phoneBook.AddNumber("zaza1", "14-66-444-555");
phoneBook.AddNumber("haha1", "15-333-444-555");
phoneBook.AddNumber("gaga1", "16-66-444-555");

Console.WriteLine(phoneBook.GetNumber("mama"));
Console.WriteLine(phoneBook.GetNumber("luna"));
Console.WriteLine(phoneBook.GetNumber("tata"));
Console.WriteLine(phoneBook.GetNumber("zaza"));
Console.WriteLine(phoneBook.GetNumber("haha"));
Console.WriteLine(phoneBook.GetNumber("gaga"));
Console.WriteLine(phoneBook.GetNumber("mama1"));
Console.WriteLine(phoneBook.GetNumber("luna1"));
Console.WriteLine(phoneBook.GetNumber("tata1"));
Console.WriteLine(phoneBook.GetNumber("zaza1"));
Console.WriteLine(phoneBook.GetNumber("haha1"));
Console.WriteLine(phoneBook.GetNumber("gaga1"));

Console.ReadLine();

public class PhoneBook
{
	KeyValuePair<string, string>[] _numbers;


	public PhoneBook()
	{
		_numbers = new KeyValuePair<string, string>[3];
	}

	public string GetNumber(string name)
	{
		var index = (name.GetHashCode() & 0x7FFFFFFF) % _numbers.Length;
		return _numbers[index].Key + " " + _numbers[index].Value;
	}

	public void AddNumber(string name, string number)
	{
		var index = GetIndex(name);
		while (_numbers[index].Key != null)
		{
			Resize();
			index = (name.GetHashCode() & 0x7FFFFFFF) % _numbers.Length;
		}

		_numbers[index] = new KeyValuePair<string, string>(name, number);
	}

	private int GetIndex(string name) => (name.GetHashCode() & 0x7FFFFFFF) % _numbers.Length;

	private void Resize()
	{
		var newLength = _numbers.Length * 2;
		var newArray = new KeyValuePair<string, string>[newLength];
		foreach (var number in _numbers)
		{
			if (number.Key == null)
				continue;
			var index = (number.Key.GetHashCode() & 0x7FFFFFFF) % newArray.Length;
			newArray[index] = new KeyValuePair<string, string>(number.Key, number.Value);
		}
		_numbers = newArray;
	}
}
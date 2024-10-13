
Func<string, string, string> func = FullName;
Action<Func<string, string, string>> action = PrintFullNames;

action((x, y) => $"firstname has {x.Length} letters, lastName has {y.Length} letters");

string[] cities = ["Gothenburg", "Hamburg", "Maranello", "Stockholm", "Dog"];

Action<string[], Func<string, string>> a2 = WriteArr;
a2(cities, x => x.ToUpper());
Console.WriteLine();
a2(cities, x => x.Substring(0, 3));
Console.WriteLine();
a2(cities, x => x.Length.ToString());

Console.WriteLine();

int[] intArr = { 1, 20, 30, -4, 5, -6, 7, 8, -9, 10 };
Func<int[], Func<int, bool>, int[]> a3 = Ex8;

foreach (var i in a3(intArr, x => x < 0))
{
    Console.Write(i + " ");
}
Console.WriteLine();
foreach (var i in a3(intArr, x => x is >= 10 and <= 20))
{
    Console.Write(i + " ");
}
Console.WriteLine();
foreach (var i in a3(intArr, x => x % 2 == 0))
{
    Console.Write(i + " ");
}

string FullName(string firstName, string lastName)
{
    return $"firstName: {firstName}, lastName: {lastName}";
}

void PrintFullNames(Func<string, string, string> func)
{
    Console.WriteLine(func("a", "b"));
    Console.WriteLine(func("c", "d"));
    Console.WriteLine(func("e", "f"));
}

void WriteArr(string[] arr, Func<string, string> func)
{
    foreach (var x in arr) Console.WriteLine(func(x));
}

int[] Ex8(int[] arr, Func<int, bool> func)
{
    List<int> list = new List<int>();
    foreach (var x in arr) if (func(x)) list.Add(x);

    return list.ToArray();
}



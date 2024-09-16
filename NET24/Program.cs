Cat[] catArray = new Cat[100];


for (int i = 0; i < catArray.Length; i++)
{
    catArray[i] = new Cat() { name = $"Katt{i + 1}", age = i + 1 };
    Console.WriteLine(catArray[i].name);
}

class Cat
{
    public string name = "default name";
    public int age = 0;


}
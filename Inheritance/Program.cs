using System.Reflection.Metadata;
using System.Runtime.CompilerServices;




Shape[] shapes = new Shape[10];

Random random = new Random();
for (int i = 0; i < shapes.Length; i++)
{
    int rndNum = random.Next(0, 2);

    ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
    var rndCol = colors[random.Next(1, colors.Length)];

    if (rndNum == 0)
    {
        shapes[i] = new Circle(random.Next(1, 11), rndCol);
    }
    else { shapes[i] = new Square(random.Next(1, 11), rndCol); }
}



for (int i = 0; i < (ConsoleColor.GetValues(typeof(ConsoleColor))).Length; i++)
{
    ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

    Console.WriteLine(colors[i]);
}

Shape.PrintAll(shapes);
Console.WriteLine();
Shape.PrintCircles(shapes);

enum Brand { Ferrari, Volvo, Toyota, Saab, Porsche }

enum Color { Red, Blue, Yellow, Green, Purple }



class Vehicle
{
    public Brand Brand;
    public Color Color;

    public Size Size;

    Random rnd = new Random();

    public Vehicle(Brand brand)
    {
        Brand = brand;
        Color = Color.Red;
        Size.Length = rnd.Next(2, 5);
        Size.Height = rnd.Next(2, 4);
        Size.Width = rnd.Next(2, 4);
    }

    public Vehicle(Brand brand, Color color)
    {
        Brand = brand;
        Color = color;
        Size.Length = rnd.Next(2, 5);
        Size.Height = rnd.Next(2, 4);
        Size.Width = rnd.Next(2, 4);
    }

    public override string ToString()
    {
        return $"A {Color} {Brand}";
    }

}

class Car : Vehicle
{
    public string Model { get; set; }
    public Car(Brand brand, string model, Color color) : base(brand, color)
    {
        Brand = brand;
        Model = model;
        Color = color;

    }

    public override string ToString()
    {
        return $"A {Color} {Size.Length} meter long {Model} from {Brand}";
    }
}

struct Size
{
    public double Length;
    public double Width;
    public double Height;

    public Size(int length, int width, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}



public abstract class Shape
{
    public abstract double Area { get; }
    public abstract double Circumference { get; }

    protected ConsoleColor color;

    public void Print()
    {
        if (GetType() == typeof(Circle))
        {
            Circle circle = (Circle)this;
            Console.WriteLine($"A circle with side {circle.Radius} has an area of {Area:f2} and a circumference of {Circumference:f2}");
        }

        if (GetType() == typeof(Square))
        {
            Square square = (Square)this;
            Console.WriteLine($"A square with side {square.Width} has an area of {Area:f2} and a circumference of {Circumference:f2}");
        }
    }

    public static void PrintAll(Shape[] shapes)
    {
        foreach (Shape shape in shapes)
        {
            if (shape is Circle) { Console.ForegroundColor = shape.color; }
            else if (shape is Square) { Console.ForegroundColor = shape.color; }

            shape.Print();
            Console.ResetColor();
        }
    }

    public static void PrintCircles(Shape[] shapes)
    {
        foreach (Shape shape in shapes)
        {
            if (shape is Circle)
            {
                shape.Print();
            }
        }
    }
}

class Circle : Shape
{
    public double Radius { get; }

    public override double Area => Math.PI * Radius * Radius;
    public override double Circumference => 2 * Math.PI * Radius;
    //public ConsoleColor Color;
    public Circle(double radius)
    {
        Radius = radius;
    }

    public Circle(double radius, ConsoleColor color) : this(radius)
    {
        this.color = color;
    }

    public override string ToString()
    {
        return $"A circle with radius {Radius}";
    }
}

class Square : Shape
{
    public double Width;

    public override double Area => Width * Width;
    public override double Circumference => 4 * Width;

    public Square(double width)
    {
        Width = width;
    }

    public Square(double width, ConsoleColor color) : this(width)
    {
        this.color = color;
    }

    public override string ToString()
    {
        return $"A square with side {Width}";
    }
}
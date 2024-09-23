/*
 * 1
 * Skapa en klass "Person" som har en private field _firstName, 
 * och en public property FirstName. 
 * När man sätter värdet på FirstName ska detta sparas i _firstName, 
 * och när man läser värdet på FirstName ska den returnera det som finns lagrat i _firstName.
 * 
 * 2
 * Lägg till en publik auto-property LastName som går att både läsa och skriva.
 * 
 * 3
 * Lägg sedan till en publik property FullName som är read only (bara get;)
 * När man läser av propertyn så ska den returnera hela namnet.
 * Testa koden genom att skapa ett objekt, tilldela värden på både FirstName och LastName,
 * och sedan skriva ut FullName.
 * 
 * 4
 * Skapa en klass som kan användas som stegräknare.
 * Den ska ha en property "Steps" som bara går att läsa;
 * en metod Step() som räknar upp Steps med 1 varje gång man anropar den;
 * och en metod Reset() som nollställer räknaren.
 * Instantiera klassen och skriv en loop som motsvarar att man går 1000 steg.
 * Skriv ut värdet på Steps.
 * 
 * 5
 * Skriv en ny klass som motsvarar en bil. 
 * Den ska ha privata fields för modell, pris och färg.
 * Skapa publika properties för att hämta eller ändra värdet på varje field.
 * Skriv en konstruktor till bilklassen som inte tar några parametrar.
 * Skriv en till konstruktor som tar en parameter för varje property som klassen har 
 * och initierar dessa. Hur kan man styra vilken konstruktor som anropas 
 * när man skapar ett objekt av klassen? Skriv en metod till bilklassen med namnet HalfPrice().
 * När den anropas ska priset på bilen sänkas till hälften.
 * 
 * 6
 * Skriv en klass som representerar ett vattenglas.
 * Den ska ha en metod för att fylla glaset, och en metod för att tömma glaset.
 * Dessutom ska den ha en private field som håller reda på om glaset är tomt eller fullt.
 * Beroende på tillståndet (tomt/fullt) så ska metoden som fyller glaset skriva ut antingen
 * “Fyller glaset” eller “Glaset är redan fullt”.
 * Den andra metoden ska skriva ut “Tömmer glaset” eller “Glaset är redan tomt”.
 * Extra övning: Lägg till ytterligare en metod för att slå sönder glaset.
 * Varje glas (instans) ska hålla reda på sitt tillstånd,
 * och skriva ut vad som händer när man kör de olika metoderna.
 * (t.ex “Glaset går sönder, och vattnet rinner ut på golvet”,
 * eller “Glaset kan inte fyllas, eftersom det är trasigt” osv.)
 * 
 * 7
 * Skapa en en klass som har en property “Red” och en property “Blue”.
 * Båda ska vara en double och kunna ha ett värde mellan 0.0 och 100.0
 * men de ska vara “sammankopplade” på så vis att värdena tillsammans alltid är 100.0
 * d.v.s om man t.ex. sätter “Blue” till 8.5 och sedan läser av “Red” så ska den returnera 91.5
 * 
 * 8
 * Skriv en ny klass som representerar en bil. Varje bil ska kunna ha en färg som representeras av en ConsoleColor,
 * samt en längd. När man instansierar en bil så ska den få en random färg, och en random längd (mellan 3 och 5 meter).
 * Instansiera 1000 bilar och spara i en array. Skapa en funktion som tar en array av bilar och returnerar den sammanlagda längden av alla gröna bilar.
 * 
 * 9
 * Lägg till en statisk metod på klassen i uppgift 8.
 * Metoden ska ta en bil som inparameter och returnera en array med 10 bilar i samma färg som bilen man skickat in, men med olika längd.
 * 
 *
 */

using System;

Car[] cars = new Car[10];

for (int i = 0; i < cars.Length; i++)
{
    cars[i] = new Car();
}

bool raceIsOngoing = true;
while (raceIsOngoing)
{
    //raceIsOngoing = false;

    Console.Clear();

    for (int i = 0; i < cars.Length; i++)
    {
        if (cars[i].Distance >= 10000) raceIsOngoing = false;

        Console.WriteLine($"Bil {i}: {cars[i].GetGraph()} {cars[i].Distance} km");
        cars[i].DriveForOneHour();



    }

    Thread.Sleep(1000);
}



class Car
{
    static Random rnd = new Random();

    Array colors = Enum.GetValues(typeof(ConsoleColor));

    public ConsoleColor Color { get; set; }
    public int Length { get; set; }
    public int Speed { get; set; }

    private int _distance = 0;
    public int Distance { get { return _distance; } set { _distance = value; } }


    public Car()
    {
        Color = (ConsoleColor)colors.GetValue(rnd.Next(colors.Length));
        Length = rnd.Next(3, 5+1);
        Speed = rnd.Next(60, 240 + 1);
    }

    public Car(ConsoleColor color)
    {
        Color = color;
        Length = rnd.Next(3, 5 + 1);
        Speed = rnd.Next(60, 240 + 1);
    }

    public static int AllGreenCars(Car[] cars)
    {
        int sumOfLenght = 0;

        foreach (Car c in cars)
        {
            if (c.Color == ConsoleColor.Green)
            {
                sumOfLenght += c.Length; 
            }
            
        }

        return sumOfLenght;
    }

    public static Car[] DupTenCars(Car car)
    {
        Car[] cars = new Car[10];

        for (int i = 0; i < 10; i++) 
        {
            cars[i] = new Car(car.Color);
        }

        return cars;
    }

    public void DriveForOneHour()
    {
        this.Distance += this.Speed;
    }

    public string GetGraph()
    {
        double oneStepPos = 10000/18;

        string carPos = $"|x-----------------|";
        char[] carPosArr = carPos.ToCharArray();

        for (int i = 1; i <= 18; i++)
        {

            if (oneStepPos * (i) >= 10000 || this.Distance >= 10000) {return "|-----------------x|"; }
            if (oneStepPos * (i) > this.Distance && this.Distance >= oneStepPos) 
            {
                carPosArr[1] = '-';
                carPosArr[i] = 'x';
                carPosArr[i-1] = '-';
                return new string(carPosArr); 
            }

        }

        return new string(carPosArr);

    }
}

//enum EColors { Red, Green, Blue, }


class Idk
{
    private double _red;
    private double _blue;

    public double Red { get { return _red; } set { _red = value; _blue = 100 - value; } }
    public double Blue { get { return _blue; } set { _blue = value; _red = 100 - value; } }
}

class WaterGlass
{
    private bool isGlassFull = true;

    public void FillGlass()
    {
        if (isGlassFull) { Console.WriteLine("Glaset är redan fullt"); }
        isGlassFull = true;
    }

    public void EmptyGlass()
    {
        if (!isGlassFull) { Console.WriteLine("Glaset är redan tomt"); }
        isGlassFull = false;
    }
}


class Car2
{
    private string _model;
    private string _color;
    private int _price;

    public string Model { get { return _model; } set { _model = value; } }
    public string Color { get { return _color; } set { _color = value; } }
    public int Price { get { return _price; } set { _price = value; } }

    public Car2() { }

    public Car2(string model, string color, int price)
    {
        _model = model;
        _color = color;
        _price = price;
    }

    public void HalfPrice()
    {
        _price = _price / 2;
    }
}


class StepCounter
{
    private int _steps;
    public int Steps { get { return _steps; } }

    public void Step()
    {
        _steps += 1;
    }

    public void Reset()
    {
        _steps = 0;
    }
}

class Person
{
    private string _firstName;
    
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string Lastname { get; set; }

    public string FullName { get { return $"{FirstName} {Lastname}"; } }

}
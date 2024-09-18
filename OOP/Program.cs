/*
 * Skriv en klass som representerar en person. 
 * Klassen ska ha två publika fält (fields): firstName, lastName. 
 * Skapa två instanser av personer med olika för och efternamn,
 * och använd sedan dessa för att printa ut (hela) namnen på de olika personerna.
 */

/*
 * Uppdatera klassen i uppgift 1 med en metod: public string GetFullName(), 
 * som returnerar en sträng med hela namnet.
 */

/*
 * Uppdatera klassen med en ny metod: 
 * public string GetFullNameReversed() som returnerar en sträng med hela namnet baklänges. 
 * Låt denna metoden använda sig av metoden i uppgift 2.
 */

/*
 * GetFullName ska finnas i två versioner: 
 * en utan parametrar som i uppgift 2; och en där man kan skicka in en titel,
 * t.ex. "Dr." eller "Mr." som returnerar namnet på personen med titeln framför.
 */

/*
 * Uppdatera person-klassen så att varje person kan ha en mamma och en pappa.
 * Dessa representeras som publika fält(fields) av typen Person 
 * (eller vad du kallade klassen i uppgift 1).
 */

/*
 * Gör en instans av en person och ge den ditt för- och efternamn.
 * Lägg även in dina föräldrars namn, kopplade till dig. 
 * Så t.ex myself.GetFullName() returnerar ditt namn, 
 * och myself.mother.GetFullName() returnerar din mammas namn.
 */

Person p1 = new Person() { firstName = "Calle", lastName = "Bjureblad" };
Person p2 = new Person() { firstName = "Kalle", lastName = "Njureblad" };

Console.WriteLine($"{p1.GetFullName()} | {p2.GetFullName()}" );
Console.WriteLine($"{p1.GetFullNameReversed()} | {p2.GetFullNameReversed()}");
Console.WriteLine($"{p1.GetFullName("Mr.")} | {p2.GetFullName("Mr.")}");

Person c = new Person() { firstName = "Calle", lastName = "Bjureblad" };
Person m = new Person() { firstName = "Mamma", lastName = "Efternamn" };
Person d = new Person();

c.mom = m;
c.dad = d;

Console.WriteLine(c.GetSelfAndParents());

c.SetLength(1.80);
Console.WriteLine(c.GetLength());

c.SetWeight(1000);
Console.WriteLine(c.GetWeight());

Console.WriteLine(c.GetBMI());


class Person
{
    public string firstName;
    public string lastName;

    private double lenght;
    private double weight;

    public Person mom;
    public Person dad;

    public string GetFullName() { return $"{firstName} {lastName}"; }

    public string GetFullName(string title) { return $"{title}{firstName} {lastName}"; }

    public string GetFullNameReversed()
    {
        char[] nameArray = GetFullName().ToCharArray();
        Array.Reverse(nameArray);

        return new string(nameArray);
    }

    public string GetSelfAndParents()
    {
        string mother = mom.GetFullName() != " " ? mom.GetFullName() : "okänd";
        string father = dad.GetFullName() != " " ? dad.GetFullName() : "okänd";

        return $"{this.GetFullName()} - {mother} - {father}";

    }

    public void SetLength(double length)
    {
        this.lenght = length;
    }

    public double GetLength()
    {
        return this.lenght;
    }

    public void SetWeight(double weight)
    {
        this.weight = weight;
    }

    public double GetWeight()
    {
        return this.weight;
    }

    public double GetBMI()
    {
        return this.weight / Math.Pow(this.lenght, 2);
    }
}





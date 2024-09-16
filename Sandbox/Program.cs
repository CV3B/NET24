/*
 * Skriv en klass som representerar en person. 
 * Klassen ska ha två publika fält (fields): firstName, lastName. 
 * Skapa två instanser av personer med olika för och efternamn,
 * och använd sedan dessa för att printa ut (hela) namnen på de olika personerna.
 */

Person p1 = new Person() { fristName = "Calle", lastName = "Bjureblad" };
Person p2 = new Person() { fristName = "Kalle", lastName = "Njureblad" };

Console.WriteLine($"{p1.fristName} {p1.lastName} | {p2.fristName} {p2.lastName}");
class Person
{
    public string fristName;
    public string lastName;


}
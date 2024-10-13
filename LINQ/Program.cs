var people = new[]
{
    new { FirstName = "John", LastName = "Doe", Age = 27, Height = 190, Weight = 85 },
    new { FirstName = "John", LastName = "Pork", Age = 45, Height = 185, Weight = 145 },
    new { FirstName = "Calle", LastName = "Skalle", Age = 21, Height = 180, Weight = 75 },
    new { FirstName = "Charles", LastName = "Leclerc", Age = 26, Height = 175, Weight = 70 },
    new { FirstName = "Enzo", LastName = "Ferrari", Age = 57, Height = 181, Weight = 80 },
    new { FirstName = "Haj", LastName = "Doe", Age = 18, Height = 160, Weight = 55 },
    new { FirstName = "Haha", LastName = "Doe", Age = 17, Height = 180, Weight = 80 },
    new { FirstName = "Yippie", LastName = "Trinken", Age = 80, Height = 188, Weight = 95 }
};

var people20To40 = people.Where(people => people.Age >= 20 && people.Age <= 40);
var People20To40Query = from p in people where p.Age >= 20 && p.Age <= 40 select p;

var people20To40Over190 = people20To40.Where(p => p.Height >= 190);
var people20To40Over190Query = from p in people20To40 where p.Height >= 190 select p;

var firstNameLargerThenLastName = people
    .Where(p => p.FirstName.Length > p.LastName.Length)
    .Select(p => new { firstName = p.FirstName, lastName = p.LastName })
    .ToList();
var firstNameLargerThenLastNameQuery =
    from p in people
    where p.FirstName.Length > p.LastName.Length
    select new { firstName = p.FirstName, lastName = p.LastName };

var BMI = people.Select(p => new
{ Name = p.FirstName + " " + p.LastName, BMI = p.Weight / Math.Pow((p.Height / 100.0), 2) }).ToList();
var BMIQuery = from p in people
               select new { Name = p.FirstName + " " + p.LastName, BMI = p.Weight / Math.Pow((p.Height / 100.0), 2) };

var BMIUnder20OrOver25 = BMI.Where(p => p.BMI < 20 || p.BMI > 25);
var BMIUnder20OrOver25Query = from p in BMI where p.BMI < 20 && p.BMI > 25 select p;

var BMIUnder20OrOver25List = people.Where(p =>
{
    double BMI = Math.Pow((p.Height / 100.0), 2);
    return BMI < 20 || BMI > 25;
});
var BMIUnder20OrOver25ListQuery =
    from p in people
    let bmi = Math.Pow((p.Height / 100.0), 2)
    where bmi < 20 || bmi > 25
    select p;

var users = people.Select(p => new
{ Username = p.FirstName + p.Age, Catagory = p.Age >= 18 ? "Adult" : "Child" }).ToList();
var usersQuery =
    from p in people
    select new
    { Username = p.FirstName + p.Age, Catagory = p.Age >= 18 ? "Adult" : "Child" };

var sortPeople = people.OrderBy(p => p.FirstName);

var sortPeopleAge = people.OrderByDescending(p => p.Age);

var sortPeopleName = people.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);

var oneBillion = Enumerable.Range(1, 1_000_000_000).AsParallel().Where(i => i % 3 == 0 || i % 5 == 0).Select(i => (long)i).Sum();
//12,240 ms
// 953 ms
Console.WriteLine(oneBillion);


using LinqToObjectsApp;

List<Person> people = new List<Person>
        {
            new Person { Name = "Pawan", Age=22 , Country="INDIA"},
            new Person { Name = "John", Age = 25, Country = "USA" },
            new Person { Name = "Nitin", Age=22 , Country="INDIA"},
            new Person { Name = "Divyansh", Age=22 , Country="INDIA"},
            new Person { Name = "Jane", Age = 30, Country = "Canada" },
            new Person { Name = "Mark", Age = 28, Country = "USA" },
            new Person { Name = "Emily", Age = 22, Country = "Australia" }
        };

//Write queries using LINQ for following operations
//1. Get all people from USA
//2. Get all people above 30
//3. Sort people by name
//4. Project/Select only Name and Country of all people




List<Person> peopleFromINDIA = people.Where(p => p.Country == "INDIA").ToList();
List<Person> peopleAbove25 = people.Where(p => p.Age > 25).ToList();
List<Person> sortedPeopleByName = people.OrderBy(p => p.Name).ToList();
var nameAndCountry = people.Select(p => new { p.Name, p.Country });

Console.WriteLine("People from INDIA:");
foreach (var person in peopleFromINDIA)
{
    Console.WriteLine($"Name: {person.Name}, Country: {person.Country}");
}

Console.WriteLine("\nPeople above 25:");
foreach (var person in peopleAbove25)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}

Console.WriteLine("\nPeople sorted by name:");
foreach (var person in sortedPeopleByName)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Country}");
}

Console.WriteLine("\nName and Country of all people:");
foreach (var person in nameAndCountry)
{
    Console.WriteLine($"Name: {person.Name}, Country: {person.Country}");
}
namespace LinqToObjectsApp
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
   

}
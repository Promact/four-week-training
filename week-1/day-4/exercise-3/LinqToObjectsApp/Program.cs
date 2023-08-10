using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }

    public Person(string name, int age, string country)
    {
        Name = name;
        Age = age;
        Country = country;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person("John", 30, "USA"),
            new Person("Jane", 25, "Canada"),
            new Person("Michael", 40, "UK"),
            new Person("Emily", 28, "Australia"),
            new Person("David", 35, "USA")
        };

        // Use LINQ to filter people above a certain age
        int minAge = 30;
        var aboveMinAge = people.Where(p => p.Age > minAge).ToList();
        Console.WriteLine("People above " + minAge + " years old:");
        foreach (var person in aboveMinAge)
        {
            Console.WriteLine($"{person.Name}, Age: {person.Age}, Country: {person.Country}");
        }
        Console.WriteLine();

        // Use LINQ to sort the list by name in ascending order
        var sortedByName = people.OrderBy(p => p.Name).ToList();
        Console.WriteLine("People sorted by name:");
        foreach (var person in sortedByName)
        {
            Console.WriteLine($"{person.Name}, Age: {person.Age}, Country: {person.Country}");
        }
        Console.WriteLine();

        // Use LINQ to project the list into a new list with Name and Country properties
        var projectedList = people.Select(p => new { p.Name, p.Country }).ToList();
        Console.WriteLine("Projected list with Name and Country properties:");
        foreach (var item in projectedList)
        {
            Console.WriteLine($"Name: {item.Name}, Country: {item.Country}");
        }
        Console.WriteLine();

        Console.ReadKey();
    }
}

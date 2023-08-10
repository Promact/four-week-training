using System.Runtime.Intrinsics.X86;
using System;

namespace LinqFilterAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            List<Person> people = new List<Person>
            {
                new Person { FirstName = "Sachin", LastName = "Tendulkar", Age = 50 },
                new Person { FirstName = "Virat", LastName = "Kohli", Age = 32 },
                new Person { FirstName = "MS", LastName = "Dhoni", Age = 40 },
                
            };

            // Use LINQ to filter and sort the list
            var filteredAndSorted = people
                .Where(person => person.Age >= 18)
                .OrderBy(person => person.LastName)
                .ThenBy(person => person.FirstName)
                .ToList();

            // Print the filtered and sorted list of people to the console
            foreach (var person in filteredAndSorted)
            {
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Age: {person.Age}");
            }
           
        }
    }
}
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

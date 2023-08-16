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
                new Person { FirstName = "John", LastName = "Doe", Age = 30 },
                new Person { FirstName = "Jane", LastName = "Smith", Age = 25 },
                new Person { FirstName = "Michael", LastName = "Johnson", Age = 40 },
                new Person { FirstName = "Emily", LastName = "Davis", Age = 28 }
            };

            // Use LINQ to filter and sort the list
            var filteredAndSorted = people
                .Where(person => person.Age >= 30) // Filter people with age >= 30
                .OrderBy(person => person.LastName) // Sort by last name
                .ThenBy(person => person.FirstName); // Then sort by first name

            // Print the filtered and sorted list of people to the console
            foreach (var person in filteredAndSorted)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}, Age: {person.Age}");
            }
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
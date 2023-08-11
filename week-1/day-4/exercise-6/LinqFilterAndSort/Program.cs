using System;

namespace LinqFilterAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            // Use LINQ to filter and sort the list
            // Print the filtered and sorted list of people to the console
            List<Person> people = new List<Person>
            {
            new Person { Name = "pawan", Age = 22 },
            new Person { Name = "piyush", Age = 10 },
            new Person { Name = "divyansh", Age = 22 },
            new Person { Name = "krishna", Age = 48 },
            new Person { Name = "nitin", Age = 22 }
        };

            List<Person> filteredAndSorted = people.Where(person => person.Age > 21)
                .OrderBy(person => person.Age).ToList();       
            Console.WriteLine("Filtered and Sorted People:");
            foreach (var person in filteredAndSorted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
                
            }
            Console.ResetColor();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
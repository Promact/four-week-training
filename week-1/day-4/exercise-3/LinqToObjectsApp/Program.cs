using System.Collections.Generic;


namespace LinqToObjectsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "John", Age = 25, Country = "USA" },
                new Person { Name = "Jane", Age = 30, Country = "Canada" },
                new Person { Name = "Mark", Age = 28, Country = "USA" },
                new Person { Name = "Emily", Age = 22, Country = "Australia" }
            };


            //Write queries using LINQ for following operations
            //1. Get all people from USA
            //2. Get all people above 30
            //3. Sort people by name
            //4. Project/Select only Name and Country of all people
            var peopleFromUSA = people.Where(person => person.Country == "USA").ToList();

            //  usa ppl
            Console.WriteLine("People from USA:");
            foreach (var person in peopleFromUSA)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }

            //     30+
            var peopleAbove30 = people.Where(person => person.Age > 30).ToList();

            Console.WriteLine("\nPeople above 30:");
            foreach (var person in peopleAbove30)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }

            //   name sort
            var sortedPeople = people.OrderBy(person => person.Name).ToList();

            Console.WriteLine("\nPeople sorted by name:");
            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }

            //  name,country
            var projectedPeople = people.Select(person => new { person.Name, person.Country }).ToList();

            Console.WriteLine("\nProjected list (Name and Country):");
            foreach (var person in projectedPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Country}");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public string Country { get; set; }
        
    }
}

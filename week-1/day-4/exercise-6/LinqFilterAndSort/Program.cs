using System;

namespace LinqFilterAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            List<Person> peopleList = new List<Person>()
            {
                new Person { FirstName = "Prince", LastName = "Kumar", Age = 16, },
                new Person { FirstName = "Sumant", LastName = "Kumar", Age = 18, },
                new Person { FirstName = "Alok", LastName = "Anand", Age = 25, },
                new Person { FirstName = "ShashiKant", LastName = "Singh", Age = 57, }
            };

            //1.  filter the list to only include people who are 18 years old or older.
            var aboveCertainAge = peopleList.Where(people => people.Age >= 18);

            //2. Sort people by name
            var sortedPeople = peopleList.OrderBy(people => people.LastName).ThenBy(people => people.FirstName).ToList();

            Console.WriteLine("People who are 18 years old or older:");
            foreach (var people in aboveCertainAge)
            {
                Console.WriteLine($"{people.FirstName} {people.LastName}, Age {people.Age}");
            }

            Console.WriteLine("\nSorted by Name: ");
            Console.WriteLine($"LastName\t FirstName");
            foreach (var people in sortedPeople)
            {
                Console.WriteLine($"{people.LastName}\t\t {people.FirstName}");
            }
        }
    }
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

    }
}
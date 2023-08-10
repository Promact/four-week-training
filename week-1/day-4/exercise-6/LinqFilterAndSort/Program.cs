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
            new Person { FirstName = "Sakshi", LastName = "Kachhi", Age = 30 },
            new Person { FirstName = "Riya", LastName = "Sharma", Age = 33 },
            new Person { FirstName = "Aisha", LastName = "Singh", Age = 18 },
            new Person { FirstName = "Janvi", LastName = "Thakkar", Age = 21 },
            new Person { FirstName = "Parth", LastName = "Parmar", Age = 25 },
            new Person { FirstName = "Henny", LastName = "Patel", Age = 14 }
        };

            // Use LINQ to filter the list to people who are 18 years old or older
            var filteredList = people.Where(person => person.Age >= 18).ToList();

            // Use LINQ to sort the filtered list by last name, then by first name
            var sortedList = filteredList.OrderBy(person => person.LastName).ThenBy(person => person.FirstName).ToList();

            // Print the filtered and sorted list to the console
            Console.WriteLine("Filtered and Sorted List:");


            foreach (var person in sortedList)
            {
                Console.WriteLine($"First Name: {person.FirstName}, Last Name: {person.LastName}, Age: {person.Age}");
            }
        }

    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}

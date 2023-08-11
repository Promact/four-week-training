using System;

namespace LinqFilterAndSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            // Use LINQ to filter and sort the list
            // Print the filtered and sorted list of people to the console

            // Create a list of Person objects
            List<Person> people = new List<Person>
            {
                new Person { FirstName = "Vipul", LastName = "Kumar", Age = 24 },
                new Person { FirstName = "Divyanshu", LastName = "Kumar", Age = 25 },
                new Person { FirstName = "Rahul", LastName = "Yadav", Age = 22 },
                new Person { FirstName = "Ashish", LastName = "Kumar", Age = 21 },
                new Person { FirstName = "Atul", LastName = "Tiwari", Age = 17 },
                new Person { FirstName = "Abhi", LastName = "Upadhyay", Age = 12 }
            };

            // Use LINQ to filter people who are 18 years old or older
            List<Person> FilteredPeople = people.Where(person => person.Age >= 18).ToList();

            // Use LINQ to sort the filtered list by last name, then by first name
            List<Person> SortedPeople = FilteredPeople.OrderBy(person => person.LastName).ThenBy(person => person.FirstName).ToList();

            // Print the filtered and sorted list of people to the console
            Console.WriteLine("Filtered and Sorted People : ");
            foreach (var person in SortedPeople)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}, Age : {person.Age}");
            }
        }
    }
}
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

            //1. Get all people from USA
            var peopleFromUSA = people.Where(person => person.Country == "USA");

            Console.WriteLine("All People from USA:");
            foreach (var person in peopleFromUSA)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Country}");
            }

            // 2. Get all people above 30
            var peopleAbove30 = people.Where(person => person.Age > 30);

            Console.WriteLine("All People above 30:");
            foreach (var person in peopleAbove30)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Country}");
            }

            // 3. Sort people by name
            var sortedPeopleByName = people.OrderBy(person => person.Name);

            Console.WriteLine("People Sorted by Name:");
            foreach (var person in sortedPeopleByName)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Country}");
            }

            // 4. Project/Select only Name and Country of all people
            var projectedPeople = people.Select(person => new { person.Name, person.Country });

            Console.WriteLine("Projected List (Name and Country):");
            foreach (var item in projectedPeople)
            {
                Console.WriteLine($"Name: {item.Name}, Country: {item.Country}");
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
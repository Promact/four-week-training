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


            // 1. Get all people from USA
            var peopleFromUSA = people.Where(person => person.Country == "USA");
            Console.WriteLine("People from USA:");
            foreach (var person in peopleFromUSA)
            {
                Console.WriteLine($"{person.Name}, Age: {person.Age}, Country: {person.Country}");
            }

            // 2. Get all people above 30
            var peopleAbove30 = people.Where(person => person.Age > 30);
            Console.WriteLine("\nPeople above 30:");
            foreach (var person in peopleAbove30)
            {
                Console.WriteLine($"{person.Name}, Age: {person.Age}, Country: {person.Country}");
            }

            // 3. Sort people by name
            var sortedPeopleByName = people.OrderBy(person => person.Name);
            Console.WriteLine("\nPeople sorted by name:");
            foreach (var person in sortedPeopleByName)
            {
                Console.WriteLine($"{person.Name}, Age: {person.Age}, Country: {person.Country}");
            }

            // 4. Project/Select only Name and Country of all people
            var projectedPeople = people.Select(person => new { person.Name, person.Country });
            Console.WriteLine("\nProjected list with Name and Country properties:");
            foreach (var person in projectedPeople)
            {
                Console.WriteLine($"{person.Name}, Country: {person.Country}");
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
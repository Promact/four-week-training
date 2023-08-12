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
            List<Person> PeopleFromUSA = people.Where(person => person.Country == "USA").ToList();
            Console.WriteLine("People from USA :");
            foreach (var person in PeopleFromUSA)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }

            // Get all people above 30
            List<Person> PeopleAbove30 = people.Where(person => person.Age > 30).ToList();
            Console.WriteLine("People from above 30 :");
            foreach (var person in PeopleAbove30)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }

            // Sort people by name
            List<Person> SortedByName = people.OrderBy(person => person.Name).ToList();
            Console.WriteLine("People sorted by name:");
            foreach (var person in SortedByName)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Country}");
            }

            // Project/Select only Name and Country of all people            
            var NameAndCountryList = people.Select(person => new { person.Name, person.Country }).ToList();

            Console.WriteLine("\nName and Country list:");
            Console.WriteLine("Name => Country");
            foreach (var item in NameAndCountryList)
            {
                Console.WriteLine($"{item.Name} => {item.Country}");
            }

        }
    }

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Country { get; set; }
    }
}
namespace LinqToObjectsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>
            {
                new Person { Name = "John", Age = 25, Country = "USA" },
                new Person { Name = "Jane", Age = 31, Country = "Canada" },
                new Person { Name = "Mark", Age = 28, Country = "USA" },
                new Person { Name = "Emily", Age = 22, Country = "Australia" }
            };


            //Write queries using LINQ for following operations
            //1. Get all people above 30
            var aboveCertainAge = peopleList.Where(people => people.Age > 30);

            //2. Sort people by name
            var sortByName = peopleList.OrderBy(people => people.Name).ToList();

            //3. Project/Select only Name and Country of all people
            var byNameAndCountry = peopleList.Select(people => new { people.Name, people.Country }).ToList();

            Console.WriteLine("Peoples above 30 are:");
            foreach (var people in aboveCertainAge)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }

            Console.WriteLine("\nSorted by Name: ");
            foreach (var people in sortByName)
            {
                Console.WriteLine(people.Name);
            }
            Console.WriteLine("\nPeople's Name and Country details: ");
            foreach (var people in byNameAndCountry)
            {
                Console.WriteLine(people.Name + " " + people.Country);

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
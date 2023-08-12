using System.Security.Cryptography.X509Certificates;

namespace Day4_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Person> listPerson = new Stack<Person>();
            listPerson.Push(new Person("Hiren",12,"India"));
            listPerson.Push(new Person("Chirag", 32, "India"));
            listPerson.Push(new Person("Yash", 21, "India"));
            listPerson.Push(new Person("DKP ",23, "India"));
            listPerson.Push(new Person("Ronak",18,"India"));

            Console.WriteLine("Please write minimum age : ");
            int minAge = Convert.ToInt32(Console.ReadLine());

            var peopleAboveAge = listPerson.Where(person => person.age > minAge);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var person in peopleAboveAge)
            {
                Console.WriteLine($"Name: {person.name}, Age: {person.age}, Country: {person.country}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ascending Order : ");

            Console.ForegroundColor = ConsoleColor.Green;
            var ascendingOrder = listPerson.OrderBy(person => person.name);

            foreach (var person in ascendingOrder)
            {
                Console.WriteLine($"Name: {person.name}, Age: {person.age}, Country: {person.country}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            var projectedList = listPerson.Select(person => new { person.name, person.country });

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nProjected List with Name and Country:");
            foreach (var person in projectedList)
            {
                Console.WriteLine($"Name: {person.name}, Country: {person.country}");
            }

        }
    }

    public class Person
    {
        public String name, country;
        public int age;

        public Person(String name,int age,String country)
        {
            this.name = name;
            this.age = age;
            this.country = country;
        }
    }
}
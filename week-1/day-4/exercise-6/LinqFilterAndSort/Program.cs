namespace Day4_Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Person> listPerson = new Stack<Person>();
            listPerson.Push(new Person("Hiren", "Chavda", 22));
            listPerson.Push(new Person("Chirag", "Thaker", 23));
            listPerson.Push(new Person("Yash", "Miyatra", 18));
            listPerson.Push(new Person("Ronak", "Dattani", 12));
            listPerson.Push(new Person("Jayesh", "Parmar", 17));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Person with older than 18 : ");

            var agedPerson = listPerson.Where(person => person.age < 18);

            Console.ForegroundColor = ConsoleColor.Yellow;


            foreach (var person in agedPerson)
            {
                Console.WriteLine("Name : " + person.firstName + "\n Last name : " + person.lastName + " \n age : " + person.age);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sort by last name : ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            var sortPerson = agedPerson.OrderBy(person => person.lastName).ToList();

            foreach (var person in sortPerson)
            {
                Console.WriteLine("Name : " + person.firstName + "\n Last name : " + person.lastName + " \n age : " + person.age);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sort by first name : ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            var sortPersonFirstName = sortPerson.OrderBy(person => person.firstName).ToList();

            foreach (var person in sortPersonFirstName)
            {
                Console.WriteLine("Name : " + person.firstName + "\n Last name : " + person.lastName + " \n age : " + person.age);
            }

        }
    }

    public class Person
    {
        public String firstName, lastName;
        public int age;
        public Person(String firstName, String lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }

}
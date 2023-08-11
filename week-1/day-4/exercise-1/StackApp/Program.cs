namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomStack<int> intStack = new CustomStack<int>();

            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);

            Console.WriteLine(intStack.Pop()); // Output: 3
            Console.WriteLine(intStack.Pop()); // Output: 2
            Console.WriteLine(intStack.IsEmpty() + "\n"); // Output: False

            ICustomStack<string> stringStack = new CustomStack<string>();

            stringStack.Push("Ashish");
            stringStack.Push("Vipul");

            Console.WriteLine(stringStack.Pop()); // Output: Vipul
            Console.WriteLine(stringStack.Pop()); // Output: Ashish
            Console.WriteLine(stringStack.IsEmpty() + "\n"); // Output: True

            //Custom Object.
            ICustomStack<Person> personStack = new CustomStack<Person>();

            personStack.Push(new Person("Krishna", 20));
            personStack.Push(new Person("Ashish", 22));

            Console.WriteLine(personStack.Pop()); // Output: {Name = Ashish, Age = 22}
            Console.WriteLine(personStack.IsEmpty()); // Output: False

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Person{{Name = {Name}, Age = {Age}}}";
        }
    }
}
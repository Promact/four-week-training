using System;

namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ICustomStack<int> intStack = new CustomStack<int>();
            //intStack.Push(1);
            //intStack.Push(2);
            //intStack.Push(3);
            //Console.WriteLine(intStack.Pop()); // Output: 3
            //Console.WriteLine(intStack.Pop()); // Output: 2
            //Console.WriteLine(intStack.IsEmpty()); // Output:
            Stack<int> intStack = new Stack<int>();
            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(30);

            Console.WriteLine("Popped: " + intStack.Pop()); // Output: Popped: 30
            Console.WriteLine("Popped: " + intStack.Pop()); // Output: Popped: 20

            // Test with strings
            Stack<string> stringStack = new Stack<string>();
            stringStack.Push("Hello");
            stringStack.Push("World");

            Console.WriteLine("Popped: " + stringStack.Pop()); // Output: Popped: World

            // Test with custom objects
            Stack<Person> personStack = new Stack<Person>();
            personStack.Push(new Person("Alice", 25));
            personStack.Push(new Person("Bob", 30));

            Person poppedPerson = personStack.Pop();
            Console.WriteLine("Popped Person: " + poppedPerson); // Output: Popped Person: Name: Bob, Age: 30
        }


        class Person
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
                return $"Name: {Name}, Age: {Age}";
            }
        }

    }
}
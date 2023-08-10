using System;

namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> intstack = new Stack<int>();
            intstack.Push(1);
            intstack.Push(2);
            intstack.Push(3);
            intstack.Push(4);
            intstack.Push(5);
            Console.WriteLine(intstack.Pop()); //out=5

            Stack<string> stringstack = new Stack<string>();
            stringstack.Push("Namaste");
            stringstack.Push("Kem");
            stringstack.Push("Cho");
            stringstack.Push("Maja");
            stringstack.Push("ma");
            Console.WriteLine(stringstack.Pop()); //out=ma

            Stack<Person> PersonStack = new Stack<Person>();
            PersonStack.Push(new Person("Divyansh", 22));
            PersonStack.Push(new Person("Arpit", 23));
            PersonStack.Push(new Person("Mradul", 22));
            PersonStack.Push(new Person("Devyan", 23));
            PersonStack.Push(new Person("Pawan", 23));
            Console.WriteLine(PersonStack.Pop().Name); //out=pawan
        }
    }
}
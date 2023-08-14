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
            Console.WriteLine(intStack.IsEmpty()); // Output: False
        }
    }
}
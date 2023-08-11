namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Stack with different types : Integer");

            Stack<int> stack = new Stack<int>();
            stack.push(1);
            stack.push(2);
            stack.push(3);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Is stack empty or not : " + stack.isEmpty());
            Console.WriteLine("Popped element : " + stack.pop());
            Console.WriteLine("Popped element : " + stack.pop());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Stack with different types : String");
            Stack<string> stringStack = new Stack<string>();
            stringStack.push("Hello");
            stringStack.push("World");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Is string empty? " + stringStack.isEmpty());
            Console.WriteLine("Popped: " + stringStack.pop());
            Console.WriteLine("Is string empty? " + stringStack.isEmpty());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Stack with different types : CustomObject");

            Stack<CustomObject> customObjectStack = new Stack<CustomObject>();
            customObjectStack.push(new CustomObject(12));
            customObjectStack.push(new CustomObject(13));
            customObjectStack.push(new CustomObject(13));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Is string empty? " + customObjectStack.isEmpty());
            Console.WriteLine("Popped element : " + customObjectStack.pop().Value);




        }
    }
}
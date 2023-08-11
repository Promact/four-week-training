namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomStack<int> intstack = new CustomStack<int>();
            intstack.Push(1);
            Console.WriteLine("pushed 1");
            intstack.Push(2);
            Console.WriteLine("pushed 2");
            intstack.Push(3);

            Console.WriteLine("pushed 3");
            //ICustomStack<int> intStack = new CustomStack<int>();
            //intStack.Push(1);
            //intStack.Push(2);
            //intStack.Push(3);
         
            Console.WriteLine("poped "+ intstack.Pop());
            Console.WriteLine("poped "+ intstack.Pop());

            Console.WriteLine("not empty !"+intstack.IsEmpty());
        }
    }
}
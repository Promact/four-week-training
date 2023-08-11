namespace IteratorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Display the Fibonacci sequence up to the ten number.
            Console.WriteLine("Fibonacci Sequence is: ");
            foreach (var i in FibonacciSequence(10))
            {
                Console.Write(i + " ");
            }
        }
        // https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
        public static IEnumerable<int> FibonacciSequence(int length)
        {
            int a = 0, b = 1;

            for (int i = 0; i < length; i++)
            {
                yield return a;
                int c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
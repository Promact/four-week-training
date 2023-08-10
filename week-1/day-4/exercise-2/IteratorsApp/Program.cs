namespace IteratorsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fibonacci = FibonacciSequence().Take(10);
            foreach (int number in fibonacci)
            {
                Console.WriteLine(number);
            }
        }
        // https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
        public static IEnumerable<int> FibonacciSequence()
        {
            int first = 0;
            int second = 1;

            yield return first;
            yield return second;

            // Generating the first 10 Fibonacci numbers
            for (int i = 2; i < 10; i++)
            {
                int next = first + second;
                yield return next;
                first = second;
                second = next;
            }
        }
    }
}
namespace IteratorsApp
{
    internal class Program
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
            int number1 = 0;
            int number2 = 1;

            for (int i = 0; i < int.MaxValue; i++)
            {
                yield return number1;

                int next = number1 + number2;
                number1 = number2;
                number2 = next;
                //throw new NotImplementedException();
            }
        }
    }
}
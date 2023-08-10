namespace IteratorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fibonacci = FibonacciSequence().Take(10);
            Console.WriteLine("PROGRAM TO DISPLAY 10 NUMBERS IN THE FIBONACCI SEQUENCE");
            foreach (int number in fibonacci)
            {
                Console.WriteLine(number);
            }
        }
        //https://www.c-sharpcorner.com/uploadfile/5ef30d/understanding-yield-return-in-c-sharp/
        //// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
        public static IEnumerable<int> FibonacciSequence()
        {
            List<int> fibonacci = new List<int>();
            int a = 0, b = 1;
            fibonacci.Add(a); 
            fibonacci.Add(b);


            for (int i = 2; i < 10; i++) 
            {
                int c = a + b;
                fibonacci.Add(c);
                a = b;
                b = c;
            }

            return fibonacci;
            throw new NotImplementedException();
        }
    }
}
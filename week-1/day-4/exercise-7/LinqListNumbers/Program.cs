namespace LinqListNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of integers
            List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

            // Use LINQ to perform the following operations:
            // 1. Find all even numbers
            // 2. Find all numbers greater than a specific value (e.g., 20)
            // 3. Calculate the sum of all numbers
            // 4. Calculate the average of all numbers
            // 5. Find the minimum and maximum values in the list

            List<int> evenNumbers = numbers.Where(num => num % 2 == 0).ToList();

            int specificValue = 20;
            List<int> greaterValue = numbers.Where(num => num > specificValue).ToList();

            int sum = numbers.Sum();

            double average = numbers.Average();

            int minimum = numbers.Min();
            int maximum = numbers.Max();

           
            Console.WriteLine("Even Numbers:");

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (int num in evenNumbers)
            {
                Console.Write(num + " ");
            }
            Console.ResetColor();
            Console.WriteLine("\nNumbers Greater Than " + specificValue + ":");

            Console.ForegroundColor = ConsoleColor.Blue ;
            foreach (int num in greaterValue)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\nSum: " + sum);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Average: " + average);
            Console.ResetColor();
            Console.WriteLine("Minimum: " + minimum);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Maximum: " + maximum);
            Console.ResetColor();
        }
    }
}
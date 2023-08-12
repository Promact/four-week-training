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
            Console.WriteLine("All even numbers are.");
            var evenNumbers = numbers.Where(num => num % 2 == 0).ToList();
            foreach (int number in evenNumbers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(number + " ");
                Console.ResetColor();
            }

            // 2. Find all numbers greater than a specific value (e.g., 20)
            Console.WriteLine("\n\nAll numbers greater then 20 are.");
            var greaterThenSpecific = numbers.Where(num => num > 20).ToList();
            foreach (int number in greaterThenSpecific)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(number + " ");
                Console.ResetColor();
            }

            // 3. Calculate the sum of all numbers
            int sum = numbers.Sum();
            Console.WriteLine("\n\nSum of all numbers: " + sum);

            // 4. Calculate the average of all numbers
            double average = numbers.Average();
            Console.WriteLine("\nAverage of all numbers: " + average);

            // 5. Find the minimum and maximum values in the list
            int min = numbers.Min();
            Console.WriteLine("\nMinimum of all numbers: " + min);

            int max = numbers.Max();
            Console.WriteLine("\nMaximum of all numbers: " + max);
        }
    }
}
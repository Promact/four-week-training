using System.Runtime.Intrinsics.X86;

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
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even Numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            // 2. Find all numbers greater than a specific value (e.g., 20)
            int specificValue = 20;
            var greaterThanSpecific = numbers.Where(n => n > specificValue);
            Console.WriteLine("Numbers Greater Than " + specificValue + ":");
            foreach (var num in greaterThanSpecific)
            {
                Console.WriteLine(num);
            }
            // 3. Calculate the sum of all numbers
            int sum = numbers.Sum();
            Console.WriteLine("Sum of Numbers: " + sum);

            // 4. Calculate the average of all numbers
            double average = numbers.Average();
            Console.WriteLine("Average of Numbers: " + average);

            // 5. Find the minimum and maximum values in the list
            int min = numbers.Min();
            int max = numbers.Max();
            Console.WriteLine("Minimum Value: " + min);
            Console.WriteLine("Maximum Value: " + max);
        
        }
    }
}

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

            // a. Find all even numbers
            var evenNumbers = numbers.Where(num => num % 2 == 0);

            Console.WriteLine("Even numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            // b. Find all numbers greater than a specific value (e.g., 20)
            int minimumValue = 20;
            var largerThanMin = numbers.Where(num => num > minimumValue);

            Console.WriteLine("\nNumbers greater than " + minimumValue + ":");
            foreach (var num in largerThanMin)
            {
                Console.WriteLine(num);
            }

            // c. Calculate the sum of all numbers
            int add = numbers.Sum();

            Console.WriteLine("\nSum of all numbers: " + add);

            // d. Calculate the average of all numbers
            double avg = numbers.Average();

            Console.WriteLine("Average of all numbers: " + avg);

            // e. Find the minimum and maximum values in the list
            int minimum = numbers.Min();
            int maximum = numbers.Max();

            Console.WriteLine("The Minimum value in the list: " + minimum);
            Console.WriteLine("The Maximum value in the list: " + maximum);
        }

    }
    
}
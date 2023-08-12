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

            // Find all even numbers
            List<int> EvenNumbers = numbers.Where(num => num % 2 == 0).ToList();
            Console.WriteLine("Even Numbers: " + string.Join(", ", EvenNumbers));

            // Find all numbers greater than a specific value (e.g., 20)
            int specificValue = UserInput();
            List<int> greaterThanSpecificValue = numbers.Where(num => num > specificValue).ToList();
            Console.WriteLine("Numbers Greater Than " + specificValue + ": " + string.Join(", ", greaterThanSpecificValue));

            // Calculate the sum of all numbers
            int sum = numbers.Sum();
            Console.WriteLine("Sum of Numbers: " + sum);

            // Calculate the average of all numbers
            double average = numbers.Average();
            Console.WriteLine("Average of Numbers: " + average);

            // Find the minimum and maximum values in the list
            int minimum = numbers.Min();
            int maximum = numbers.Max();
            Console.WriteLine("Minimum Value: " + minimum);
            Console.WriteLine("Maximum Value: " + maximum);
        }

        // Take user input integer only uaer can be only able to type integer number
        // Here negative number is also allowed
        private static int UserInput()
        {
            ConsoleKeyInfo key;
            string input = "";

            Console.Write("Enter Specific number : ");

            do
            {
                key = Console.ReadKey(true);
                if (char.IsDigit(key.KeyChar))
                {
                    input += key.KeyChar;

                    // Display the digit
                    Console.Write(key.KeyChar);
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);

                    // Erase the last character from display
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            // Move to the next line
            Console.WriteLine();

            int number = Convert.ToInt32(input);
            return number;
        }
    }
}
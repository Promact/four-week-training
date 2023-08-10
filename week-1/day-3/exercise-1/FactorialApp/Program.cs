namespace FactorialApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int value;

            // User input
            Console.Write("Enter the number to find factorial: ");
            string? input = Console.ReadLine(); // Read user input as a string. Because ReadLine function always return string.

            try
            {
                // Parse the input string as an integer.
                value = int.Parse(input);

                if (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Factorial of negative numbers can't be found.");
                }
                else
                {
                    // Here the Recursive Factorial method is being called and then display the factorial.
                    long fact = Fact(value);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Factorial of given number {input} is: " + fact);
                }

            }
            catch (FormatException)
            {
                // Handle the user input if the user entered wrong input.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The given input '{input}' is not an integer. Input should be an integer only.");
            }
            Console.ResetColor();
        }

        // Recursive method to calculate the factorial of a given value.
        static long Fact(int value)
        {
            if (value == 0 || value == 1)
            {
                return 1;
            }
            else
            {
                return (value * Fact(value - 1));
            }
        }
    }
}
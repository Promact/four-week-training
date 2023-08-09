using System;

namespace FactorialApp
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, World!");
            Console.Write("Enter a number: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput < 0)
            {
                Console.WriteLine("Factorial is not valid for negative numbers.");
            }
            else
            {
                long result = CalculateFactorial(userInput);
                Console.WriteLine($"Factorial of {userInput} is {result}");
            }
        }

        public static long CalculateFactorial(int number)
        {
           // throw new NotImplementedException();
            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
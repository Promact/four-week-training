using System;

namespace FactorialApp
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            long factorial = CalculateFactorial(number);

            Console.WriteLine($"The factorial of {number} is: {factorial}");
        }

        public static long CalculateFactorial(int number)
        {
            long result = number;
            int count = 1;

            while (count < number)
            {
                result = result * count;
                count++;

            }

            Console.WriteLine("facorial is " + result);
            return result;
            throw new NotImplementedException();
        }
    }
}
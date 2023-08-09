using System.Numerics;
using System.Xml.Schema;

namespace Day3_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please write a number : ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (number < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please write postive numberfor factorial");
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Factorial of number " + number + " is : " + factorial(number));
                    Console.ReadKey();
                    break;
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please write integer number for factorial");
                }
            }
        }

        static BigInteger factorial(int n)
        {

            BigInteger total = 1;
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                while (n > 0)
                {
                    total *= n;
                    n--;
                }
            }
            return total;
        }


    }


}
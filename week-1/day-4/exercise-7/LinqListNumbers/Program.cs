using System;
using System.Linq;

namespace Day4_Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 20, 14, 45, 84, 65, 10, 3, 0, 5, 78, 12, 14, 6, 52, 54, 56 };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Even numbers : ");
            var evenNum = array.Where(n => n % 2 == 0);

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (int i in evenNum)
            {
                Console.WriteLine(i);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Write number : ");
            int num = Convert.ToInt32(Console.ReadLine());

            // Using LINQ to filter numbers greater than the entered number
            var greaterNum = array.Where(n => n > num);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Numbers greater than " + num + ":");
            foreach (int i in greaterNum)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Sum of numbers : " + array.Sum());

            // Calculate the average of all numbers
            double average = array.Average();
            Console.WriteLine($"Average of all numbers: {average}");

            // Find the minimum value in the list
            int min = array.Min();
            Console.WriteLine($"Minimum value: {min}");

            // Find the maximum value in the list
            int max = array.Max();
            Console.WriteLine($"Maximum value: {max}");

        }
    }
}

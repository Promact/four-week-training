﻿using System.Diagnostics;

namespace QueryOptimizationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> data = GenerateRandomNumbers(10000000);
            Stopwatch sw = Stopwatch.StartNew();
            // Current implementation
           
            sw.Start();
            var originalQuery = data.Where(x => x > 100).OrderByDescending(x => x).Take(10).ToList();
            sw.Stop();
            Console.WriteLine("Original Query: {0} ms", sw.ElapsedMilliseconds);

            // Optimized implementation
            sw.Restart();
            var optimizedQuery = data.Where(x => x > 100).Take(10).OrderBy(x => -x).ToList();
            sw.Stop();
            Console.WriteLine("Optimized Query: {0} ms", sw.ElapsedMilliseconds);
        }

        static List<int> GenerateRandomNumbers(int count)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next();
                numbers.Add(randomNumber);
            }

            return numbers;
        }
    }
}

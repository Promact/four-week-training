using System;
using System.Diagnostics;
using System.Linq;

namespace Day3_Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int collectionSize = 1000000;
            int[] array = Enumerable.Range(0, collectionSize).ToArray();

            Stopwatch stopwatch = new Stopwatch();

            // Original LINQ query
            stopwatch.Start();
            var evenOriginal = array.Where(n => n % 2 == 0).ToList();
            stopwatch.Stop();
            Console.WriteLine("Original solution: " + stopwatch.Elapsed);

            // Optimized LINQ
        }
        }
        }
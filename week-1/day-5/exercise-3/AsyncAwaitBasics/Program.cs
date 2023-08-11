using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            int numberOfTasks = 5; // You can change this value as needed

            Stopwatch stopwatch = Stopwatch.StartNew();

            await PerformCalculations(numberOfTasks);

            stopwatch.Stop();

            Console.WriteLine($"All tasks completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
        }

        private static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete
            var tasks = new Task[numberOfTasks];

            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1); // Pass i + 1 as the delayInSeconds
            }

            await Task.WhenAll(tasks);
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            Console.WriteLine($"Task with {delayInSeconds} second delay started.");
            await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
            Console.WriteLine($"Task with {delayInSeconds} second delay completed.");
        }
    }
}


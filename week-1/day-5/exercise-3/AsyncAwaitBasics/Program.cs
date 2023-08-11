using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int numberOfTasks = 5; // You can change the number of tasks as needed

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await PerformCalculations(numberOfTasks);

            stopwatch.Stop();

            Console.WriteLine($"All tasks completed in {stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            Console.WriteLine($"Task with {delayInSeconds} seconds delay started.");
            await Task.Delay(delayInSeconds * 1000);
            Console.WriteLine($"Task with {delayInSeconds} seconds delay completed.");
        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            Task[] tasks = new Task[numberOfTasks];

            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1); // Simulate longer delay for each task
            }

            await Task.WhenAll(tasks);
        }
    }
}

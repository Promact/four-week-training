using System.Diagnostics;

namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            int numOfTasks = 10;
            var sw = new Stopwatch();
            sw.Start();

            await PerformCalculations(numOfTasks);

            sw.Stop();
            Console.WriteLine($"Total Time taken to complete all tasks: {sw.Elapsed}");
        }

        static async Task SimulateLongRunningTask(int delayInSec)
        {
            // Implement long-running task simulation
            Console.WriteLine($"Starting long-running task with delay of {delayInSec} seconds.");
            await Task.Delay(TimeSpan.FromSeconds(delayInSec));
            Console.WriteLine($"Long-running task with delay of {delayInSec} seconds completed.");
        }

        static async Task PerformCalculations(int numOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete
            var tasks = new Task[numOfTasks];

            for (int i = 0; i < numOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1);
            }

            await Task.WhenAll(tasks);
        }
    }
}
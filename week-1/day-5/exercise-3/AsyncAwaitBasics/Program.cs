using System.Diagnostics;

namespace AsyncAwaitBasics
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            int numberOfTasks = 5;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            await PerformCalculations(numberOfTasks);
            stopwatch.Stop();

            Console.WriteLine($"All tasks completed in {stopwatch.ElapsedMilliseconds} ms.");
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            await Task.Delay(delayInSeconds * 1000);
        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete
            Task[] tasks = new Task[numberOfTasks];

            for (int i = 0; i < numberOfTasks; i++)
            {
                // Simulate a task that runs for i+1 seconds
                tasks[i] = SimulateLongRunningTask(i + 1);
            }

            await Task.WhenAll(tasks);
        }
    }
}
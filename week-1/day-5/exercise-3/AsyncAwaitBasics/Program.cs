using System.Diagnostics;

namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            Stopwatch sw = Stopwatch.StartNew();

            await PerformCalculations(3);

            sw.Stop();
            Console.WriteLine("Total Time taken: {0} ms", sw.ElapsedMilliseconds);
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete
            Task[] task = new Task[numberOfTasks];

            for (int i = 0; i < numberOfTasks; i++)
            {
                task[i] = SimulateLongRunningTask(i + 1);
            }
            await Task.WhenAll(task);

            Console.WriteLine("Task Completed.");
        }
    }
}
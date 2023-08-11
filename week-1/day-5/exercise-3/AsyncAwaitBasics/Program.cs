using System.Diagnostics;

namespace Day5_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTasks = 5;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            PerFormCalculations(numberOfTasks);

            stopwatch.Stop();

            Console.WriteLine($"All tasks completed in {stopwatch.Elapsed.TotalSeconds} seconds.");


        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
           await Task.Delay(delayInSeconds);
        }

       static async Task PerFormCalculations(int numberOfTasks)
        {
            var tasks = new Task[numberOfTasks];

            for(int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1);
            }

            await Task.WhenAll(tasks);
        }

    }
}
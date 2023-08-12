using System;

namespace CovariantAndContravariantGenerics
{
    interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

    class StringToIntProcessor : IProcessor<string, int>
    {
        public int Process(string input)
        {
            // Implement conversion from string to int
            return int.Parse(input);
        }
    }

    class DoubleToStringProcessor : IProcessor<double, string>
    {
        public string Process(double input)
        {
            // Implement conversion from double to string
            return input.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstrate covariance and contravariance with IProcessor interface

            IProcessor<string, int> stringToIntProcessor = new StringToIntProcessor();
            int result1 = stringToIntProcessor.Process("42");
            Console.WriteLine(result1); // Output: 42

            IProcessor<double, string> doubleToStringProcessor = new DoubleToStringProcessor();
            string result2 = doubleToStringProcessor.Process(3.14);
            Console.WriteLine(result2); // Output: "3.14"
        }
    }
}


namespace CovariantAndContravariantGenerics
{
    public interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

    public class StringToIntProcessor : IProcessor<string, int>
    {
        // Implement Process method
        public int Process(string input)
        {
            return input.Length;
        }
    }

    public class DoubleToStringProcessor : IProcessor<double, string>
    {
        // Implement Process method
        public string Process(double input)
        {
            return input.ToString();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // Demonstrate covariance and contravariance with IProcessor interface
            IProcessor<string, int> stringProcessor = new StringToIntProcessor();
            int result1 = stringProcessor.Process("Hello");
            Console.WriteLine($"String length: {result1}");

            IProcessor<double, string> doubleProcessor = new DoubleToStringProcessor();
            string result2 = doubleProcessor.Process(3.14);
            Console.WriteLine($"Double as string: {result2}");
        }
    }
} 
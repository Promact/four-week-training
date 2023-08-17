
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
            return input.Length;
        }
    }

     class DoubleToStringProcessor : IProcessor<double, string>
    {
        public string Process(double input)
        {
            return input.ToString();
        }
    }

     internal class Program
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

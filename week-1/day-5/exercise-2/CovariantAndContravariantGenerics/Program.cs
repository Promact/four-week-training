namespace CovariantAndContravariantGenerics
{
    interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

    class StringToIntProcessor : IProcessor<string, int>
    {
        // Implement Process method
        public int Process(string input)
        {
            //throw new NotImplementedException();
            return input.Length;
        }
    }

    class DoubleToStringProcessor : IProcessor<double, string>
    {
        // Implement Process method
        public string Process(double input)
        {
            //throw new NotImplementedException();
            return input.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstrate covariance and contravariance with IProcessor interface
            IProcessor<string, int> stringToObjectProcessor = new StringToIntProcessor();
            Console.WriteLine($"Length of Janvi Thakkar: {stringToObjectProcessor.Process("Janvi Thakkar")}");

            IProcessor<double, string> doubleToStringProcessor = new DoubleToStringProcessor();
            Console.WriteLine($"String representation of 18.12: {doubleToStringProcessor.Process(18.12)}");
        }
    }
}
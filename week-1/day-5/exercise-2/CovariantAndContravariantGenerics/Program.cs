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
            bool output = int.TryParse(input, out int result);
            if (output)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Not a valid input integer.");
            }
        }
    }

    class DoubleToStringProcessor : IProcessor<double, string>
    {
        // Implement Process method
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
            IProcessor<string, int> stringToInt = new StringToIntProcessor();

            IProcessor<double, string> doubleToStrng = new DoubleToStringProcessor();

            //Process String to Integer
            int intResult1 = stringToInt.Process("42");
            Console.WriteLine($"Result for String to Int process: {intResult1} and (Type: {intResult1.GetType()})");

            //Process Double to String
            string stringResult1 = doubleToStrng.Process(34.22);
            Console.WriteLine($"Result for String to Int process: {stringResult1} and (Type: {stringResult1.GetType()})");
        }
    }
}
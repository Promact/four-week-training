namespace Day5_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Covariance Example : ");
            StringToIntProcessor covarianceProcessor = new StringToIntProcessor();
            int result = covarianceProcessor.TResultProcess("Hello world");
            Console.WriteLine($"Covariant Result: {result}");

            Console.WriteLine("contraVariance Example : ");
            DoubleToStringProcessor contraVarianceProcessor = new DoubleToStringProcessor();
            String result2 = contraVarianceProcessor.TResultProcess(1.23);
            Console.WriteLine($"Covariant Result: {result2}");

        }
    }

    interface IProcessor<Tinput, out Toutput>
    {
        Toutput TResultProcess(Tinput input);
    }

    public class StringToIntProcessor : IProcessor<String, int>
    {
        public int TResultProcess(string input)
        {
            return input.Length;

        }
    }

    public class DoubleToStringProcessor : IProcessor<double, string>
    {
        public String TResultProcess(double input)
        {
            return Convert.ToString(input);
        }
    }

}

namespace CovariantAndContravariantGenerics
{
    interface IProcessor<in TInput, out TResult>
    {
        TResult Process(TInput input);
    }

    internal class ObjectToIntProcessor : IProcessor<Program, int>
    {
        public int Process(Program input)
        {
             return Convert.ToInt32(input._input);
        }
    }

  public  class MyClass
    {
       public double inputdouble { get; set; }
      public  MyClass(double inputDouble)
        {
            this.inputdouble = inputDouble;
        }

    }

    class DoubleToObjectProcessor : IProcessor<double, MyClass>
    {
        public MyClass Process(double input)
        {
            
            return new MyClass(input); 
        }
    }

    internal class Program 
    {
        public  string _input { get; set; }
        
        static void Main(string[] args)
        {

            Program program = new Program()
            {
                _input = "42"
            };
            IProcessor<Program, int> objectToIntCovariantProcessor = new ObjectToIntProcessor();
            int intValue = objectToIntCovariantProcessor.Process(program);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Covariant Processor Output (object to int): " + intValue);

            IProcessor<double, MyClass> doubleToObjectContravariantProcessor = new DoubleToObjectProcessor();

           MyClass myobj = doubleToObjectContravariantProcessor.Process(3.14159);
           
            Console.WriteLine("Contravariant Processor Output (double to Object): " + myobj.inputdouble);
            Console.ResetColor();
        }
    }
}

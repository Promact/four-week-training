namespace program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Factorial");
            Console.WriteLine(" Enter a number here");
            Int32 num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number is " + num);

            Int32 result = num;
            Int32 count = 1;

            while (count < num)
            {
                result = result * count;
                Console.WriteLine(result);
                count++;
            }
            Console.WriteLine("Factorial is " + result);

        }
    }
}
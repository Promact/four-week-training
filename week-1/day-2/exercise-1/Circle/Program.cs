namespace Day2_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please write raduis of circle : ");
            double radius = double.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Area of circle is : " + circle.getArea(radius));
            Console.WriteLine("Circumference of circle is : " + circle.getCircumference(radius));
            Console.ReadKey();
        }
    }
}
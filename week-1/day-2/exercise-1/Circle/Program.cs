namespace DAY2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = 10;
            Circle circle = new Circle(radius);
            double area = circle.GetArea();
            double circumference = circle.GetCircumference();
            Console.WriteLine($"Area:{area}");
            Console.WriteLine($"circumference:{circumference}");
            Console.WriteLine("Hello, World!");
        }
    }
}

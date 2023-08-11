namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Circle object and display its area and circumference
            Circle c = new Circle(3);
            Console.WriteLine("area of circle is " + c.getArea());
            Console.WriteLine("Circumference  of circle is " + c.GetCircumference());
        }
    }
}
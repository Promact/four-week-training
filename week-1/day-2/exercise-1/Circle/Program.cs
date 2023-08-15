namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Circle object and display its area and circumference
            Console.Write("Enter the radius of the circle: ");
            double radius = Convert.ToDouble(Console.ReadLine());

            Circle circle = new Circle(radius);

            double area = circle.CalculateArea();
            double circumference = circle.CalculateCircumference();

            Console.WriteLine($"Circle Area: {area}");
            Console.WriteLine($"Circle Circumference: {circumference}");

        }
    }
}
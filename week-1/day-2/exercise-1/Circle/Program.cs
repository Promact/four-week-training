namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Circle object with a given radius
            double radius = 5.0;
            Circle circle = new Circle(radius);

            // Calculate and display the area
            double area = circle.GetArea();
            Console.WriteLine($"Area of the circle with radius {radius}: {area}");

            // Calculate and display the circumference
            double circumference = circle.GetCircumference();
            Console.WriteLine($"Circumference of the circle with radius {radius}: {circumference}");
        }
    }
}
namespace Circle
{
    public class Program
    {
        // Entry point of the program
        static void Main(string[] args)
        {
            double radius = 5.5; // Define the radius of the circle

            Circle areaObj = new Circle(radius); // Create a Circle object with the given radius

            // Print the calculated area and circumference of the circle
            Console.WriteLine("The Area of Circle is " + areaObj.GetArea());
            Console.WriteLine("The Circumference of Circle is " + areaObj.GetCircumference());
        }
    }
}
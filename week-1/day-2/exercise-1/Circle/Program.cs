namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Circle object and display its area and circumference
            Console.WriteLine("Enter the radius of the circle: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Circle myCircle = new Circle(radius);

            Console.WriteLine($"Area: {myCircle.GetArea()}");

            Console.WriteLine($"Circumference: {myCircle.GetCircumference()}");
        }
    }
}
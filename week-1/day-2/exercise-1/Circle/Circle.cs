using System;

class Circle
{
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double GetCircumference()
    {
        return 2 * Math.PI * Radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a Circle object with a given radius
        double radius = 5.0;
        Circle circle = new Circle(radius);

        // Display area and circumference
        Console.WriteLine($"Circle with radius {radius}");
        Console.WriteLine($"Area: {circle.GetArea()}");
        Console.WriteLine($"Circumference: {circle.GetCircumference()}");
        Console.ReadLine();

    }
}

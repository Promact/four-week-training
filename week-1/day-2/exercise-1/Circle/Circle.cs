

public class Circle
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
    public double GetCircumference()
    {
        return 2 * Math.PI * Radius;
    }

}

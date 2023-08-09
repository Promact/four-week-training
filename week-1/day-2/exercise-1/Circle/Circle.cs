using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    public class Circle
    {
        private double Radius;
        // Constructor for the Circle class, initializes the radius
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Method to calculate and return the area of the circle
        public double GetArea()
        {
            return Math.Round(Math.PI * Radius * Radius); // Calculate and round the area
            // Alternative: return Math.PI * Math.Pow(Radius, 2);
        }

        // Method to calculate and return the circumference of the circle
        public double GetCircumference()
        {
            return Math.Round(2 * Math.PI * Radius); // Calculate and round the circumference
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    internal class Circle
    {
        // Implement the Circle class here
        public double Radius { get; private set; }

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
}

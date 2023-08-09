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

        int radius;
        public Circle(int Radius)
        {
            radius = Radius;
        }
        public double getArea()
        {

            return Math.PI * Math.Pow(radius, 2);
        }
        public double GetCircumference()
        {
            return 2 * Math.PI * radius;
        }
    }
}

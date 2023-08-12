using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Task1
{
    public class Circle
    {

        public double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double getArea(double raduis)
        {
            double area = 3.14 * radius * radius;
            return area;
        }

        public double getCircumference(double raduis)
        {
            double perimeter = 3.14 * 2 * raduis;
            return perimeter;
        }

    }
}

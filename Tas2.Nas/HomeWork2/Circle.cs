using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Circle
    {
        public Point Center { get; private set; }
        public double Radius { get; private set; }

        public virtual double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public virtual double Length
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        public Circle(double x, double y, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Center = new Point(x, y);
                Radius = radius;
            }
        }
    }
}

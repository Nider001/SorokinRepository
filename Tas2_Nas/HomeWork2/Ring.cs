using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    public class Ring
    {
        private Circle innerCircle;
        private Circle outerCircle;

        public Ring(Circle innerCircle, Circle outerCircle)
        {
            if (innerCircle.Center.X != outerCircle.Center.X || innerCircle.Center.Y != outerCircle.Center.Y)
            {
                throw new ArgumentException();
            }

            this.innerCircle = innerCircle;
            this.outerCircle = outerCircle;
        }

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            if (innerRadius >= outerRadius)
            {
                throw new ArgumentException();
            }

            innerCircle = new Circle(x, y, innerRadius);
            outerCircle = new Circle(x, y, outerRadius);
        }

        public Point Center
        {
            get
            {
                return new Point(innerCircle.Center.X, innerCircle.Center.Y);
            }
        }

        public double InnerRadius
        {
            get
            {
                return innerCircle.Radius;
            }
        }

        public double OuterRadius
        {
            get
            {
                return outerCircle.Radius;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * (outerCircle.Radius * outerCircle.Radius - innerCircle.Radius * innerCircle.Radius);
            }
        }

        public double Length
        {
            get
            {
                return 2 * Math.PI * (outerCircle.Radius + innerCircle.Radius);
            }
        }
    }
}

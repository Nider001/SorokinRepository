using System;
using System.Linq;

namespace HomeWork2
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point(double value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
        }

        public static double FindPathLength(Point P1, Point P2)
        {
            return Math.Sqrt((P2.X - P1.X) * (P2.X - P1.X) + (P2.Y - P1.Y) * (P2.Y - P1.Y) + (P2.Z - P1.Z) * (P2.Z - P1.Z));
        }
    }

    public class Pyramid
    {
        private Point[] vertices;

        public int Size
        {
            get
            {
                if (vertices != null)
                {
                    return vertices.Length;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public Point Top
        {
            get
            {
                if (vertices != null && vertices.Length > 0)
                {
                    return vertices.First();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            set
            {
                this[0] = value;
            }
        }

        public Pyramid(params Point[] vertices)
        {
            if (CheckIncData(vertices))
            {
                this.vertices = new Point[vertices.Length];
                vertices.CopyTo(this.vertices, 0);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Point this[int vertexIndex]
        {
            get
            {
                if (vertexIndex < vertices.Length && vertexIndex >= 0)
                {
                    return vertices[vertexIndex];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (vertexIndex < vertices.Length)
                {
                    var temp = vertices.ToArray();
                    temp[vertexIndex] = value;

                    if (CheckIncData(temp))
                    {
                        vertices[vertexIndex] = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        private static double FindDeterminant3x3(double a11, double a12, double a13, double a21, double a22, double a23, double a31, double a32, double a33)
        {
            return a11 * a22 * a33 - a11 * a23 * a32 - a12 * a21 * a33 + a12 * a23 * a31 + a13 * a21 * a32 - a13 * a22 * a31;
        }

        public static bool CheckIncData(Point[] vertices)
        {
            //https://otvet.mail.ru/question/73938326

            if (vertices.Length < 4 || vertices.Length > 5)
            {
                return false;
            }

            double a11 = vertices[0].X - vertices[1].X;
            double a12 = vertices[0].Y - vertices[1].Y;
            double a13 = vertices[0].Z - vertices[1].Z;

            double a21 = vertices[2].X - vertices[1].X;
            double a22 = vertices[2].Y - vertices[1].Y;
            double a23 = vertices[2].Z - vertices[1].Z;

            double a31 = vertices[3].X - vertices[1].X;
            double a32 = vertices[3].Y - vertices[1].Y;
            double a33 = vertices[3].Z - vertices[1].Z;

            if (FindDeterminant3x3(a11, a12, a13, a21, a22, a23, a31, a32, a33) == 0)
            {
                return false;
            }

            if (vertices.Length > 4)
            {
                for (int i = 4; i < vertices.Length; i++)
                {
                    a11 = vertices[i].X - vertices[1].X;
                    a12 = vertices[i].Y - vertices[1].Y;
                    a13 = vertices[i].Z - vertices[1].Z;

                    if (FindDeterminant3x3(a11, a12, a13, a21, a22, a23, a31, a32, a33) != 0)
                    {
                        return false;
                    }
                }
            }

            for (int i = 1; i < vertices.Length - 2; i++)
                for (int j = i + 1; j < vertices.Length - 1; j++)
                    for (int k = j + 1; k < vertices.Length; k++)
                    {
                        double temp = FindDeterminant3x3(vertices[i].X, vertices[i].Y, vertices[i].Z,
                                                            vertices[j].X, vertices[j].Y, vertices[j].Z,
                                                            vertices[k].X, vertices[k].Y, vertices[k].Z);

                        if (temp != 0)
                        {
                            if (CheckTriangles(vertices))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (i == vertices.Length - 2 && j == vertices.Length - 1 && k == vertices.Length)
                        {
                            #warning The volume will not be calculated correctly due to specific input
                        }
                    }

            if (CheckTriangles(vertices))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckTriangles(Point[] vertices)
        {
            for (int i = 0; i < vertices.Length - 2; i++)
                for (int j = i + 1; j < vertices.Length - 1; j++)
                    for (int k = j + 1; k < vertices.Length; k++)
                    {
                        double a = Point.FindPathLength(vertices[i], vertices[j]);
                        double b = Point.FindPathLength(vertices[i], vertices[k]);
                        double c = Point.FindPathLength(vertices[j], vertices[k]);

                        if ((a + b <= c) || (a + c <= b) || (b + c <= a))
                        {
                            return false;
                        }
                    }

            return true;
        }

        public static bool CheckPointVsPlane(Point pointToCheck, Point p1, Point p2, Point p3)
        {
            double a11 = pointToCheck.X - p1.X;
            double a12 = pointToCheck.Y - p1.Y;
            double a13 = pointToCheck.Z - p1.Z;

            double a21 = p2.X - p1.X;
            double a22 = p2.Y - p1.Y;
            double a23 = p2.Z - p1.Z;

            double a31 = p3.X - p1.X;
            double a32 = p3.Y - p1.Y;
            double a33 = p3.Z - p1.Z;

            if (FindDeterminant3x3(a11, a12, a13, a21, a22, a23, a31, a32, a33) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetBaseArea() //Площадь основания
        {
            if (vertices.Length == 4)
            {
                double a1 = Point.FindPathLength(vertices[1], vertices[2]);
                double a2 = Point.FindPathLength(vertices[1], vertices[3]);
                double a3 = Point.FindPathLength(vertices[2], vertices[3]);

                double p = (a1 + a2 + a3) / 2.0;

                return Math.Sqrt(p * (p - a1) * (p - a2) * (p - a3));
            }
            else //5
            {
                double a1 = Point.FindPathLength(vertices[1], vertices[2]);
                double a2 = Point.FindPathLength(vertices[2], vertices[3]);
                double a3 = Point.FindPathLength(vertices[3], vertices[4]);
                double a4 = Point.FindPathLength(vertices[1], vertices[4]);

                double p = (a1 + a2 + a3 + a4) / 2.0;

                return Math.Sqrt(p * (p - a1) * (p - a2) * (p - a3) * (p - a4));
            }
        }

        public double GetVolume() //Объем
        {
            //https://ege-ok.ru/2012/03/18/uravnenie-ploskosti
            //https://reader.lecta.rosuchebnik.ru/demo/7999/data/chapter27.xhtml

            double D = CheckPointVsPlane(new Point(0), vertices[1], vertices[2], vertices[3]) ? 0 : 1;

            double A = 0, B = 0, C = 0;

            for (int i = 1; i < vertices.Length - 2; i++)
                for (int j = i + 1; j < vertices.Length - 1; j++)
                    for (int k = j + 1; k < vertices.Length; k++)
                    {
                        if (i == j || i == k || j == k)
                        {
                            continue;
                        }

                        double temp = FindDeterminant3x3(vertices[i].X, vertices[i].Y, vertices[i].Z,
                                                  vertices[j].X, vertices[j].Y, vertices[j].Z,
                                                  vertices[k].X, vertices[k].Y, vertices[k].Z);

                        if (temp == 0 && i != vertices.Length - 2 && j != vertices.Length - 1 && k != vertices.Length)
                        {
                            continue;
                        }
                        else if (temp == 0)
                        {
                            throw new DivideByZeroException("Volume cannot be calculated due to specific input");
                        }

                        A = FindDeterminant3x3(-D, vertices[i].Y, vertices[i].Z,
                                               -D, vertices[j].Y, vertices[j].Z,
                                               -D, vertices[k].Y, vertices[k].Z) / temp;

                        B = FindDeterminant3x3(vertices[i].X, -D, vertices[i].Z,
                                               vertices[j].X, -D, vertices[j].Z,
                                               vertices[k].X, -D, vertices[k].Z) / temp;

                        C = FindDeterminant3x3(vertices[i].X, vertices[i].Y, -D,
                                               vertices[j].X, vertices[j].Y, -D,
                                               vertices[k].X, vertices[k].Y, -D) / temp;

                        break;
                    }

            double t = (-A * vertices[0].X + B * vertices[0].Y + C * vertices[0].Z + D) / (A * A + B * B + C * C);

            Point PointOnPlane = new Point(vertices[0].X + A * t, vertices[0].Y + B * t, vertices[0].Z + C * t);

            //finally
            return Point.FindPathLength(vertices[0], PointOnPlane) * GetBaseArea() / 3.0;
        }
    }
}

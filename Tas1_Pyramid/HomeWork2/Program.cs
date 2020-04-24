using System;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Pyramid pyramid = new Pyramid(new Point(4, 4, 4),
                new Point(1, 1, 1), new Point(1, 2, 2), new Point(1, 1, 3), new Point(1, 2, 3));*/

            PyramidHandler ph = new PyramidHandler();

            Pyramid pyramid = ph.GetPyramid("input.txt");

            Console.WriteLine(pyramid.GetBaseArea());
            Console.WriteLine(pyramid.GetVolume());

            //pyramid[0] = new Point(99, 99, 99);
            //pyramid.Top = new Point(99, 99, 99);
            pyramid[3] = new Point(1, 1, 3);

            Console.WriteLine("\n" + pyramid.GetBaseArea());
            Console.WriteLine(pyramid.GetVolume());

            Console.ReadKey();
        }
    }
}

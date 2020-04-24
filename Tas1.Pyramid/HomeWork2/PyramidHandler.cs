using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork2
{
    public class PyramidHandler
    {
        public Pyramid GetPyramid(string input)
        {
            try
            {
                using (StreamReader inputfile = new StreamReader(input))
                {
                    List<Point> points = new List<Point>();
                    var tarr = new double[3];
                    while (!inputfile.EndOfStream)
                    {
                        var inp = inputfile.ReadLine().Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (double.TryParse(inp[0], out tarr[0]) && double.TryParse(inp[1], out tarr[1]) && double.TryParse(inp[2], out tarr[2]))
                        {
                            points.Add(new Point(tarr[0], tarr[1], tarr[2]));
                        }
                        else
                        {
                            throw new FormatException("Error while trying to parse a number");
                        }
                    }

                    var temp = points.ToArray();

                    if (Pyramid.CheckIncData(temp))
                    {
                        Pyramid res = new Pyramid(temp);
                        return res;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException("Error while reading the input file", ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Input file is not correct", ex);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Error while trying to parse a number", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inputting the data", ex);
            }
        }

        public void WriteToFile(Pyramid obj, string output)
        {
            try
            {
                using (StreamWriter outputfile = new StreamWriter(output))
                {
                    int k = obj.Size - 1;

                    for (int i = 0; i < k; i++)
                    {
                        outputfile.WriteLine(obj[i].X + " " + obj[i].Y + " " + obj[i].Z);
                    }

                    outputfile.WriteLine(obj[k].X + " " + obj[k].Y + " " + obj[k].Z);
                }
            }
            catch (IOException ex)
            {
                throw new IOException("Error while accessing the output file", ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Input file is not correct", ex);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Error while trying to parse a number", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inputting the data", ex);
            }
        }
    }
}

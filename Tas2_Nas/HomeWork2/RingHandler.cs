using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork2
{
    public class RingHandler
    {
        public Ring GetRing(string input)
        {
            try
            {
                using (StreamReader inputfile = new StreamReader(input))
                {
                    return new Ring(double.Parse(inputfile.ReadLine()), double.Parse(inputfile.ReadLine()), double.Parse(inputfile.ReadLine()), double.Parse(inputfile.ReadLine()));
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
                throw new FormatException("Error while trying to parse the data", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inputting the data", ex);
            }
        }

        public void WriteToFile(Ring obj, string output)
        {
            try
            {
                using (StreamWriter outputfile = new StreamWriter(output))
                {
                    outputfile.WriteLine(obj.Center.X);
                    outputfile.WriteLine(obj.Center.Y);
                    outputfile.WriteLine(obj.InnerRadius);
                    outputfile.WriteLine(obj.OuterRadius);
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

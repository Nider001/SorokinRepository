using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork2
{
    public class EmployeeHandler
    {
        public Employee GetEmployee(string input)
        {
            try
            {
                using (StreamReader inputfile = new StreamReader(input))
                {
                    return new Employee(inputfile.ReadLine(), inputfile.ReadLine(), inputfile.ReadLine(), Convert.ToDateTime(inputfile.ReadLine()), Convert.ToDateTime(inputfile.ReadLine()), inputfile.ReadLine());
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

        public void WriteToFile(Employee obj, string output)
        {
            try
            {
                using (StreamWriter outputfile = new StreamWriter(output))
                {
                    outputfile.WriteLine(obj.FirstName);
                    outputfile.WriteLine(obj.MiddleName);
                    outputfile.WriteLine(obj.LastName);
                    outputfile.WriteLine(Convert.ToString(obj.DateOfBirth));
                    outputfile.WriteLine(Convert.ToString(obj.WorkStarted));
                    outputfile.WriteLine(obj.Occupation);
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

using System;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine((DateTime.Now.Year - DateTime.Now.AddDays(-363).Year));

            UserHandler uh = new UserHandler();
            EmployeeHandler eh = new EmployeeHandler();
            RingHandler rh = new RingHandler();

            User user = uh.GetUser("input.txt");
            Employee employee = eh.GetEmployee("input.txt");

            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.MiddleName);
            Console.WriteLine(user.Age);
            Console.WriteLine(employee.Occupation);

            Ring ring = rh.GetRing("input2.txt");
            Console.WriteLine(Environment.NewLine + ring.Area);
            Console.WriteLine(ring.Length);

            Console.ReadKey();
        }
    }
}

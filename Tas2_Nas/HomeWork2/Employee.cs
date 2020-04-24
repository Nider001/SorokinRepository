using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Employee: User
    {
        public Employee(string firstName, string lastName, string middleName, DateTime dateOfBirth, DateTime WorkStarted, string Occupation)
            : base(firstName, lastName, middleName, dateOfBirth)
        {
            this.WorkStarted = WorkStarted;
            this.Occupation = Occupation;
        }

        public DateTime WorkStarted { get; set; }

        public int LengthOfService
        {
            get
            {
                if (WorkStarted < DateOfBirth)
                {
                    return 0;
                }
                else
                {
                    return (int)(DateTime.Now - WorkStarted).TotalDays;
                }
            }
            set
            {
                LengthOfService = value;
            }
        }
        public string Occupation { get; set; }
    }
}

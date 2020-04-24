using System;
using System.Linq;

namespace HomeWork2
{
    public class User
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;

                return age;
            }
        }

        public User(string firstName, string lastName, string middleName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }
    }
}

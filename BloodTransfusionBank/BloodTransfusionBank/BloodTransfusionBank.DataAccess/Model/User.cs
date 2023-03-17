using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodTransfusionBank.DataAccess.Model
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Occupation
    {
        Student,
        Employee,
        Unemployed
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public Occupation Occupation { get; set; }
    }
}

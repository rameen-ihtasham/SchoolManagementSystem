using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class Person
    {
        public int Id { get; set; }
        public int CNIC { get; set; }
        public string RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address{ get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string status { get; set; }
        public int age { get; set; }
        public int UserId { get; set; }


        public Person(int id, string registrationNumber, string firstName, string lastName, string contact, string email, string gender, string dOB, int cNIC, string address, string status, int age, int userId)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Contact = contact;
            Email = email;
            Gender = gender;
            DOB = dOB;
            CNIC = cNIC;
            Address = address;
            this.status = status;
            this.age = age;
            UserId = userId;
        }
    }
}

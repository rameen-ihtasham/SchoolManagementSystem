using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
public Person(int id, string firstName, string lastName, string contact, string dOB, string email,string address, string CNIC,int gender,int Status,int Age,int UserId)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Contact = contact;
            DOB = dOB;
            Email = email;
            Address = address;
            this.CNIC = CNIC;
            Gender = gender;
           this. Status = Status;
            this.Age = Age;
           this.UserId = UserId;


   
        }
    }
}

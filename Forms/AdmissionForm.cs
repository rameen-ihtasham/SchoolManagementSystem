using DBFinalProject.BL;
using DBFinalProject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject.Forms
{
    public partial class AdmissionForm : Form
    {
        public string RClass;
        public Person student;
        public User user;
        public ClassStudent studentClass;
        public Class clas;
        public AdmissionForm()
        {

            InitializeComponent();
            RClass = RclassCB.Text.Trim();
            cn();
           
           
        }

        public void GetStudent()
        {

            DateTime dob = DateTime.Parse(DOB.Text);
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.Month < dob.Month || (DateTime.Now.Month == dob.Month && DateTime.Now.Day < dob.Day))
            {
                age--;
            }
            string firstName = FirstNameTB.Text;
            string lastName = LastNameTB.Text;
            string registrationNumber = RegistrationNoTB.Text;
            string contact = ContactTB.Text;
            string email = EmailTB.Text;
            string gender = GenderCB.Text;
            string dob1 = DOB.Text;
            string address = AdressTB.Text;
            string rclass = RclassCB.Text;
            string cnic = CNICTB.Text;

            
            this.student = new Person(firstName, lastName, contact, email, gender, dob1, cnic, address, "5", age, 2);

        }
        public void cn(Person student = null)
        {
            this.student=student;
            if (!(this.student is null))
            {
                FirstNameTB.Text = student.FirstName;
                LastNameTB.Text = student.LastName;
                RegistrationNoTB.Text = student.RegistrationNumber;
                ContactTB.Text = student.Contact;
                EmailTB.Text = student.Email;
                GenderCB.Text = student.Gender;
                DOB.Text = student.DOB;
                AdressTB.Text = student.Address;
                RclassCB.Text = clas.ClassGrade.ToString();
                CNICTB.Text = student.CNIC.ToString();



            }
        }
        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
             Form f = new StudentPassword();
             f.Show();
           /* try
            {
                this.GetStudent();
               
                
                    Queries.insertStudent(this.student);
                

                this.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log, display error message)
               MessageBox.Show("An error occurred: " + ex.Message);
                Console.WriteLine("An error occurred: " + ex.Message);
                string dateString = "2003-06-17";
                Console.WriteLine("Date string: " + dateString); // Output the date string for debugging
                DateTime dob = DateTime.Parse(dateString);

            }*/

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenderCB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

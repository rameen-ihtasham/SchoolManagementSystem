using DBFinalProject.BL;
using DBFinalProject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject.Forms
{
    public partial class StudentPassword : Form
    {
        public Person student;
        public User user;
        public ClassStudent studentClass;
        AdmissionForm admissionForm = new AdmissionForm();
        public StudentPassword(Person student = null,User user = null)
        {

            this.student = student;
            this.user = user;
            InitializeComponent();

            
            admissionForm.cn();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            admissionForm.GetStudent();
            if (this.student.Id == 0)
            {
                Queries.InsertStudent(this.student);
            }
           
          
            this.Close();
        }
    }
}

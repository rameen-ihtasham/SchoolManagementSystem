using CRUD_Operations;
using DBFinalProject.BL;
using DBFinalProject.Forms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject.DataAccess
{
    static public class Queries
    {

        public static SqlConnection con = Configuration.getInstance().getConnection();

        public static int LastInsertedUserId { get; private set; }

        static public void InsertUser(User user)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [User] ( UserName, Password, Role) OUTPUT Inserted.ID VALUES ( @Username, @Password, @role);", con);

            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            LastInsertedUserId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();

        }
        static public void insertStudent(Person student) {



            DateTime dob = DateTime.Parse(student.DOB);


            SqlCommand cmd = new SqlCommand("INSERT INTO Person (FirstName, LastName, Contact, Email, DOB, Gender, Address, CNIC, Status, Age, UserId)  VALUES (@first, @second, @contact, @email, @dob, @gender, @address, @cnic, @status, @age, @userId);", con);
            // SqlCommand cmd = new SqlCommand("insert into Person values ('@alishba','mazhar','03010966661','alishba74@gmail.com','2003-06-17','street 6 house 2','42301-4438447-0',4,5,'20',2)");
            cmd.Parameters.AddWithValue("@first", student.FirstName);
            cmd.Parameters.AddWithValue("@second", student.LastName);
            cmd.Parameters.AddWithValue("@contact", student.Contact);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@gender", student.Gender == "Male" ? 3 : 4);
            cmd.Parameters.AddWithValue("@address", student.Address);
            cmd.Parameters.AddWithValue("@cnic", student.CNIC);
            cmd.Parameters.AddWithValue("@status", student.status);
            cmd.Parameters.AddWithValue("@age", student.age);
            cmd.Parameters.AddWithValue("@userId", student.UserId);
            // LastInsertedUserId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();


        }
        static public void InsertStudent(Person student)
        {


            SqlCommand cmd = new SqlCommand("INSERT INTO Student (ID, RegNo) VALUES (@id, @regNo); SELECT SCOPE_IDENTITY();", con);
            cmd.Parameters.AddWithValue("@id", LastInsertedUserId);
            cmd.Parameters.AddWithValue("@regNo", student.RegistrationNumber);
            LastInsertedUserId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
        }

        static public  void insertclass()
        {

            AdmissionForm admissionForm = new AdmissionForm();
            string rClassValue = admissionForm.RClass;
            SqlCommand cmdFetchClassId = new SqlCommand("SELECT classID FROM Class WHERE ClassGrade = @ClassGrade;", con);
            cmdFetchClassId.Parameters.AddWithValue("@ClassGrade", rClassValue);
            object classIdObj = cmdFetchClassId.ExecuteScalar();
            if (classIdObj != null && classIdObj != DBNull.Value)
            {
                int classId = Convert.ToInt32(classIdObj);

               SqlCommand cmd = new SqlCommand("INSERT INTO ClassStudent (ClassId, StudentId) VALUES (@Classid, @stuId);", con);
                cmd.Parameters.AddWithValue("@Classid", classId);
                cmd.Parameters.AddWithValue("@stuId", LastInsertedUserId);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("class id is not found");
            }
        }

    }

}


   

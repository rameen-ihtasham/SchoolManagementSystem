using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using DBFinalProject.BBL;
using DBFinalProject.Forms;
using Guna.UI2.WinForms;
namespace DBFinalProject.DataAccess
{
    public class Queries
    {
        public static SqlConnection con = Configuration.getInstance().getConnection();

       
        

        static public void attendanceHandling(Attendancee e)
        {
            int classID = 0;
            int studentID = 0;
            int teacherrid = 0;
            SqlCommand cmd = new SqlCommand("SELECT c.classID as ClassID, cs.StudentID as StudentID, t.teachID AS InchargeTeacherID " +
                                          "FROM Teacher t " +
                                          "JOIN ClassTeacher ct ON t.teachID = ct.TteacherID " +
                                          "JOIN Class c ON ct.CllassID = c.classID " +
                                          "JOIN ClassStudent cs ON c.classID = cs.ClasID " +
                                          "WHERE t.teachID = 4 " +
                                          "AND t.Designation = (SELECT lookupID FROM Lookup WHERE Value = 'Incharge')", con);


         
            SqlDataReader reader = cmd.ExecuteReader();
            List<int> studentIDs = new List<int>();
            while (reader.Read())
            {
                classID = Convert.ToInt32(reader["ClassID"]);
                studentID = Convert.ToInt32(reader["StudentID"]);
                teacherrid = Convert.ToInt32(reader["InchargeTeacherID"]);
                studentIDs.Add(studentID);
            }
            reader.Close();
            Attendance attendanceForm = new Attendance();
             attendanceForm.ComboBoxValues();

            SqlCommand ccmd = new SqlCommand("Insert into Attendance(StudentID, Date, ClassID, TeacherID, IsPresent) values (@studentid, @date, @classid, @teacherid, @status);", con);
                ccmd.Parameters.AddWithValue("@studentid", e.StudentID);
            ccmd.Parameters.AddWithValue("@Date", e.date != null ? DateTime.Parse(e.date) :DateTime.Now.Date);

            ccmd.Parameters.AddWithValue("@classid", e.ClassID);
                ccmd.Parameters.AddWithValue("@teacherid", e.TeacherID);
                ccmd.Parameters.AddWithValue("@Status", e.IsPresent);
        }
    }
}



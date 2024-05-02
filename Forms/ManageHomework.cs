using DBFinalProject.BBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DBFinalProject.Forms
{
    public partial class ManageHomework : Form
    {
        public HomeworkAssign h;
        public Action loadGrid;
        public static SqlConnection con = Configuration.getInstance().getConnection();
        public ManageHomework(Action loadGrid)
        {

            this.loadGrid = loadGrid;
            InitializeComponent();
            fetching();



        }
   void fetching()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();


                ClassCB.Items.Clear();

                SqlCommand cmdFetchCLOIds = new SqlCommand("SELECT c.classID as Id FROM Class c", con);
                SqlDataReader reader = cmdFetchCLOIds.ExecuteReader();


                while (reader.Read())
                {
                    ClassCB.Items.Add(reader["Id"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching IDs: " + ex.Message);
            }

        }
        private void GetHomework()
        {
            var con = Configuration.getInstance().getConnection();
            string classid = ClassCB.Text;
            string descriptionHomework = richTextBox1.Text;
            string teacherId = "4";
            bool teacherTeachesClass = IsTeacherAssignedToClass(classid, teacherId,con);
            if (teacherTeachesClass)
            {

                Tuple<string, string> ids = GetSubjectIdsForClass(classid, teacherId, con);

                string teacherid = ids.Item1;
                string subjectId = ids.Item2;
                InsertHomework(teacherId, subjectId, descriptionHomework,con);
                MessageBox.Show("Homework added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("The selected teacher is not assigned to teach the chosen class. Please select a different class or teacher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertHomework(string teacherId, string subjectId, string descriptionHomework, SqlConnection connection)
        {
            
            string query = @"INSERT INTO Homework (TeacherID, subjectId, HomeWork,Date, UpdatedOn, UpdatedBy)
                     VALUES (@TeacherId, @SubjectId, @Description,DateTime.Now.Date, GETDATE(), @UpdatedBy)";

           
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.Parameters.AddWithValue("@SubjectId", subjectId);          
                command.Parameters.AddWithValue("@Description", descriptionHomework);
               
                command.Parameters.AddWithValue("@UpdatedBy", teacherId); 

                
                command.ExecuteNonQuery();
            }
        }

        bool IsTeacherAssignedToClass(string classId, string teacherId, SqlConnection connection)
        {
            string query = @"SELECT COUNT(*)
                     FROM ClassSubject
                     WHERE ClaassID = @ClassId 
                     AND TeacherrID = @TeacherId";

            using (SqlCommand command = new SqlCommand(query, connection)) // Pass the SqlConnection object
            {
                command.Parameters.AddWithValue("@ClassId", classId);
                command.Parameters.AddWithValue("@TeacherId", teacherId);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }



        private Tuple<string, string> GetSubjectIdsForClass(string classId, string teacherID, SqlConnection connection)
            {

                string query = @"SELECT subID
                     FROM ClassSubject
                     WHERE ClaassID = @ClassId 
                     AND TeacherrID = @TeacherId";


                using (SqlCommand command = new SqlCommand(query,connection))
                {

                    command.Parameters.AddWithValue("@ClassId", classId);
                    command.Parameters.AddWithValue("@TeacherId", teacherID);


                    string subjectId = command.ExecuteScalar()?.ToString();


                    return Tuple.Create(teacherID, subjectId);
                }
            }

            private void guna2Button3_Click(object sender, EventArgs e)
            {
              GetHomework();

            }
        }
    }



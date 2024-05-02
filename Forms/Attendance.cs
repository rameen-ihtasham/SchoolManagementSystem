using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DBFinalProject.DataAccess;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BBL;
using DBFinalProject.BL;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace DBFinalProject.Forms
{
    public partial class Attendance : Form
    {
        public static SqlConnection con = Configuration.getInstance().getConnection();
        User u1 = new User();
        public Attendance()
        {
            InitializeComponent();
            DataBind();
        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int role = u1.GetMyRole();
            if (role == 7) 
            {
                
            }
        }

        DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn();
        private void DataBind()
        {


          
            status.HeaderText = "Status";
            status.Items.Add("Present");
            status.Items.Add("Absent");
            

            guna2DataGridView1.Columns.Add(status);




        }


        public void ComboBoxValues()
        {
            SqlCommand studentCount = new SqlCommand(@"SELECT COUNT(*) AS ActiveStudentCount
                                                FROM Person p
                                                JOIN Student s ON p.ID = s.stdID
                                                JOIN ClassStudent cs ON p.ID = cs.StudentID
                                                JOIN Class c ON cs.ClasID = c.classID
                                                JOIN ClassTeacher ct ON c.classID = ct.CllassID
                                                JOIN Teacher t ON ct.TteacherID = t.teachID
                                                JOIN [Lookup] l ON p.Status = l.lookupID
                                                WHERE l.Value = 'Active' AND l.Description = 'STUDENT_STATUS'
                                                AND t.teachID = 4
                                                AND t.Designation = (SELECT lookupID FROM [Lookup] WHERE Value = 'Incharge')
                                                AND c.classID = 1;", con);
            int count = (int)studentCount.ExecuteScalar();

            for (int i = 0; i < count; i++)
            {
                if (i < guna2DataGridView1.Rows.Count)
                {
                    if (guna2DataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        string studentID = guna2DataGridView1.Rows[i].Cells[0].Value.ToString();

                        DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)guna2DataGridView1.Rows[i].Cells[4];

                        if (comboBoxCell.Value != null)
                        {
                            string stdRole = comboBoxCell.Value.ToString();
                            int std = stdRole == "Present" ? 1 : (stdRole == "Absent" ? 2 : 0);

                            SqlCommand insertAttendance = new SqlCommand("INSERT INTO Attendance (Status) VALUES (@Status)", con);
                            insertAttendance.Parameters.AddWithValue("@Status", std);
                            insertAttendance.ExecuteNonQuery();
                        }
                    }
                }
            }
        }



        public void GetStudentsData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT c.classID, cs.StudentID, t.teachID AS InchargeTeacherID " +
                                            "FROM Teacher t " +
                                            "JOIN ClassTeacher ct ON t.teachID = ct.TteacherID " +
                                            "JOIN Class c ON ct.CllassID = c.classID " +
                                            "JOIN ClassStudent cs ON c.classID = cs.ClasID " +
                                            "WHERE t.teachID = @TeacherID " + 
                                            "AND t.Designation = (SELECT lookupID FROM Lookup WHERE Value = 'Incharge')", con);

          
            cmd.Parameters.AddWithValue("@TeacherID", 4);
          /*  cmd.Parameters.AddWithValue("@Date", e.date != null ? DateTime.Parse(e.date) : DateTime.Now.Date);*/

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
           


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}

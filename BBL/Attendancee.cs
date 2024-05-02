using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.DataAccess;
using DBFinalProject.Forms;
namespace DBFinalProject.BBL
{
    public class Attendancee
    {
        public int StudentID { get; set; }
     
        public int ClassID { get; set; }
        public int TeacherID { get; set; }

        public  string date{ get; set; }
        public int IsPresent { get; set; }
        public Attendancee() 
        {
        }
        public Attendancee(int stdid, int classid, int teacherid, int ispresent, string date)
        {
            this.StudentID = stdid;
            this.date = date; 

            this.ClassID = classid;
            this.TeacherID = teacherid;
            this.IsPresent = ispresent;
        }



    }
}

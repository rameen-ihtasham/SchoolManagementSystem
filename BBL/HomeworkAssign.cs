using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DBFinalProject.Forms;
namespace DBFinalProject.BBL
{
    public class HomeworkAssign
    {
        public int homeworkID { get; set; }

        public int TeacherID { get; set; }
        public int subjectId { get; set; }

        public string date { get; set; }
        public string HomeWork { get; set; }

        public string UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
        public HomeworkAssign()
        {
        }
        public HomeworkAssign(int homeworkID, int TeacherID, int subjectId, string date, string Homework,string UpdatedOn, int UpdatedBy)
        {
            this.homeworkID = homeworkID;
            this.TeacherID = TeacherID;
            this.subjectId = subjectId;
            this.date = date;
            this.HomeWork = HomeWork;
           this.UpdatedOn = UpdatedOn;
            this.UpdatedBy = UpdatedBy;




        }

    }
}

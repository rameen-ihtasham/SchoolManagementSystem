using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class ClassStudent
    {


        public int ID { get; set; }
        public int StudentID { get; set; }


        public ClassStudent(int Id, int StudentID)
        {
            ID = Id;
          this.StudentID = StudentID;

        }
    }
}

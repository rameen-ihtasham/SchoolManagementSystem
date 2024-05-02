using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DBFinalProject.BBL
{
    public class Teacher
    {
        public int teachID { get; set; }
        public int Designation { get; set; }
        public Teacher(int id, int designation)
        {
            teachID = id;
            Designation = designation;
           
        }


    }
}

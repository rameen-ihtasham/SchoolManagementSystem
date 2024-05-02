using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class Class
    {
        public int CLassId { get; set; }
        public int ClassGrade { get; set; }


        public Class(int cLassId, int classGrade)
        {
            CLassId = cLassId;
            ClassGrade = classGrade;
        }
    }
}

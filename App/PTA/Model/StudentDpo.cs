using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.Data;
using PTA.Dpo;

namespace PTA
{
    public class StudentDpo : ptaStudentDpo
    {
        public StudentDpo()
        {
        }

        public StudentDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public StudentDpo(int student_id)
            : base(student_id)
        { 
        }
    }
}

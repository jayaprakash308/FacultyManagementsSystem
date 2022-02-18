using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{

    public class CoursesTaught
    {
        //properties of courses taught
        public int CourseID { get; set; }
        public int FacultyID { get; set; }
        public int SubjectID { get; set; }
        public DateTime FirstDateTaught { get; set; }

        //constructor of courses taught
        public CoursesTaught()
        {
           
        }

    }
}
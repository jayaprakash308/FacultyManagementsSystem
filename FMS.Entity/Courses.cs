using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{
    public class Courses
    {
        //properties of courses
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseCredits { get; set; }
        public int DeptID { get; set; }

        //constructor of courses
        public Courses()
        {
           
        }

    }
}
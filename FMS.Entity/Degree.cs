using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{
    public class Degrees
    {
        //properties of degrees
        public int DegreeID { get; set; }
        public int FacultyID { get; set; }
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public string DegreeYear { get; set; }
        public char Grade { get; set; }

        //constructor of degrees
        public Degrees()
        {
           

        }

    }
}
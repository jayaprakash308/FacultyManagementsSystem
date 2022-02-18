using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{
    //properties of grants
    public class Grants
    {
        public int GrantID { get; set; }
        public int FacultyID { get; set; }
        public string GrantTitle { get; set; }
        public string GrantDescription { get; set; }

        //constructor of grants
        public Grants()
        {
            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Entity
{

    public class WorkHistory
    {
        //properties of workhistory
        public int WorkHistoryID { get; set; }
        public int FacultyID { get; set; }
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public DateTime JobBeginDate { get; set; }
        public DateTime JobEndDate { get; set; }
        public string JobResponsibilities { get; set; }
        public string JobType { get; set; }

        //constructor of workhistory
        public WorkHistory()
        {
           

        }

    }
}
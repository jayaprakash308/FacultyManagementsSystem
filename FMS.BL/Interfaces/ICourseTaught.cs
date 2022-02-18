using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.DAL;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;

namespace FMS.BL.Interfaces
{
    interface ICourseTaught
    {
        void AddCourseTaught(CoursesTaught courseTaught);
        void UpdCourseTaught(CoursesTaught courseTaught);
        void DelCourseTaught(CoursesTaught courseTaught);
        void AddorUpdorDelCourseTaught(CoursesTaught courseTaught, string cmdtext);
        ArrayList PrintCourseTaught(CoursesTaught courseTaught);
    }

        
}

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
    interface IFacultyBL
    {
        void AddPersonalInfo(Faculty faculty);
        void UpdPersonalInfo(Faculty faculty);
        void DelPersonalnfo(Faculty faculty);
        Faculty PrintFacultyInfo(Faculty faculty);
        ArrayList PrintAllFacultyInfo(Faculty faculty);
        void AddGrants(Grants grants);
        void DelCourseTaught(CoursesTaught coursesTaught);
        ArrayList PrintCourseTaught(CoursesTaught courseTaught);
        void UpdCourseTaught(CoursesTaught courseTaught);
        void AddCourseTaught(CoursesTaught courseTaught);
        void UpdGrants(Grants grants);
        void DelGrants(Grants grants);
        ArrayList PrintGrants(Grants grants);
       


    }
}

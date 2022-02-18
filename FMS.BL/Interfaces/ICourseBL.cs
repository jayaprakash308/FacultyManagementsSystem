using System;
using System.Collections.Generic;
using System.Text;
using FMS.Entity;

namespace FMS.BL
{
    public interface ICourseBL
    {
        void AddNewCourse(Courses newcourse);
        void UpdateCourse(Courses newcourse);
        void DeleteCourse(Courses newcourse);



    }
}

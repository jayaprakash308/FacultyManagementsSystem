using System;
using System.Collections.Generic;
using System.Text;
using FMS.Entity;

namespace FMS.BL
{
    public interface IAdministatorBL
    {
        void AddNewUser(Users newuser);
        void AddNewDesignation(Designation newdesignation);
        void AddNewSubject(Subjects newsubject);
        void UpdateSubject(Subjects newsubject);
        void DeleteSubject(Subjects newsubject);
        void UpdCurrentJob(Faculty faculty);



    }
}

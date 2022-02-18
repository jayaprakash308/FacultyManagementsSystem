using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.DAL;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
using FMS.BL.Interfaces;

namespace FMS.BL
{
    public class FacultyInfo : IFacultyInfo
    {
        void IFacultyInfo.AddPersonalInfo(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        void IFacultyInfo.PrintFacultyInfo(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        void IFacultyInfo.UpdPersonalInfo(Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
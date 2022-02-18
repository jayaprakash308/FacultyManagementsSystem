using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.BL;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;

namespace FMS.BL
{
    public class AdministatorBL : IAdministatorBL
    {

        #region
        public void AddNewUser(Users newuser)
        {
            try
            {
                FacultyDAL newuserDAL = new FacultyDAL();
                // call add new user method of DAL
                newuserDAL.AddNewUser(newuser);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void AddNewDesignation(Designation newdesignation)
        {
            try
            {
                FacultyDAL newdesgnDAL = new FacultyDAL();
                // call add new designation method of DAL
                newdesgnDAL.AddNewDesignation(newdesignation);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void AddNewSubject(Subjects newsubject)
        {
            try
            {
                FacultyDAL addsubjDAL = new FacultyDAL();
                // call add new subject method of DAL
                addsubjDAL.AddNewSubject(newsubject);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void UpdateSubject(Subjects newsubject)
        {
            try
            {
                FacultyDAL updSubjDAL = new FacultyDAL();
                // call update subject method of DAL
                updSubjDAL.UpdateSubject(newsubject);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
       public  void DeleteSubject(Subjects newsubject)
        {
            try
            {
                FacultyDAL delSubjDAL = new FacultyDAL();
                // call delete subject method of DAL
                delSubjDAL.DeleteSubject(newsubject);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
       public void UpdCurrentJob(Faculty faculty)
        {
            try
            {
                FacultyDAL updJobDAL = new FacultyDAL();
                // call update current job method of DAL
                updJobDAL.UpdCurrentJob(faculty);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        #endregion

    }

}
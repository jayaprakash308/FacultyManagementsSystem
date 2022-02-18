using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FMS.Entity;
using FMS.Exceptions;
using FMS.DAL;

namespace FMS.DAL
{
    class CourseDAL
    {
        #region CourseMethods

        //method for add or update or delete course
        public void AddorUpdorDelCourse(Courses newcourse, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            if (cmdtext == "coursesinsert" || cmdtext == "coursesupdate")
            {

                cmd.Parameters.AddWithValue("@coursename", newcourse.CourseName);
                cmd.Parameters.AddWithValue("@coursecredit", newcourse.CourseCredits);
                cmd.Parameters.AddWithValue("@deptid", newcourse.DeptID);
            }
            if (cmdtext == "coursesupdate" || cmdtext == "coursesdelete")
            {
                cmd.Parameters.AddWithValue("@courseid", newcourse.CourseID);
            }
            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                //print succedded message
                if (cmdtext == "coursesinsert")
                    throw new FacultyExceptions(recordcount + " Course Successfully added");
                else if (cmdtext == "coursesupdate")
                    throw new FacultyExceptions(recordcount + " Course Successfully updated");
                else if (cmdtext == "coursesdelete")
                    throw new FacultyExceptions(recordcount + " Course Successfully deleted");

            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
        }

        //method for add new course
        public void AddNewCourse(Courses newcourse)
        {
            try
            {
                string cmdtext = "coursesinsert";
                //call add or update or delete course method
                AddorUpdorDelCourse(newcourse, cmdtext);
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

        //method for update course
        public void UpdateCourse(Courses newcourse)
        {
            try
            {
                string cmdtext = "coursesupdate";
                //call add or update or delete course method
                AddorUpdorDelCourse(newcourse, cmdtext);
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

        //method for delete course
        public void DeleteCourse(Courses newcourse)
        {
            try
            {
                string cmdtext = "coursesdelete";
                //call add or update or delete course method
                AddorUpdorDelCourse(newcourse, cmdtext);
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

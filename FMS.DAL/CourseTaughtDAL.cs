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
    class CourseTaughtDAL
    {
        #region CourseTaughtMethods
        //method for add new course taught
        public void AddCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                string cmdtext = "CourseTaughtInsert";
                //call add or update or delete course taught method
                AddorUpdorDelCourseTaught(courseTaught, cmdtext);
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

        //method for update course taught
        public void UpdCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                string cmdtext = "CourseTaughtUpdate";
                //call add or update or delete course taught method
                AddorUpdorDelCourseTaught(courseTaught, cmdtext);
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

        //method for delete course taught
        public void DelCourseTaught(CoursesTaught courseTaught)
        {
            try
            {
                string cmdtext = "CourseTaughtDelete";
                //call add or update or delete course taught method
                AddorUpdorDelCourseTaught(courseTaught, cmdtext);
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

        //method for add or update or delete course taught
        public void AddorUpdorDelCourseTaught(CoursesTaught courseTaught, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", courseTaught.FacultyID);
            if (cmdtext == "CourseTaughtUpdate" || cmdtext == "CourseTaughtInsert")
            {
                cmd.Parameters.AddWithValue("@FirstDateTaught", courseTaught.FirstDateTaught);
                cmd.Parameters.AddWithValue("@subjectid", courseTaught.SubjectID);

            }
            if (cmdtext == "CourseTaughtUpdate" || cmdtext == "CourseTaughtDelete")
            {
                cmd.Parameters.AddWithValue("@courseid", courseTaught.CourseID);
            }

            int facultyid = courseTaught.FacultyID;
            try
            {
                if (validate(facultyid))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "CourseTaughtInsert")
                        throw new FacultyExceptions("CoursesTaught record Successfully Inserted");
                    else if (cmdtext == "CourseTaughtUpdate")
                        throw new FacultyExceptions("CoursesTaught record Successfully Updated");
                    else if (cmdtext == "CourseTaughtDelete")
                        throw new FacultyExceptions("CoursesTaught Record Successfully Deleted");
                }
                else
                {

                    throw new FacultyExceptions("you are not authorized for this action");
                }

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

        //method for print course taught
        public ArrayList PrintCourseTaught(CoursesTaught courseTaught)
        {
            ArrayList courseTaughtList = new ArrayList();
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "CourseTaughtSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FacultyID", courseTaught.FacultyID);
            CoursesTaught coursesTaught;
            int facultyid = courseTaught.FacultyID;
            if (validate(facultyid))
            {
                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            //read course taught details from database
                            coursesTaught = new CoursesTaught();
                            coursesTaught.CourseID = sqldatareader.GetInt32(0);

                            coursesTaught.FirstDateTaught = sqldatareader.GetDateTime(1);

                            coursesTaught.SubjectID = sqldatareader.GetInt32(2);

                            coursesTaught.FacultyID = sqldatareader.GetInt32(3);
                            courseTaughtList.Add(coursesTaught);
                        }
                    }
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
                return courseTaughtList;
            }
            else
            {

                throw new FacultyExceptions("you are not authorized for this action");

            }
        }

        #endregion
    }
}

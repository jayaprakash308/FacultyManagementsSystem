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
    class AdministatorDAL
    {
        #region AdministratorMethods


        //method for validate username
        public void ValidateUserName(string UserName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "UserNameCheck";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@username", UserName);
            try
            {
                conn.Open();
                SqlDataReader sqldatareader = cmd.ExecuteReader();
                if (sqldatareader.HasRows)
                {

                    throw new FacultyExceptions("Username already exists");


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

        //validating password method
        public void ValidatePassword(string Password)
        {

            try
            {
                if (Password.Length < 8)
                {
                    throw new FacultyExceptions("Password length must be greater than 8 characters");
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

        }


        //method for add new user
        public void AddNewUser(Users newuser)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "UsersInsert";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@username", newuser.UserName1);
            cmd.Parameters.AddWithValue("@password", newuser.Password1);
            //  cmd.Parameters.AddWithValue("@usertype", newuser.Usertype);
            // cmd.Parameters.AddWithValue("@uid", newuser.UniversalID);
            try
            {
                ValidateUserName(newuser.UserName1);
                ValidatePassword(newuser.Password1);
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                string acknowledgement = recordcount + " user successfully added";
                throw new FacultyExceptions(acknowledgement);

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

        //method for add new designation
        public void AddNewDesignation(Designation newdesignation)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "DesignationInsert";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@designationname", newdesignation.DesignationName);
            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                string acknowledgement = recordcount + " Designation Successfully added";
                throw new FacultyExceptions(acknowledgement);

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

        //method for add department
        public void AddDepartment(Department newdept)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "DepartmentsInsert";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@deptname", newdept.DeptName);

            try
            {
                conn.Open();
                int recordcount = cmd.ExecuteNonQuery();
                string acknowledgement = recordcount + " Department Successfully added";
                throw new FacultyExceptions(acknowledgement);

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

        //method for update current job
        public void UpdCurrentJob(Faculty faculty)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "CurrentJobUpd";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);
            cmd.Parameters.AddWithValue("@deptid", faculty.DeptID);
            cmd.Parameters.AddWithValue("@desgnid", faculty.DesignationID);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                throw new FacultyExceptions("Current Job of Faculty Successfully updated");


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




        //method for print all faculty information
        public ArrayList PrintAllFacultyInfo(Faculty faculty)
        {

            var objectList = new ArrayList();
            //create list for storing select stored procedure
            List<String> storedproc = new List<string>
            {
                "DegreesSelect",
                "PublicationsSelect",
                "WorkHistoriesSelect",
                "CourseTaughtSelect",
                "GrantsSelect"
            };
            //create objects
            Degrees degree = new Degrees();
            Publications publication = new Publications();
            WorkHistory work = new WorkHistory();
            CoursesTaught course = new CoursesTaught();
            Grants Grants = new Grants();
            foreach (string cmdtext in storedproc)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);

                try
                {
                    conn.Open();
                    SqlDataReader sqldatareader = cmd.ExecuteReader();
                    if (sqldatareader.HasRows)
                    {
                        while (sqldatareader.Read())
                        {
                            if (storedproc.IndexOf(cmdtext) == 0)
                            {
                                //read degree details from database
                                degree.DegreeID = sqldatareader.GetInt32(0);
                                degree.Degree = sqldatareader.GetString(1);
                                degree.Specialization = sqldatareader.GetString(2);
                                degree.DegreeYear = sqldatareader.GetString(3);
                                degree.Grade = Convert.ToChar(sqldatareader.GetString(4));
                                degree.FacultyID = sqldatareader.GetInt32(5);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 1)
                            {
                                //read publication details from database
                                publication.PublicationID = sqldatareader.GetInt32(0);
                                publication.PublicationTitle = sqldatareader.GetString(1);
                                publication.ArticleName = sqldatareader.GetString(2);
                                publication.PublisherName = sqldatareader.GetString(3);
                                publication.PublicationLocation = sqldatareader.GetString(4);
                                publication.CitationDate = sqldatareader.GetDateTime(5);
                                publication.FacultyID = sqldatareader.GetInt32(6);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 2)
                            {
                                //read work history details from database
                                work.WorkHistoryID = sqldatareader.GetInt32(0);
                                work.Organization = sqldatareader.GetString(1);
                                work.JobTitle = sqldatareader.GetString(2);
                                work.JobBeginDate = sqldatareader.GetDateTime(3);
                                work.JobEndDate = sqldatareader.GetDateTime(4);
                                work.JobResponsibilities = sqldatareader.GetString(5);
                                work.JobType = sqldatareader.GetString(6);
                                work.FacultyID = sqldatareader.GetInt32(7);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 3)
                            {
                                //read course details from database
                                course.CourseID = sqldatareader.GetInt32(0);
                                course.FirstDateTaught = sqldatareader.GetDateTime(1);
                                course.SubjectID = sqldatareader.GetInt32(2);
                                course.FacultyID = sqldatareader.GetInt32(3);
                            }
                            else if (storedproc.IndexOf(cmdtext) == 4)
                            {
                                //read grant details from database
                                Grants.GrantID = sqldatareader.GetInt32(0);
                                Grants.GrantTitle = sqldatareader.GetString(1);
                                Grants.GrantDescription = sqldatareader.GetString(2);
                                Grants.FacultyID = sqldatareader.GetInt32(3);
                            }
                        }

                    }

                    //add details in list
                    objectList.Add(degree);
                    objectList.Add(publication);
                    objectList.Add(work);
                    objectList.Add(course);
                    objectList.Add(Grants);
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
                    conn.Close();
                }


            }
            return objectList;
        }


        #endregion
    }
}

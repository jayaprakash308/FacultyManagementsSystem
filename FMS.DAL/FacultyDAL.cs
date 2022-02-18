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
    public class FacultyDAL
    {
        #region FacultyDALmethods
        //method for add personal information
        public void AddPersonalInfo(Faculty faculty)
        {
            try
            {
                string cmdtext = "FacultyInsert";
                //call add or update or delete personal information method
                AddorUpdorDelPersonalInfo(faculty, cmdtext);
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

        //method for update personal information
        public void UpdPersonalInfo(Faculty faculty)
        {
            try
            {
                string cmdtext = "FacultyUpdate";
                //call add or update or delete personal information method
                AddorUpdorDelPersonalInfo(faculty, cmdtext);
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
        //method for delete personal information
        public void DelPersonalnfo(Faculty faculty)
        {
            try
            {
                string cmdtext = "FacultyDelete";
                //call add or update or delete personal information method
                AddorUpdorDelPersonalInfo(faculty, cmdtext);
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

        //method for add or update or delete personal information
        public void AddorUpdorDelPersonalInfo(Faculty faculty, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmdtext == "FacultyInsert" || cmdtext == "FacultyUpdate")
            {
                cmd.Parameters.AddWithValue("@firstname", faculty.FirstName);
                cmd.Parameters.AddWithValue("@lastname", faculty.LastName);
                cmd.Parameters.AddWithValue("@address", faculty.Address);
                cmd.Parameters.AddWithValue("@city", faculty.City);
                cmd.Parameters.AddWithValue("@state", faculty.State);
                cmd.Parameters.AddWithValue("pincode", faculty.Pincode);
                cmd.Parameters.AddWithValue("@mobileno", faculty.MoblieNo);
                cmd.Parameters.AddWithValue("hiredate", faculty.HireDate);
                cmd.Parameters.AddWithValue("@email", faculty.EmailAddress);
                cmd.Parameters.AddWithValue("dob", faculty.DateofBirth);
                cmd.Parameters.AddWithValue("@deptid", faculty.DeptID);
                cmd.Parameters.AddWithValue("@desgnid", faculty.DesignationID);
            }


            cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);

            int facultyid = faculty.FacultyID;

            if (validate(facultyid))
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //printing succedded message 
                    if (cmdtext == "FacultyInsert")
                    {
                        throw new FacultyExceptions("Faculty Personal Information Succesfully Added");
                    }
                    else if (cmdtext == "FacultyUpdate")
                    {
                        throw new FacultyExceptions("Faculty Personal Information Successfully Updated");
                    }
                    else if (cmdtext == "FacultyDelete")
                    {
                        throw new FacultyExceptions("Faculty Personal Information Successfully Deleted");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
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
            else
            {

                throw new FacultyExceptions("You are not authorized for this action");

            }



        }


        //method for print faculty information
        public Faculty PrintFacultyInfo(Faculty faculty)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "FacultySelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@facultyid", faculty.FacultyID);
            int facultyid = faculty.FacultyID;
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
                            //read faculty information from database
                            faculty.FirstName = sqldatareader.GetString(0);
                            faculty.LastName = sqldatareader.GetString(1);
                            faculty.Address = sqldatareader.GetString(2);
                            faculty.City = sqldatareader.GetString(3);
                            faculty.State = sqldatareader.GetString(4);
                            faculty.Pincode = sqldatareader.GetInt32(5);
                            faculty.MoblieNo = sqldatareader.GetString(6);
                            faculty.HireDate = sqldatareader.GetDateTime(7);
                            faculty.EmailAddress = sqldatareader.GetString(8);
                            faculty.DateofBirth = sqldatareader.GetDateTime(9);
                            faculty.DeptID = sqldatareader.GetInt32(10);
                            faculty.DesignationID = sqldatareader.GetInt32(11);
                            faculty.FacultyID = sqldatareader.GetInt32(12);

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
                return faculty;
            }
            else
            {
                throw new FacultyExceptions("you are not authorized for this action");
                // return faculty;
            }


        }

        #endregion


        #region ValidateFacultyMethod
        //method for faculty validation
        public bool validate(int facultyid)
        {
            try
            {
                int UniversalID = 0;
                if (facultyid == UniversalID || UniversalID > 2000 || (UniversalID > 100 && UniversalID < 1000))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #region GrantsMethods
        //method for add grant details
        public void AddGrants(Grants grants)
        {
            try
            {
                string cmdtext = "GrantsInsert";
                //call add or update or delete grant method
                AddorUpdorDelGrants(grants, cmdtext);
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
        //method for update grant details
        public void UpdGrants(Grants grants)
        {
            try
            {
                string cmdtext = "GrantsUpdate";
                //call add or update or delete grant method
                AddorUpdorDelGrants(grants, cmdtext);
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

        //method for delete grant details
        public void DelGrants(Grants grants)
        {
            try
            {
                string cmdtext = "GrantsDelete";
                //call add or update or delete grant method
                AddorUpdorDelGrants(grants, cmdtext);
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

        //method for add or update or delete grant
        public void AddorUpdorDelGrants(Grants grants, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmdtext == "GrantsInsert" || cmdtext == "GrantsUpdate")
            {
                cmd.Parameters.AddWithValue("@GrantTitle", grants.GrantTitle);
                cmd.Parameters.AddWithValue("@GrantDescription", grants.GrantDescription);
                cmd.Parameters.AddWithValue("facultyid", grants.FacultyID);
            }
            if (cmdtext == "GrantsDelete")
            {
                cmd.Parameters.AddWithValue("facultyid", grants.FacultyID);
            }
            if (cmdtext == "GrantsUpdate" || cmdtext == "GrantsDelete")
            {
                cmd.Parameters.AddWithValue("@grantid", grants.GrantID);
            }

            int facultyid = grants.FacultyID;
            try
            {
                if (validate(facultyid))
                {
                    conn.Open();
                    int recordcount = cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "GrantsInsert")
                        throw new FacultyExceptions(recordcount + " Grant Record Successfully Inserted");
                    else if (cmdtext == "GrantsUpdate")
                        throw new FacultyExceptions(recordcount + " Grant Record Successfully Updated");
                    else if (cmdtext == "GrantsDelete")
                        throw new FacultyExceptions(recordcount + " Grants Record Successfully Deleted");

                }
                else
                {

                    throw new FacultyExceptions("you are not authorised for this action");

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

        //method for print grant details
        public ArrayList PrintGrants(Grants grant)
        {
            ArrayList grantsList = new ArrayList();
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "GrantsSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@facultyid", grant.FacultyID);
            Grants grants;

            int facultyid = grant.FacultyID;
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
                            //read grant details from database
                            grants = new Grants();
                            grants.GrantID = sqldatareader.GetInt32(0);

                            grants.GrantTitle = sqldatareader.GetString(1);

                            grants.GrantDescription = sqldatareader.GetString(2);

                            grants.FacultyID = sqldatareader.GetInt32(3);
                            grantsList.Add(grants);

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
                return grantsList;
            }
            else
            {
                throw new FacultyExceptions("you are not authorised for this action");

            }
        }

        #endregion 
        #endregion
    }

}


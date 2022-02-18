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
    class LoginCheckDAL
    {
        #region Variables
        int access;
        public static int UniversalID;
        SqlConnection con = null;

        #endregion


        #region LoginCheckMethod

        //method for login check
        public int LoginCheck(Users user)
        {

            // SqlConnection con = null;
            // SqlCommand cmd = null;
            // SqlDataReader sdr = null;
            con = new SqlConnection("server=.;Integrated Security=true;Database=SPRINT_DB");
            // con.ConnectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;
            SqlCommand cmd = new SqlCommand("select * from users where username='" + user.UserName + "' and password='" + user.Password + "'");



            //string cmdtext = "UsersSelect";
            //SqlCommand cmd = new SqlCommand(cmdtext, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@username", user.UserName1);
            //cmd.Parameters.AddWithValue("@password", user.Password1);
            //cmd.Parameters.AddWithValue("@usertype", user.Usertype);

            //cmd.Parameters.AddWithValue("@UniversalID",user.UniversalID);

            try
            {
                // string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
                cmd.Connection = con;
                con.Open();
                SqlDataReader sqldatareader = cmd.ExecuteReader();
                if (sqldatareader.HasRows)
                {
                    while (sqldatareader.Read())
                    {
                        int useruID = sqldatareader.GetInt32(0);
                        string userName = sqldatareader.GetString(1);
                        string password = sqldatareader.GetString(2);
                        string usertype = sqldatareader.GetString(3);



                        if (password == user.Password1)
                        {
                            if (usertype == "faculty")
                            {
                                access = 2;
                                return access;
                            }
                            else if (usertype == "admin")
                            {
                                access = 1;
                                return access;
                            }
                            else if (usertype == "student")
                            {
                                access = 0;
                                return access;
                            }

                        }
                        else
                        {
                            throw new FacultyExceptions("wrong password");

                        }
                    }
                }
                else
                {
                    throw new FacultyExceptions("You are not valid user");
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
                if (con != null)
                    con.Close();
            }
            return -1;
        }
        #endregion
    }
}

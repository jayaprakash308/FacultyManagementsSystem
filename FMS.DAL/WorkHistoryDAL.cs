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
    class WorkHistoryDAL
    {
        #region WorkHistoryMethods
        //method for add work history information
        public void AddWorkHistoryInfo(WorkHistory workHistory)
        {
            try
            {
                string cmdtext = "WorkHistoriesInsert";
                //call add or update or delete work history information method
                AddorUpdorDelWorkInfo(workHistory, cmdtext);
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

        //method for update work history information
        public void UpdWorkHistoryInfo(WorkHistory workHistory)
        {
            try
            {
                string cmdtext = "WorkHistoriesUpdate";
                //call add or update or delete work history information method
                AddorUpdorDelWorkInfo(workHistory, cmdtext);
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

        //method for delete work history information
        public void DelWorkHistoryInfo(WorkHistory workHistory)
        {
            try
            {
                string cmdtext = "WorkHistoriesDelete";
                //call add or update or delete work history information method
                AddorUpdorDelWorkInfo(workHistory, cmdtext);
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

        //method for add or update or delete work history information 
        public void AddorUpdorDelWorkInfo(WorkHistory workHistory, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", workHistory.FacultyID);
            if (cmdtext == "WorkHistoriesInsert" || cmdtext == "WorkHistoriesUpdate")
            {
                cmd.Parameters.AddWithValue("@organization", workHistory.Organization);
                cmd.Parameters.AddWithValue("@jobtitle", workHistory.JobTitle);
                cmd.Parameters.AddWithValue("@jobbegindate", workHistory.JobBeginDate);
                cmd.Parameters.AddWithValue("@jobenddate", workHistory.JobEndDate);
                cmd.Parameters.AddWithValue("@jobresponsibilities", workHistory.JobResponsibilities);
                cmd.Parameters.AddWithValue("@jobtype", workHistory.JobType);
            }
            if (cmdtext == "WorkHistoriesUpdate" || cmdtext == "WorkHistoriesDelete")
            {
                cmd.Parameters.AddWithValue("@workid", workHistory.WorkHistoryID);
            }
            int facultyid = workHistory.FacultyID;
            try
            {
                if (validate(facultyid))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "WorkHistoriesInsert")
                        throw new FacultyExceptions("Work history Successfully Inserted");
                    else if (cmdtext == "WorkHistoriesUpdate")
                        throw new FacultyExceptions("Work history Successfully Updated");
                    else if (cmdtext == "WorkHistoriesDelete")
                        throw new FacultyExceptions("WorkHistory Successfully Deleted");
                }
                else
                {
                    throw new FacultyExceptions("You are not a valid user");
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

        // method for printing work history details
        public ArrayList PrintWorkHistoryInfo(WorkHistory workHistoryy)
        {
            ArrayList workList = new ArrayList();
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "WorkHistoriesSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            WorkHistory workHistory = new WorkHistory();
            int facultyid = workHistoryy.FacultyID;
            cmd.Parameters.AddWithValue("@facultyid", workHistoryy.FacultyID);

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
                            //read work history informatio from database
                            workHistory = new WorkHistory();
                            workHistory.WorkHistoryID = sqldatareader.GetInt32(0);
                            workHistory.Organization = sqldatareader.GetString(1);
                            workHistory.JobTitle = sqldatareader.GetString(2);
                            workHistory.JobBeginDate = sqldatareader.GetDateTime(3);
                            workHistory.JobEndDate = sqldatareader.GetDateTime(4);
                            workHistory.JobResponsibilities = sqldatareader.GetString(5);
                            workHistory.JobType = sqldatareader.GetString(6);
                            workHistory.FacultyID = sqldatareader.GetInt32(7);
                            workList.Add(workHistory);

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
                return workList;
            }
            else
            {
                throw new FacultyExceptions("you are not authorised for this action");
            }
        }
        #endregion
    }
}

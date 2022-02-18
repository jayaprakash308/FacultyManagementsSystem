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
    class PublicationDAL
    {
        #region PublicationMethods

        //method for add new publication
        public void AddPublications(Publications publications)
        {
            try
            {
                string cmdtext = "PublicationInsert";
                //call add or update or delete publications method
                AddorUpdorDelPublications(publications, cmdtext);
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

        //method for update publication
        public void UpdPublications(Publications publications)
        {
            try
            {
                string cmdtext = "PublicationUpdate";
                //call add or update or delete publications method
                AddorUpdorDelPublications(publications, cmdtext);
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

        //method for delete publication
        public void DelPublications(Publications publications)
        {
            try
            {
                string cmdtext = "PublicationDelete";
                //call add or update or delete publications method
                AddorUpdorDelPublications(publications, cmdtext);
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

        //method  for add or update or delete publications
        public void AddorUpdorDelPublications(Publications publications, string cmdtext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@facultyid", publications.FacultyID);

            if (cmdtext == "PublicationInsert" || cmdtext == "PublicationUpdate")
            {
                cmd.Parameters.AddWithValue("@publictitle", publications.PublicationTitle);
                cmd.Parameters.AddWithValue("@articlename", publications.ArticleName);
                cmd.Parameters.AddWithValue("@publicname", publications.PublisherName);
                cmd.Parameters.AddWithValue("@publicloc", publications.PublicationLocation);
                cmd.Parameters.AddWithValue("@Citationdt", publications.CitationDate);
            }
            if (cmdtext == "PublicationUpdate" || cmdtext == "PublicationDelete")
            {
                cmd.Parameters.AddWithValue("@publicid", publications.PublicationID);
            }
            int facultyid = publications.FacultyID;
            try
            {
                if (validate(facultyid))
                {

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //print succedded message
                    if (cmdtext == "PublicationInsert")
                        throw new FacultyExceptions("Publication Successfully Inserted");
                    else if (cmdtext == "PublicationUpdate")
                        throw new FacultyExceptions("Publication Successfully Updated");
                    else if (cmdtext == "PublicationDelete")
                        throw new FacultyExceptions("Publication Successfully Deleted");

                }
                else
                {
                    throw new FacultyExceptions("You are not authorised for this action");
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
                conn.Close();

            }

        }

        //method for print publication details
        public ArrayList PrintPublications(Publications publication)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            string cmdtext = "PublicationsSelect";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            ArrayList publicationList = new ArrayList();

            cmd.Parameters.AddWithValue("@facultyid", publication.FacultyID);
            Publications publications;
            int facultyid = publication.FacultyID;
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
                            //read publication details from database
                            publications = new Publications();
                            publications.PublicationID = sqldatareader.GetInt32(0);
                            publications.PublicationTitle = sqldatareader.GetString(1);
                            publications.ArticleName = sqldatareader.GetString(2);
                            publications.PublisherName = sqldatareader.GetString(3);
                            publications.PublicationLocation = sqldatareader.GetString(4);
                            publications.CitationDate = sqldatareader.GetDateTime(5);
                            publications.FacultyID = sqldatareader.GetInt32(6);

                            publicationList.Add(publications);
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
                return publicationList;
            }
            else
            {

                throw new FacultyExceptions("you are not authorised for this action");

            }
        }
        #endregion

        #region PublicationYearorMonthorRecent

        //method for print publication yearwise
        public ArrayList PrintPublicationsYear(string year)
        {
            ArrayList publicationList = null;
            try
            {
                string cmdtext = "YearSelect";
                //call print year or month or recent method
                publicationList = PrintYearorMonthorRecent(year, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publicationList;
        }
        //method for print publication monthwise
        public ArrayList PrintPublicationsMonth(string month)
        {
            ArrayList publicationList = null;
            try
            {
                string cmdtext = "MonthSelect";
                //call print year or month or recent method
                publicationList = PrintYearorMonthorRecent(month, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publicationList;
        }


        //method for print recent publications 
        public ArrayList PrintPublicationsRecent(string recent)
        {
            ArrayList publicationList = null;
            try
            {
                string cmdtext = "RecentSelect";
                //call print year or month or recent method
                publicationList = PrintYearorMonthorRecent(recent, cmdtext);
            }
            catch (FacultyExceptions e)
            {
                throw new FacultyExceptions(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publicationList;
        }

        //method for print year or month or recent publications
        public ArrayList PrintYearorMonthorRecent(string filter, string cmdtext)
        {


            var publicationList = new ArrayList();

            string connectionString = ConfigurationManager.ConnectionStrings["FacultyInfoConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (cmdtext == "YearSelect")
            {
                cmd.Parameters.AddWithValue("@year", filter);
            }
            else if (cmdtext == "MonthSelect")
            {
                cmd.Parameters.AddWithValue("@month", filter);
            }
            else if (cmdtext == "RecentSelect")
            {
                cmd.Parameters.AddWithValue("@recent", filter);
            }
            Publications publication;
            try
            {
                conn.Open();
                SqlDataReader sqldatareader = cmd.ExecuteReader();
                if (sqldatareader.HasRows)
                {
                    while (sqldatareader.Read())
                    {
                        //read publication details from database
                        publication = new Publications();
                        publication.PublicationID = sqldatareader.GetInt32(0);
                        publication.PublicationTitle = sqldatareader.GetString(1);
                        publication.ArticleName = sqldatareader.GetString(2);
                        publication.PublisherName = sqldatareader.GetString(3);
                        publication.PublicationLocation = sqldatareader.GetString(4);
                        publication.CitationDate = sqldatareader.GetDateTime(5);
                        publication.FacultyID = sqldatareader.GetInt32(6);
                        publicationList.Add(publication);
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


            return publicationList;
        }
        #endregion
    }
}

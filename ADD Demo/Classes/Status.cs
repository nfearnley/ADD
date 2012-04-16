using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Status
    {
        private int StatusID;
        private String StatusName;

        public Status()
        { }

        public Status(String statusName)
        {
            StatusName = statusName;
        }

        public static Status GetStatus(int statusID)
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCompany", conn);
            comm.Parameters.AddWithValue("StatusID", statusID);
            Status status = new Status();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    status.StatusID = (int)reader["StatusID"];
                    status.StatusName = reader["StatusName"] as String;
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return status;
        }

        public static IEnumerable<Status> GetStatuses()
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCompany", conn);
            List<Status> statuses = new List<Status>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Status status = new Status();
                    status.StatusID = (int)reader["StatusID"];
                    status.StatusName = reader["StatusName"] as String;
                    statuses.Add(status);
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return statuses;
        }

        public static int AddStatus(Status status)
        {
            int result = 0;
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCompany", conn);
            comm.Parameters.AddWithValue("StatusID", status.StatusID);
            comm.Parameters.AddWithValue("StatusName", status.StatusName);
            try
            {
                conn.Open();
                result = comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return result;            
        }

        public static int RemoveStatus(int statusID)
        {
            int result = 0;
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCompany", conn);
            comm.Parameters.AddWithValue("StatusID", statusID);
            try
            {
                conn.Open();
                result = comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return result;
        }
    }
}
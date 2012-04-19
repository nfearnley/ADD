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
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public Status()
        { }

        public static Status GetStatus(int statusID)
        {
            Status status = new Status();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetStatus"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("StatusID", statusID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                IList<Status> statuses = Read(reader);
                status = statuses[0];
            }

            return status;
        }

        public static IEnumerable<Status> GetStatuses()
        {
            IEnumerable<Status> statuses = new List<Status>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetStatuses"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                statuses = Read(reader);
            }

            return statuses;
        }

        public static int AddStatus(Status status)
        {
            int statusID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddStatus"))
            {
                // Set Parameters
                AddParameters(status, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                statusID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return statusID;            
        }

        public static int RemoveStatus(Status oldStatus)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveStatus"))
            {
                // Set Parameters
                AddOldParameters(oldStatus, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<Status> Read(SqlDataReader reader)
        {
            IList<Status> statuses = new List<Status>();
            while (reader.Read())
            {
                Status status = new Status();
                status.StatusID = (int)reader["StatusID"];
                status.StatusName = (string)reader["StatusName"];
                statuses.Add(status);
            }
            return statuses;
        }

        private static void AddParameters(Status status, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("StatusName", status.StatusName);
        }

        private static void AddOldParameters(Status status, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldStatusID", status.StatusID);
            comm.Parameters.AddWithValue("OldStatusName", status.StatusName);
        }
    }
}
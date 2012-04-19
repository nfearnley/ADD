using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class ClientSession
    {
        public int ClientSessionID { get; set; }
        public int ClientID { get; set; }
        public int SessionID { get; set; }
        public int StatusID { get; set; }
        public bool Paid { get; set; }
        public decimal Price { get; set; }

        public ClientSession()
        { }

        public static IEnumerable<ClientSession> GetUnpaidClientSessionsByCompanyID(int companyID)
        {
            IEnumerable<ClientSession> clientSessions = new List<ClientSession>();
            
            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetUnpaidClientSessions"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CompanyID", companyID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clientSessions = Read(reader);
            }

            return clientSessions;
        }

        public static IEnumerable<ClientSession> GetClientSession(int clientSessionID)
        {
            IEnumerable<ClientSession> clientSessions = new List<ClientSession>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClientSession"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clientSessions = Read(reader);
            }

            return clientSessions;
        }

        public static IEnumerable<ClientSession> GetClientSessionsByClientID(int clientID)
        {
            IEnumerable<ClientSession> clientSessions = new List<ClientSession>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClientSessionsByClientID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("ClientID", clientID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clientSessions = Read(reader);
            }

            return clientSessions;
        }

        public static IEnumerable<ClientSession> GetClientSessionsBySessionID(int sessionID)
        {
            IEnumerable<ClientSession> clientSessions = new List<ClientSession>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClientSessionsBySessionID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("SessionID", sessionID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clientSessions = Read(reader);
            }

            return clientSessions;
        }

        public static IEnumerable<ClientSession> GetClientSessionsByStatusID(int statusID)
        {
            IEnumerable<ClientSession> clientSessions = new List<ClientSession>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClientSessionsByStatusID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("StatusID", statusID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clientSessions = Read(reader);
            }

            return clientSessions;
        }

        public static int AddClientSession(ClientSession clientSession)
        {
            int clientSessionID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddClientSession"))
            {
                // Set Parameters
                AddParameters(clientSession, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                clientSessionID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return clientSessionID;
        }

        public static int UpdateClientSession(ClientSession clientSession, ClientSession oldClientSession)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateClientSesssion"))
            {
                // Set Parameters
                AddParameters(clientSession, db.comm);
                AddOldParameters(oldClientSession, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int RemoveClientSession(ClientSession oldClientSession)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveClientSession"))
            {
                // Set Parameters
                AddOldParameters(oldClientSession, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<ClientSession> Read(SqlDataReader reader)
        {
            IList<ClientSession> clientSessions = new List<ClientSession>();
            while (reader.Read())
            {
                ClientSession clientSession = new ClientSession();
                clientSession.ClientSessionID = (int)reader["ClientSessionID"];
                clientSession.ClientID = (int)reader["ClientID"];
                clientSession.SessionID = (int)reader["SessionID"];
                clientSession.StatusID = (int)reader["StatusID"];
                clientSession.Paid = (bool)reader["Paid"];
                clientSession.Price = (decimal)reader["Price"];
                clientSessions.Add(clientSession);
            }
            return clientSessions;
        }

        private static void AddParameters(ClientSession clientSession, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("ClientID", clientSession.ClientID);
            comm.Parameters.AddWithValue("SessionID", clientSession.SessionID);
            comm.Parameters.AddWithValue("StatusID", clientSession.StatusID);
            comm.Parameters.AddWithValue("Paid", clientSession.Paid);
            comm.Parameters.AddWithValue("Price", clientSession.Price);
        }

        private static void AddOldParameters(ClientSession clientSession, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldClientSessionID", clientSession.ClientSessionID);
            comm.Parameters.AddWithValue("OldClientID", clientSession.ClientID);
            comm.Parameters.AddWithValue("OldSessionID", clientSession.SessionID);
            comm.Parameters.AddWithValue("OldStatusID", clientSession.StatusID);
            comm.Parameters.AddWithValue("OldPaid", clientSession.Paid);
            comm.Parameters.AddWithValue("OldPrice", clientSession.Price);
        }
    }
}
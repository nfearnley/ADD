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
        public int SessionID { get; set; }
        public int StatusID { get; set; }
        public int ClientID { get; set; }
        public bool Paid { get; set; }
        public float Price { get; set; }

        public ClientSession()
        { }

        public ClientSession(int sessionID, int statusID, int clientID, bool paid, float price)
        { 
            SessionID = sessionID;
            StatusID = statusID;
            ClientID = clientID;
            Paid = paid;
            Price = price;
        }

        public static IEnumerable<ClientSession> GetUnpaidClientSessions(int companyID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetUnpaidClientSessions", conn);
            comm.Parameters.AddWithValue("CompanyID", companyID);
            List<ClientSession> clientSessions = new List<ClientSession>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ClientSession clientSession = new ClientSession();
                    clientSession.ClientID = (int)reader["ClientID"];
                    clientSession.ClientSessionID = (int)reader["ClientSessionID"];
                    clientSession.SessionID = (int)reader["SessionID"];
                    clientSession.StatusID = (int)reader["StatusID"];
                    clientSession.Paid = (bool)reader["Paid"];
                    clientSession.Price = (float)reader["Price"];
                    clientSessions.Add(clientSession);
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
            return clientSessions;
        }

        public static ClientSession GetClientSession(int clientSessionID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClientSession", conn);
            comm.Parameters.AddWithValue("ClientSessionID", clientSessionID);
            ClientSession clientSession = new ClientSession();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    clientSession.ClientID = (int)reader["ClientID"];
                    clientSession.ClientSessionID = (int)reader["ClientSessionID"];
                    clientSession.SessionID = (int)reader["SessionID"];
                    clientSession.StatusID = (int)reader["StatusID"];
                    clientSession.Paid = (bool)reader["Paid"];
                    clientSession.Price = (float)reader["Price"];
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
            return clientSession;
        }

        public static List<ClientSession> GetClientSessionsByClientID(int clientID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClientSessionsByClientID", conn);
            comm.Parameters.AddWithValue("ClientID", clientID);
            List<ClientSession> clientSessions = new List<ClientSession>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ClientSession clientSession = new ClientSession();
                    clientSession.ClientID = (int)reader["ClientID"];
                    clientSession.ClientSessionID = (int)reader["ClientSessionID"];
                    clientSession.SessionID = (int)reader["SessionID"];
                    clientSession.StatusID = (int)reader["StatusID"];
                    clientSession.Paid = (bool)reader["Paid"];
                    clientSession.Price = (float)reader["Price"];
                    clientSessions.Add(clientSession);
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
            return clientSessions;
        }

        public static List<ClientSession> GetClientSessionsBySessionID(int sessionID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClientSessionsBySessionID", conn);
            comm.Parameters.AddWithValue("SessionID", sessionID);
            List<ClientSession> clientSessions = new List<ClientSession>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ClientSession clientSession = new ClientSession();
                    clientSession.ClientID = (int)reader["ClientID"];
                    clientSession.ClientSessionID = (int)reader["ClientSessionID"];
                    clientSession.SessionID = (int)reader["SessionID"];
                    clientSession.StatusID = (int)reader["StatusID"];
                    clientSession.Paid = (bool)reader["Paid"];
                    clientSession.Price = (float)reader["Price"];
                    clientSessions.Add(clientSession);
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
            return clientSessions;
        }

        public static List<ClientSession> GetClientSessionsByStatusID(int statusID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClientSessionsByStatusID", conn);
            comm.Parameters.AddWithValue("StatusID", statusID);
            List<ClientSession> clientSessions = new List<ClientSession>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ClientSession clientSession = new ClientSession();
                    clientSession.ClientID = (int)reader["ClientID"];
                    clientSession.ClientSessionID = (int)reader["ClientSessionID"];
                    clientSession.SessionID = (int)reader["SessionID"];
                    clientSession.StatusID = (int)reader["StatusID"];
                    clientSession.Paid = (bool)reader["Paid"];
                    clientSession.Price = (float)reader["Price"];
                    clientSessions.Add(clientSession);
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
            return clientSessions;
        }

        public static int AddClientSession(ClientSession cs)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddClientSession", conn);
            comm.Parameters.AddWithValue("SessionID", cs.SessionID);
            comm.Parameters.AddWithValue("StatusID", cs.StatusID);
            comm.Parameters.AddWithValue("PriceID", cs.Price);
            comm.Parameters.AddWithValue("PaidID", cs.Paid);
            comm.Parameters.AddWithValue("ClientID", cs.ClientID);
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

        public static int UpdateClientSession(ClientSession cs)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.UpdateClientSession", conn);
            comm.Parameters.AddWithValue("SessionID", cs.SessionID);
            comm.Parameters.AddWithValue("StatusID", cs.StatusID);
            comm.Parameters.AddWithValue("PriceID", cs.Price);
            comm.Parameters.AddWithValue("PaidID", cs.Paid);
            comm.Parameters.AddWithValue("ClientID", cs.ClientID);
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

        public static int RemoveClientSession(int clientSessionID)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveClientSession", conn);
            comm.Parameters.AddWithValue("ClientSessionID", clientSessionID);
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
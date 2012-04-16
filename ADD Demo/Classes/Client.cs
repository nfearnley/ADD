using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Client
    {
        private int ClientID;
        private String WorkPhone;
        private String LastName;
        private String HomePhone;
        private String FirstName;
        private String FaxPhone;
        private String AddressRegion;
        private String AddressPostalCode;
        private String AddressLine1;
        private String AddressLine2;
        private String AddressCountry;
        private String AddressCity;
        private int CompanyID;

        public Client()
        { }

        public Client(String wPhone, String lName, String hPhone, String fName, String fPhone, String region, String code, String line1, String line2, String country, String city, int companyID)
        { 
            WorkPhone = wPhone;
            LastName = lName;
            HomePhone = hPhone;
            FirstName = fName;
            FaxPhone = fPhone;
            AddressRegion = region;
            AddressPostalCode = code;
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressCountry = country;
            AddressCity = city;
            CompanyID = companyID;
        }

        public static Client GetClient(int clientID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClient", conn);
            comm.Parameters.AddWithValue("@ClientID", clientID);
            Client client = new Client();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    client.WorkPhone = reader["WorkPhone"] as String;
                    client.LastName = reader["LastName"] as String; ;
                    client.HomePhone = reader["HomePhone"] as String;
                    client.FirstName = reader["FirstName"] as String;
                    client.FaxPhone = reader["FaxPhone"] as String;
                    client.AddressRegion = reader["AddressRegion"] as String;
                    client.AddressPostalCode = reader["AddressPostalCode"] as String;
                    client.AddressLine1 = reader["AddressLine1"] as String;
                    client.AddressLine2 = reader["AddressLine2"] as String;
                    client.AddressCountry = reader["AddressCountry"] as String;
                    client.AddressCity = reader["AddressCountry"] as String;
                    client.CompanyID = (int)reader["CompanyID"];
                    client.ClientID = (int)reader["ClientID"];
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
            return client;
        }

        public static List<Client> GetClientsByCompanyID(int companyID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClientsByCompanyID", conn);
            comm.Parameters.AddWithValue("@CompanyID", companyID);
            List<Client> clients = new List<Client>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client();
                    client.WorkPhone = reader["WorkPhone"] as String;
                    client.LastName = reader["LastName"] as String; ;
                    client.HomePhone = reader["HomePhone"] as String;
                    client.FirstName = reader["FirstName"] as String;
                    client.FaxPhone = reader["FaxPhone"] as String;
                    client.AddressRegion = reader["AddressRegion"] as String;
                    client.AddressPostalCode = reader["AddressPostalCode"] as String;
                    client.AddressLine1 = reader["AddressLine1"] as String;
                    client.AddressLine2 = reader["AddressLine2"] as String;
                    client.AddressCountry = reader["AddressCountry"] as String;
                    client.AddressCity = reader["AddressCountry"] as String;
                    client.CompanyID = (int)reader["CompanyID"];
                    client.ClientID = (int)reader["ClientID"];
                    clients.Add(client);
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
            return clients;
        }

        public static List<Client> GetClients()
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetClients", conn);
            List<Client> clients = new List<Client>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client();
                    client.WorkPhone = reader["WorkPhone"] as String;
                    client.LastName = reader["LastName"] as String; ;
                    client.HomePhone = reader["HomePhone"] as String;
                    client.FirstName = reader["FirstName"] as String;
                    client.FaxPhone = reader["FaxPhone"] as String;
                    client.AddressRegion = reader["AddressRegion"] as String;
                    client.AddressPostalCode = reader["AddressPostalCode"] as String;
                    client.AddressLine1 = reader["AddressLine1"] as String;
                    client.AddressLine2 = reader["AddressLine2"] as String;
                    client.AddressCountry = reader["AddressCountry"] as String;
                    client.AddressCity = reader["AddressCountry"] as String;
                    client.CompanyID = (int)reader["CompanyID"];
                    client.ClientID = (int)reader["ClientID"];
                    clients.Add(client);
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
            return clients;
        }

        public static int AddClient(Client client)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddClient", conn);
            comm.Parameters.AddWithValue("AddressCity", client.AddressCity);
            comm.Parameters.AddWithValue("AddressCountry", client.AddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", client.AddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", client.AddressLine2);
            comm.Parameters.AddWithValue("AddressPostalCode", client.AddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", client.AddressRegion);
            comm.Parameters.AddWithValue("FirstName", client.FirstName);
            comm.Parameters.AddWithValue("LastName", client.LastName);
            comm.Parameters.AddWithValue("WorkPhone", client.WorkPhone);
            comm.Parameters.AddWithValue("FaxPhone", client.FaxPhone);
            comm.Parameters.AddWithValue("HomePhone", client.HomePhone);
            comm.Parameters.AddWithValue("CompanyID", client.CompanyID);
            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
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

        public static int RemoveClient(int clientID)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveClient", conn);
            comm.Parameters.AddWithValue("ClientID", clientID);
            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
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

        public static int UpdateClient(Client client)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.UpdateClient", conn);
            comm.Parameters.AddWithValue("AddressCity", client.AddressCity);
            comm.Parameters.AddWithValue("AddressCountry", client.AddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", client.AddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", client.AddressLine2);
            comm.Parameters.AddWithValue("AddressPostalCode", client.AddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", client.AddressRegion);
            comm.Parameters.AddWithValue("FirstName", client.FirstName);
            comm.Parameters.AddWithValue("LastName", client.LastName);
            comm.Parameters.AddWithValue("WorkPhone", client.WorkPhone);
            comm.Parameters.AddWithValue("FaxPhone", client.FaxPhone);
            comm.Parameters.AddWithValue("HomePhone", client.HomePhone);
            comm.Parameters.AddWithValue("CompanyID", client.CompanyID);
            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
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
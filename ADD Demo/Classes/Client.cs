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
        public int ClientID { get; set; }
        public int CompanyID { get; set; }
        public string AddressRegion { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } // Can be null
        public string AddressCountry { get; set; }
        public string AddressCity { get; set; }
        public string FaxPhone { get; set; }  // Can be null
        public string FirstName { get; set; }
        public string HomePhone { get; set; }
        public string LastName { get; set; }
        public string WorkPhone { get; set; }

        public Client()
        { }

        public static IEnumerable<Client> GetClient(int clientID)
        {
            IEnumerable<Client> clients = new List<Client>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClient"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("ClientID", clientID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clients = Read(reader);
                db.Dispose();
            }
            
            return clients;
        }

        public static IEnumerable<Client> GetClientsByCompanyID(int companyID)
        {
            IEnumerable<Client> clients = new List<Client>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClientsByCompanyID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CompanyID", companyID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clients = Read(reader);
            }

            return clients;
        }

        public static IEnumerable<Client> GetClients()
        {
            IEnumerable<Client> clients = new List<Client>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetClients"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                clients = Read(reader);
            }

            return clients;
        }

        public static int AddClient(Client client)
        {
            int clientID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddClient"))
            {
                // Set Parameters
                AddParameters(client, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                clientID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return clientID;
        }

        public static int RemoveClient(Client oldClient)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveClient"))
            {
                // Set Parameters
                AddOldParameters(oldClient, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int UpdateClient(Client client, Client oldClient)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateClient"))
            {
                // Set Parameters
                AddParameters(client, db.comm);
                AddOldParameters(oldClient, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<Client> Read(SqlDataReader reader)
        {
            IList<Client> clients = new List<Client>();
            while (reader.Read())
            {
                Client client = new Client();
                client.ClientID = (int)reader["ClientID"];
                client.CompanyID = (int)reader["CompanyID"];
                client.AddressCity = (string)reader["AddressCity"];
                client.AddressCountry = (string)reader["AddressCountry"];
                client.AddressLine1 = (string)reader["AddressLine1"];
                client.AddressLine2 = reader["AddressLine2"] as string; // Allow null
                client.AddressPostalCode = (string)reader["AddressPostalCode"];
                client.AddressRegion = (string)reader["AddressRegion"];
                client.FaxPhone = reader["FaxPhone"] as string; // Allow null
                client.FirstName = (string)reader["FirstName"];
                client.HomePhone = (string)reader["HomePhone"];
                client.LastName = (string)reader["LastName"];
                client.WorkPhone = (string)reader["WorkPhone"];
                clients.Add(client);
            }
            return clients;
        }

        private static void AddParameters(Client client, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CompanyID", client.CompanyID);
            comm.Parameters.AddWithValue("AddressCity", client.AddressCity);
            comm.Parameters.AddWithValue("AddressCountry", client.AddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", client.AddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", client.AddressLine2 == null ? (object)DBNull.Value :  client.AddressLine2); // Check for null
            comm.Parameters.AddWithValue("AddressPostalCode", client.AddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", client.AddressRegion);
            comm.Parameters.AddWithValue("FaxPhone", client.FaxPhone == null ? (object)DBNull.Value : client.FaxPhone); // Check for null
            comm.Parameters.AddWithValue("FirstName", client.FirstName);
            comm.Parameters.AddWithValue("HomePhone", client.HomePhone);
            comm.Parameters.AddWithValue("LastName", client.LastName);
            comm.Parameters.AddWithValue("WorkPhone", client.WorkPhone);
        }

        private static void AddOldParameters(Client client, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldClientID", client.ClientID);
            comm.Parameters.AddWithValue("OldCompanyID", client.CompanyID);
            comm.Parameters.AddWithValue("OldAddressCity", client.AddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", client.AddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", client.AddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", client.AddressLine2 == null ? (object)DBNull.Value : client.AddressLine2); // Check for null
            comm.Parameters.AddWithValue("OldAddressPostalCode", client.AddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", client.AddressRegion);
            comm.Parameters.AddWithValue("OldFaxPhone", client.FaxPhone == null ? (object)DBNull.Value : client.FaxPhone); // Check for null
            comm.Parameters.AddWithValue("OldFirstName", client.FirstName);
            comm.Parameters.AddWithValue("OldHomePhone", client.HomePhone);
            comm.Parameters.AddWithValue("OldLastName", client.LastName);
            comm.Parameters.AddWithValue("OldWorkPhone", client.WorkPhone);
        }
    }
}
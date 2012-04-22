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
        public string ClientAddressRegion { get; set; }
        public string ClientAddressPostalCode { get; set; }
        public string ClientAddressLine1 { get; set; }
        public string ClientAddressLine2 { get; set; } // Can be null
        public string ClientAddressCountry { get; set; }
        public string ClientAddressCity { get; set; }
        public string ClientFaxPhone { get; set; }  // Can be null
        public string ClientFirstName { get; set; }
        public string ClientHomePhone { get; set; }
        public string ClientLastName { get; set; }
        public string ClientWorkPhone { get; set; }
        public string ClientFullName { get { return ClientFirstName + " " + ClientLastName; } }
        public Company company { get; set; }
        public int CompanyID { get { return company.CompanyID; } set { company.CompanyID = value; } }
        public string CompanyBillingAddressCity { get { return company.CompanyBillingAddressCity; } }
        public string CompanyBillingAddressCountry { get { return company.CompanyBillingAddressCountry; } }
        public string CompanyBillingAddressLine1 { get { return company.CompanyBillingAddressLine1; } }
        public string CompanyBillingAddressLine2 { get { return company.CompanyBillingAddressLine2; } } // can be null
        public string CompanyBillingAddressPostalCode { get { return company.CompanyBillingAddressPostalCode; } }
        public string CompanyBillingAddressRegion { get { return company.CompanyBillingAddressRegion; } }
        public string CompanyBillingName { get { return company.CompanyBillingName; } }

        public Client()
        {
            company = new Company();
        }

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
                clients = ReadClients(reader);
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
                clients = ReadClients(reader);
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
                clients = ReadClients(reader);
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

        private static IList<Client> ReadClients(SqlDataReader reader)
        {
            IList<Client> clients = new List<Client>();
            while (reader.Read())
            {
                clients.Add(ReadClient(reader));
            }
            return clients;
        }

        public static Client ReadClient(SqlDataReader reader)
        {
            Client client = new Client();
            client.ClientID = (int)reader["ClientID"];
            client.ClientAddressCity = (string)reader["ClientAddressCity"];
            client.ClientAddressCountry = (string)reader["ClientAddressCountry"];
            client.ClientAddressLine1 = (string)reader["ClientAddressLine1"];
            client.ClientAddressLine2 = reader["ClientAddressLine2"] as string; // Allow null
            client.ClientAddressPostalCode = (string)reader["ClientAddressPostalCode"];
            client.ClientAddressRegion = (string)reader["ClientAddressRegion"];
            client.ClientFaxPhone = reader["ClientFaxPhone"] as string; // Allow null
            client.ClientFirstName = (string)reader["ClientFirstName"];
            client.ClientHomePhone = (string)reader["ClientHomePhone"];
            client.ClientLastName = (string)reader["ClientLastName"];
            client.ClientWorkPhone = (string)reader["ClientWorkPhone"];
            client.company = Company.ReadCompany(reader);
            return client;
        }

        private static void AddParameters(Client client, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CompanyID", client.CompanyID);
            comm.Parameters.AddWithValue("AddressCity", client.ClientAddressCity);
            comm.Parameters.AddWithValue("AddressCountry", client.ClientAddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", client.ClientAddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", client.ClientAddressLine2 == null ? (object)DBNull.Value : client.ClientAddressLine2); // Check for null
            comm.Parameters.AddWithValue("AddressPostalCode", client.ClientAddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", client.ClientAddressRegion);
            comm.Parameters.AddWithValue("FaxPhone", client.ClientFaxPhone == null ? (object)DBNull.Value : client.ClientFaxPhone); // Check for null
            comm.Parameters.AddWithValue("FirstName", client.ClientFirstName);
            comm.Parameters.AddWithValue("HomePhone", client.ClientHomePhone);
            comm.Parameters.AddWithValue("LastName", client.ClientLastName);
            comm.Parameters.AddWithValue("WorkPhone", client.ClientWorkPhone);
        }

        private static void AddOldParameters(Client client, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldClientID", client.ClientID);
            comm.Parameters.AddWithValue("OldCompanyID", client.CompanyID);
            comm.Parameters.AddWithValue("OldAddressCity", client.ClientAddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", client.ClientAddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", client.ClientAddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", client.ClientAddressLine2 == null ? (object)DBNull.Value : client.ClientAddressLine2); // Check for null
            comm.Parameters.AddWithValue("OldAddressPostalCode", client.ClientAddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", client.ClientAddressRegion);
            comm.Parameters.AddWithValue("OldFaxPhone", client.ClientFaxPhone == null ? (object)DBNull.Value : client.ClientFaxPhone); // Check for null
            comm.Parameters.AddWithValue("OldFirstName", client.ClientFirstName);
            comm.Parameters.AddWithValue("OldHomePhone", client.ClientHomePhone);
            comm.Parameters.AddWithValue("OldLastName", client.ClientLastName);
            comm.Parameters.AddWithValue("OldWorkPhone", client.ClientWorkPhone);
        }
    }
}
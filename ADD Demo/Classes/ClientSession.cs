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
        public bool ClientSessionPaid { get; set; }
        public decimal ClientSessionPrice { get; set; }
        public Client client { get; set; }
        public int ClientID { get { return client.ClientID; } set { client.ClientID = value; } }
        public string ClientAddressRegion { get { return client.ClientAddressRegion; } }
        public string ClientAddressPostalCode { get { return client.ClientAddressPostalCode; } }
        public string ClientAddressLine1 { get { return client.ClientAddressLine1; } }
        public string ClientAddressLine2 { get { return client.ClientAddressLine2; } } // Can be null
        public string ClientAddressCountry { get { return client.ClientAddressCountry; } }
        public string ClientAddressCity { get { return client.ClientAddressCity; } }
        public string ClientFaxPhone { get { return client.ClientFaxPhone; } }  // Can be null
        public string ClientFirstName { get { return client.ClientFirstName; } }
        public string ClientHomePhone { get { return client.ClientHomePhone; } }
        public string ClientLastName { get { return client.ClientLastName; } }
        public string ClientWorkPhone { get { return client.ClientWorkPhone; } }
        public string ClientFullName { get { return client.ClientFullName; } }
        public int CompanyID { get { return client.CompanyID; } }
        public string CompanyBillingAddressCity { get { return client.CompanyBillingAddressCity; } }
        public string CompanyBillingAddressCountry { get { return client.CompanyBillingAddressCountry; } }
        public string CompanyBillingAddressLine1 { get { return client.CompanyBillingAddressLine1; } }
        public string CompanyBillingAddressLine2 { get { return client.CompanyBillingAddressLine2; } } // can be null
        public string CompanyBillingAddressPostalCode { get { return client.CompanyBillingAddressPostalCode; } }
        public string CompanyBillingAddressRegion { get { return client.CompanyBillingAddressRegion; } }
        public string CompanyBillingName { get { return client.CompanyBillingName; } }
        public Session session { get; set; }
        public int SessionID { get { return session.SessionID; } set { session.SessionID = value; } }
        public DateTime SessionDateTime { get { return session.SessionDateTime; } }
        public int SessionLength { get { return session.SessionLength; } }
        public int SessionEnrolled { get { return session.SessionEnrolled; } }
        public int SessionAvailableSeats { get { return session.SessionAvailableSeats; } }
        public int CourseID { get { return session.CourseID; } }
        public string CourseCode { get { return session.CourseCode; } }
        public string CourseDescription { get { return session.CourseDescription; } }
        public string CourseOutline { get { return session.CourseOutline; } }
        public decimal CoursePrice { get { return session.CoursePrice; } }
        public int InstructorID { get { return session.InstructorID; } }
        public string InstructorAddressCity { get { return session.InstructorAddressCity; } }
        public string InstructorAddressCountry { get { return session.InstructorAddressCountry; } }
        public string InstructorAddressLine1 { get { return session.InstructorAddressLine1; } }
        public string InstructorAddressLine2 { get { return session.InstructorAddressLine2; } }
        public string InstructorAddressPostalCode { get { return session.InstructorAddressPostalCode; } }
        public string InstructorAddressRegion { get { return session.InstructorAddressRegion; } }
        public string InstructorAltPhone { get { return session.InstructorAltPhone; } }
        public string InstructorFirstName { get { return session.InstructorFirstName; } }
        public string InstructorHomePhone { get { return session.InstructorHomePhone; } }
        public string InstructorLastName { get { return session.InstructorLastName; } }
        public string InstructorFullName { get { return session.InstructorFullName; } }
        public int RoomID { get { return session.RoomID; } }
        public string RoomName { get { return session.RoomName; } }
        public int RoomSeats { get { return session.RoomSeats; } }
        public Status status { get; set; }
        public int StatusID { get { return status.StatusID; } set { status.StatusID = value; } }
        public string StatusName { get { return status.StatusName; } }

        public ClientSession()
        {
            client = new Client();
            session = new Session();
            status = new Status();
        }

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
                clientSessions = ReadClientSessions(reader);
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
                clientSessions = ReadClientSessions(reader);
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
                clientSessions = ReadClientSessions(reader);
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
                clientSessions = ReadClientSessions(reader);
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
                clientSessions = ReadClientSessions(reader);
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

        private static IList<ClientSession> ReadClientSessions(SqlDataReader reader)
        {
            IList<ClientSession> clientSessions = new List<ClientSession>();
            while (reader.Read())
            {
                clientSessions.Add(ReadClientSession(reader));
            }
            return clientSessions;
        }

        public static ClientSession ReadClientSession(SqlDataReader reader)
        {
            ClientSession clientSession = new ClientSession();
            clientSession.ClientSessionID = (int)reader["ClientSessionID"];
            clientSession.ClientSessionPaid = (bool)reader["ClientSessionPaid"];
            clientSession.ClientSessionPrice = (decimal)reader["ClientSessionPrice"];
            clientSession.client = Client.ReadClient(reader);
            clientSession.session = Session.ReadSession(reader);
            clientSession.status = Status.ReadStatus(reader);
            return clientSession;

        }

        private static void AddParameters(ClientSession clientSession, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("ClientID", clientSession.ClientID);
            comm.Parameters.AddWithValue("SessionID", clientSession.SessionID);
            comm.Parameters.AddWithValue("StatusID", clientSession.StatusID);
            comm.Parameters.AddWithValue("Paid", clientSession.ClientSessionPaid);
            comm.Parameters.AddWithValue("Price", clientSession.ClientSessionPrice);
        }

        private static void AddOldParameters(ClientSession clientSession, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldClientSessionID", clientSession.ClientSessionID);
            comm.Parameters.AddWithValue("OldClientID", clientSession.ClientID);
            comm.Parameters.AddWithValue("OldSessionID", clientSession.SessionID);
            comm.Parameters.AddWithValue("OldStatusID", clientSession.StatusID);
            comm.Parameters.AddWithValue("OldPaid", clientSession.ClientSessionPaid);
            comm.Parameters.AddWithValue("OldPrice", clientSession.ClientSessionPrice);
        }
    }
}
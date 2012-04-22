using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class InvoiceItem
    {
        public ClientSession clientSession { get; set; }
        public int ClientSessionID { get { return clientSession.ClientSessionID; } set { clientSession.ClientSessionID = value; } }
        public bool ClientSessionPaid { get { return clientSession.ClientSessionPaid; } }
        public decimal ClientSessionPrice { get { return clientSession.ClientSessionPrice; } }
        public int ClientID { get { return clientSession.ClientID; } }
        public string ClientAddressRegion { get { return clientSession.ClientAddressRegion; } }
        public string ClientAddressPostalCode { get { return clientSession.ClientAddressPostalCode; } }
        public string ClientAddressLine1 { get { return clientSession.ClientAddressLine1; } }
        public string ClientAddressLine2 { get { return clientSession.ClientAddressLine2; } } // Can be null
        public string ClientAddressCountry { get { return clientSession.ClientAddressCountry; } }
        public string ClientAddressCity { get { return clientSession.ClientAddressCity; } }
        public string ClientFaxPhone { get { return clientSession.ClientFaxPhone; } }  // Can be null
        public string ClientFirstName { get { return clientSession.ClientFirstName; } }
        public string ClientHomePhone { get { return clientSession.ClientHomePhone; } }
        public string ClientLastName { get { return clientSession.ClientLastName; } }
        public string ClientWorkPhone { get { return clientSession.ClientWorkPhone; } }
        public string ClientFullName { get { return clientSession.ClientFullName; } }
        public int SessionID { get { return clientSession.SessionID; } }
        public int SessionLength { get { return clientSession.SessionLength; } }
        public int SessionEnrolled { get { return clientSession.SessionEnrolled; } }
        public int SessionAvailableSeats { get { return clientSession.SessionAvailableSeats; } }
        public int CourseID { get { return clientSession.CourseID; } }
        public string CourseCode { get { return clientSession.CourseCode; } }
        public string CourseDescription { get { return clientSession.CourseDescription; } }
        public string CourseOutline { get { return clientSession.CourseOutline; } }
        public decimal CoursePrice { get { return clientSession.CoursePrice; } }
        public int InstructorID { get { return clientSession.InstructorID; } }
        public string InstructorAddressCity { get { return clientSession.InstructorAddressCity; } }
        public string InstructorAddressCountry { get { return clientSession.InstructorAddressCountry; } }
        public string InstructorAddressLine1 { get { return clientSession.InstructorAddressLine1; } }
        public string InstructorAddressLine2 { get { return clientSession.InstructorAddressLine2; } }
        public string InstructorAddressPostalCode { get { return clientSession.InstructorAddressPostalCode; } }
        public string InstructorAddressRegion { get { return clientSession.InstructorAddressRegion; } }
        public string InstructorAltPhone { get { return clientSession.InstructorAltPhone; } }
        public string InstructorFirstName { get { return clientSession.InstructorFirstName; } }
        public string InstructorHomePhone { get { return clientSession.InstructorHomePhone; } }
        public string InstructorLastName { get { return clientSession.InstructorLastName; } }
        public string InstructorFullName { get { return clientSession.InstructorFullName; } }
        public int RoomID { get { return clientSession.RoomID; } }
        public string RoomName { get { return clientSession.RoomName; } }
        public int RoomSeats { get { return clientSession.RoomSeats; } }
        public int StatusID { get { return clientSession.StatusID; } }
        public string StatusName { get { return clientSession.StatusName; } }
        public Invoice invoice { get; set; }
        public int InvoiceID { get { return invoice.InvoiceID; } set { invoice.InvoiceID = value; } }
        public DateTime InvoiceDate { get { return invoice.InvoiceDate; } }
        public int CompanyID { get { return invoice.CompanyID; } }
        public string CompanyBillingAddressCity { get { return invoice.CompanyBillingAddressCity; } }
        public string CompanyBillingAddressCountry { get { return invoice.CompanyBillingAddressCountry; } }
        public string CompanyBillingAddressLine1 { get { return invoice.CompanyBillingAddressLine2; } }
        public string CompanyBillingAddressLine2 { get { return invoice.CompanyBillingAddressLine2; } } // can be null
        public string CompanyBillingAddressPostalCode { get { return invoice.CompanyBillingAddressPostalCode; } }
        public string CompanyBillingAddressRegion { get { return invoice.CompanyBillingAddressRegion; } }
        public string CompanyBillingName { get { return invoice.CompanyBillingName; } }

        public InvoiceItem()
        {
            clientSession = new ClientSession();
            invoice = new Invoice();
        }

        public static IEnumerable<InvoiceItem> GetInvoiceItemsByInvoiceID(int invoiceID)
        {
            IEnumerable<InvoiceItem> invoiceItems = new List<InvoiceItem>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInvoiceItemsByInvoiceID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("InvoiceID", invoiceID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                invoiceItems = ReadInvoiceItems(reader);
            }

            return invoiceItems;
        }

        public static IEnumerable<InvoiceItem> GetInvoiceItemsByClientSessionID(int clientSessionID)
        {
            IEnumerable<InvoiceItem> invoiceItems = new List<InvoiceItem>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInvoiceItemsByClientSessionID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("ClientSessionID", clientSessionID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                invoiceItems = ReadInvoiceItems(reader);
            }

            return invoiceItems;
        }

        public static IEnumerable<InvoiceItem> GetInvoiceItems()
        {
            IEnumerable<InvoiceItem> invoiceItems = new List<InvoiceItem>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInvoiceItems"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                invoiceItems = ReadInvoiceItems(reader);
            }

            return invoiceItems;
        }

        public static int AddInvoiceItem(InvoiceItem invoiceItem)
        {
            int invoiceItemID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddInvoiceItem"))
            {
                // Set Parameters
                AddParameters(invoiceItem, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                invoiceItemID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return invoiceItemID;
        }

        public static int RemoveInvoiceItem(InvoiceItem oldInvoiceItem)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveInvoiceItem"))
            {
                // Set Parameters
                AddOldParameters(oldInvoiceItem, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<InvoiceItem> ReadInvoiceItems(SqlDataReader reader)
        {
            IList<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            while (reader.Read())
            {
                invoiceItems.Add(ReadInvoiceItem(reader));
            }
            return invoiceItems;
        }

        public static InvoiceItem ReadInvoiceItem(SqlDataReader reader)
        {
            InvoiceItem invoiceItem = new InvoiceItem();
            invoiceItem.clientSession = ClientSession.ReadClientSession(reader);
            invoiceItem.invoice = Invoice.ReadInvoice(reader);
            return invoiceItem;
        }

        private static void AddParameters(InvoiceItem invoiceItem, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("ClientSessionID", invoiceItem.ClientSessionID);
            comm.Parameters.AddWithValue("InvoiceID", invoiceItem.InvoiceID);
        }

        private static void AddOldParameters(InvoiceItem invoiceItem, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldClientSessionID", invoiceItem.ClientSessionID);
            comm.Parameters.AddWithValue("OldInvoiceID", invoiceItem.InvoiceID);
        }
    }
}
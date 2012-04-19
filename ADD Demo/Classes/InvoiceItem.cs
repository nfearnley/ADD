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
        public int ClientSessionID { get; set; }
        public int InvoiceID { get; set; }

        public InvoiceItem()
        { }

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
                invoiceItems = Read(reader);
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
                invoiceItems = Read(reader);
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
                invoiceItems = Read(reader);
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

        private static IList<InvoiceItem> Read(SqlDataReader reader)
        {
            IList<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            while (reader.Read())
            {
                InvoiceItem invoiceItem = new InvoiceItem();
                invoiceItem.ClientSessionID = (int)reader["ClientSessionID"];
                invoiceItem.InvoiceID = (int)reader["InvoiceID"];
                invoiceItems.Add(invoiceItem);
            }
            return invoiceItems;
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
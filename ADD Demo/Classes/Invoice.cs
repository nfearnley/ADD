using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int CompanyID { get; set; }
        public DateTime Date { get; set; }

        public Invoice()
        { }

        public static int GenerateInvoice(int companyID)
        {
            int invoiceID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GenerateInvoice"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CompanyID", companyID);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                invoiceID = Convert.ToInt32(db.comm.ExecuteScalar());
            }


            return invoiceID;
        }

        public static IEnumerable<Invoice> GetInvoice(int invoiceID)
        {
            IEnumerable<Invoice> invoices = new List<Invoice>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInvoice"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("InvoiceID", invoiceID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                invoices = Read(reader);
            }

            return invoices;
        }

        public static IEnumerable<Invoice> GetInvoicesByCompanyID(int companyID)
        {
            IEnumerable<Invoice> invoices = new List<Invoice>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInvoicesByCompanyID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CompanyID", companyID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                invoices = Read(reader);
            }

            return invoices;
        }

        public static IEnumerable<Invoice> GetInvoices()
        {
            IEnumerable<Invoice> invoices = new List<Invoice>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInvoices"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                invoices = Read(reader);
            }

            return invoices;
        }

        public static int AddInvoice(Invoice invoice)
        {
            int invoiceID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddInvoice"))
            {
                // Set Parameters
                AddParameters(invoice, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                invoiceID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return invoiceID;
        }

        public static int UpdateInvoice(Invoice invoice, Invoice oldInvoice)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateInvoice"))
            {
                // Set Parameters
                AddParameters(invoice, db.comm);
                AddOldParameters(oldInvoice, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int RemoveInvoice(Invoice oldInvoice)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveInvoice"))
            {
                // Set Parameters
                AddOldParameters(oldInvoice, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<Invoice> Read(SqlDataReader reader)
        {
            IList<Invoice> invoices = new List<Invoice>();
            while (reader.Read())
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceID = (int)reader["InvoiceID"];
                invoice.CompanyID = (int)reader["CompanyID"];
                invoice.Date = (DateTime)reader["Date"];
                invoices.Add(invoice);
            }
            return invoices;
        }

        private static void AddParameters(Invoice invoice, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CompanyID", invoice.CompanyID);
            comm.Parameters.AddWithValue("Date", invoice.Date);
        }

        private static void AddOldParameters(Invoice invoice, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldInvoiceID", invoice.InvoiceID);
            comm.Parameters.AddWithValue("OldCompanyID", invoice.CompanyID);
            comm.Parameters.AddWithValue("OldDate", invoice.Date);
        }
    }
}
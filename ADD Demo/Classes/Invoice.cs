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
        public DateTime InvoiceDate { get; set; }
        public Company company { get; set; }
        public int CompanyID { get { return company.CompanyID; } set { company.CompanyID = value; } }
        public string CompanyBillingAddressCity { get { return company.CompanyBillingAddressCity; } }
        public string CompanyBillingAddressCountry { get { return company.CompanyBillingAddressCountry; } }
        public string CompanyBillingAddressLine1 { get { return company.CompanyBillingAddressLine2; } }
        public string CompanyBillingAddressLine2 { get { return company.CompanyBillingAddressLine2; } } // can be null
        public string CompanyBillingAddressPostalCode { get { return company.CompanyBillingAddressPostalCode; } }
        public string CompanyBillingAddressRegion { get { return company.CompanyBillingAddressRegion; } }
        public string CompanyBillingName { get { return company.CompanyBillingName; } }

        public Invoice()
        {
            company = new Company();
        }

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
                invoices = ReadInvoices(reader);
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
                invoices = ReadInvoices(reader);
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
                invoices = ReadInvoices(reader);
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

        private static IList<Invoice> ReadInvoices(SqlDataReader reader)
        {
            IList<Invoice> invoices = new List<Invoice>();
            while (reader.Read())
            {
                invoices.Add(ReadInvoice(reader));
            }
            return invoices;
        }

        public static Invoice ReadInvoice(SqlDataReader reader)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceID = (int)reader["InvoiceID"];
            invoice.InvoiceDate = (DateTime)reader["InvoiceDate"];
            invoice.company = Company.ReadCompany(reader);
            return invoice;
        }


        private static void AddParameters(Invoice invoice, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CompanyID", invoice.CompanyID);
            comm.Parameters.AddWithValue("Date", invoice.InvoiceDate);
        }

        private static void AddOldParameters(Invoice invoice, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldInvoiceID", invoice.InvoiceID);
            comm.Parameters.AddWithValue("OldCompanyID", invoice.CompanyID);
            comm.Parameters.AddWithValue("OldDate", invoice.InvoiceDate);
        }
    }
}
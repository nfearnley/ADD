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
        public int CompanyID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }

        public Invoice()
        {}

        public Invoice(int companyID, DateTime date)
        { 
            CompanyID = companyID;
            Date = date;
        }

        public static Invoice GenerateInvoice(int companyID)
        {
            Invoice invoice = new Invoice(companyID, DateTime.Now);
            AddInvoice(invoice);
            List<Invoice> companyInvoices = GetInvoicesByCompanyID(companyID) as List<Invoice>;
            foreach (Invoice inv in companyInvoices)
            {
                if (inv.Date == invoice.Date && inv.CompanyID == invoice.CompanyID)
                {
                    invoice = inv;
                    break;
                }
            }
            List<ClientSession> cs = ClientSession.GetUnpaidClientSessions(companyID) as List<ClientSession>;
            foreach (ClientSession cSession in cs)
            { 
                InvoiceItem.AddInvoiceItem(new InvoiceItem(cSession.ClientSessionID,invoice.InvoiceID));
            }
            return invoice;
        }

        public static Invoice GetInvoice(int invoiceID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoice", conn);
            comm.Parameters.AddWithValue("SessionID", invoiceID);
            Invoice invoice = new Invoice();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    invoice.CompanyID = (int)reader["CompanyID"];
                    invoice.Date = (DateTime)reader["Date"];
                    invoice.InvoiceID = (int)reader["InvoiceID"];
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
            return invoice;
        }

        public static IEnumerable<Invoice> GetInvoicesByCompanyID(int companyID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoice", conn);
            comm.Parameters.AddWithValue("CompanyID", companyID);
            List<Invoice> invoices = new List<Invoice>();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.CompanyID = (int)reader["CompanyID"];
                    invoice.Date = (DateTime)reader["Date"];
                    invoice.InvoiceID = (int)reader["InvoiceID"];
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
            return invoices;
        }

        public static List<Invoice> GetInvoices()
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoice", conn);
            List<Invoice> invoices = new List<Invoice>();

            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.CompanyID = (int)reader["CompanyID"];
                    invoice.Date = (DateTime)reader["Date"];
                    invoice.InvoiceID = (int)reader["InvoiceID"];
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
            return invoices;
        }

        public static int AddInvoice(Invoice invoice)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoice", conn);
            comm.Parameters.AddWithValue("CompanyID", invoice.CompanyID);
            comm.Parameters.AddWithValue("Date", invoice.Date);
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

        public static int UpdateInvoice(Invoice invoice)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoice", conn);
            comm.Parameters.AddWithValue("InvoiceID", invoice.InvoiceID);
            comm.Parameters.AddWithValue("CompanyID", invoice.CompanyID);
            comm.Parameters.AddWithValue("Date", invoice.Date);
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

        public static int RemoveInvoice(int invoiceID)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoice", conn);
            comm.Parameters.AddWithValue("InvoiceID", invoiceID);
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
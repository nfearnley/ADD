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
        private int ClientSessionID;
        private int InvoiceID;

        public InvoiceItem()
        { }

        public InvoiceItem(int clientSessionID,int invoiceID)
        {
            ClientSessionID = clientSessionID;
            InvoiceID = invoiceID;
        }

        public static IEnumerable<InvoiceItem> GetInvoiceItemsByInvoice(int invoiceID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoiceItemsByInvoice", conn);
            comm.Parameters.AddWithValue("InvoiceID", invoiceID);
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                { 
                    InvoiceItem invoiceItem = new InvoiceItem();
                    invoiceItem.ClientSessionID = (int)reader["ClientSessionID"];
                    invoiceItem.InvoiceID = (int)reader["InvoiceID"];
                    invoiceItems.Add(invoiceItem);
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
            return invoiceItems;
        }

        public static List<InvoiceItem> GetInvoiceItemsByClientSessionID(int clientSessionID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoiceItemsBySessionID", conn);
            comm.Parameters.AddWithValue("ClientSessionID", clientSessionID);
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceItem invoiceItem = new InvoiceItem();
                    invoiceItem.ClientSessionID = (int)reader["ClientSessionID"];
                    invoiceItem.InvoiceID = (int)reader["InvoiceID"];
                    invoiceItems.Add(invoiceItem);
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
            return invoiceItems;
        }

        public static List<InvoiceItem> GetInvoiceItems()
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInvoiceItems", conn);
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceItem invoiceItem = new InvoiceItem();
                    invoiceItem.ClientSessionID = (int)reader["ClientSessionID"];
                    invoiceItem.InvoiceID = (int)reader["InvoiceID"];
                    invoiceItems.Add(invoiceItem);
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
            return invoiceItems;
        }

        public static int AddInvoiceItem(InvoiceItem invoiceItem)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddInvoiceItem", conn);
            comm.Parameters.AddWithValue("ClientSessionID", invoiceItem.ClientSessionID);
            comm.Parameters.AddWithValue("InvoiceID", invoiceItem.InvoiceID);
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

        public static int RemoveInvoiceItem(InvoiceItem invoiceItem)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveInvoiceItem", conn);
            comm.Parameters.AddWithValue("ClientSessionID", invoiceItem.ClientSessionID);
            comm.Parameters.AddWithValue("InvoiceID", invoiceItem.InvoiceID);
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

        public static int RemoveInvoiceItem(int invoiceID, int clientSessionID)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveInvoiceItem", conn);
            comm.Parameters.AddWithValue("ClientSessionID", clientSessionID);
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
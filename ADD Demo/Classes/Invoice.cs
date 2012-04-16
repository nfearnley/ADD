using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Invoice
    {
        private int CompanyID;
        private int InvoiceID;
        private DateTime Date;

        public Invoice()
        {}

        public Invoice(int companyID, DateTime date)
        { 
            CompanyID = companyID;
            Date = date;
        }

        public static Invoice GenerateInvoice(int companyID)
        {
            return new Invoice();
        }

        public static Invoice GetInvoice(int invoiceID)
        {
            return new Invoice();
        }

        public static List<Invoice> GetInvoicesByCompanyID(int companyID)
        {
            return new List<Invoice>();
        }

        public static List<Invoice> GetInvoices()
        {
            return new List<Invoice>();
        }

        public static int AddInvoice(Invoice invoice)
        {
            return 0;
        }

        public static int UpdateInvoice(Invoice invoice)
        {
            return 0;
        }

        public static int RemoveInvoice(int invoiceID)
        {
            return 0;
        }
    }
}
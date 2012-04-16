using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public static List<InvoiceItem> GetInvoiceItemsByInvoice(int invoiceID)
        {
            return new List<InvoiceItem>();
        }

        public static List<InvoiceItem> GetInvoiceItemsByClientSessionID(int clientSessionID)
        {
            return new List<InvoiceItem>();
        }

        public static List<InvoiceItem> GetInvoiceItems()
        {
            return new List<InvoiceItem>();
        }

        public static int AddInvoiceItem(InvoiceItem invoiceItem)
        {
            return 0;
        }

        public static int RemoveInvoiceItem(InvoiceItem invoiceItem)
        {
            return 0;
        }

        public static int RemoveInvoiceItem(int invoiceID, int clientSessionID)
        {
            return 0;
        }
    }
}
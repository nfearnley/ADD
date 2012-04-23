using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADD_Demo.Classes;

namespace ADD_Demo
{
    public partial class Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String courseID = Request.Params.Get("CompanyID");
                ddlCompanies.DataBind();
                ddlCompanies.SelectedValue = courseID;
            }
        }

        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            string invoiceID = Invoice.GenerateInvoice(int.Parse(ddlCompanies.SelectedValue)).ToString();
            InvoicesGridView.DataBind();
            for (int x = 0; x < InvoicesGridView.DataKeys.Count; x++)
            {
                string selectedInvoiceID = InvoicesGridView.DataKeys[x].Value.ToString();
                if (selectedInvoiceID == invoiceID)
                {
                    InvoicesGridView.SelectedIndex = x;
                    break;
                }
            }
        }

    }
}
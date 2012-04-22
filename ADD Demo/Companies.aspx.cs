using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            
        }

    }
}
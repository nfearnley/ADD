using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADD_Demo.Classes;
using System.Data;
using System.Data.SqlClient;

namespace ADD_Demo
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlClientSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int clientID = int.Parse(ddlClientSearch.SelectedValue);
            Client client = (Client.GetClient(clientID)).ElementAt(0);
            IEnumerable<ClientSession> clientSessions = (ClientSession.GetClientSessionsByClientID(clientID));

            using (DatabaseConnection db = new DatabaseConnection("dbo.GetCompany"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CompanyID", client.CompanyID);

                // Open Connection
                db.conn.Open();

                // Execute Command               
                SqlDataAdapter MyAdapter = new SqlDataAdapter();
                MyAdapter.SelectCommand = db.comm;
                DataTable table = new DataTable("companyInfo");

                // Read Response
                MyAdapter.Fill(table);
                modTable(table);
                dvClientCompany.DataSource = table.DefaultView;
                
                dvClientCompany.DataBind();
                dvClientCompany.Fields[0].Visible = false;
                db.Dispose();
            }
            DataTable sessionsTable = new DataTable("AllSessions");
            foreach(ClientSession sesh in clientSessions)
            {
                using (DatabaseConnection db = new DatabaseConnection("dbo.GetSession"))
                {
                    // Set Parameters
                    db.comm.Parameters.AddWithValue("SessionID", sesh.SessionID);

                    // Open Connection
                    db.conn.Open();

                    // Execute Command               
                    SqlDataAdapter MyAdapter = new SqlDataAdapter();
                    MyAdapter.SelectCommand = db.comm;
                    DataTable table = new DataTable("sessionInfo");

                    // Read Response
                    MyAdapter.Fill(table);
                    sessionsTable.Merge(table);                    
                    //gvClientSessions.Fields[0].Visible = false;
                    db.Dispose();
                }
            }
            gvClientSessions.DataSource = sessionsTable.DefaultView;
            gvClientSessions.DataBind();
            
        }

        private void modTable(DataTable oldTable)
        {
            DataColumnCollection dCC = oldTable.Columns;
            dCC.Remove("BillingAddressCity");
            dCC.Remove("BillingAddressCountry");
            dCC.Remove("BillingAddressLine1");
            dCC.Remove("BillingAddressLine2");
            dCC.Remove("BillingAddressPostalCode");
            dCC.Remove("BillingAddressRegion");
        }

        protected void dvClientDetails_ModeChanged(object sender, EventArgs e)
        {
            if (dvClientDetails.CurrentMode == DetailsViewMode.Insert || dvClientDetails.CurrentMode == DetailsViewMode.Edit)
                dvClientDetails.Fields[11].Visible = true;
            else
                dvClientDetails.Fields[11].Visible = false;
        }
    }
}
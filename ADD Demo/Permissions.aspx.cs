using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADD_Demo.Classes;

namespace ADD_Demo
{
    public partial class Permissions : System.Web.UI.Page
    {
        private Permission permissions;

        protected void Page_Load(object sender, EventArgs e)
        {
            permissions = new Permission(User);
            UserAccess.Text = "UserAccess: " + permissions.UserAccess.ToString();
            Add.Text = "Add: " + permissions.Add.ToString();
            Edit.Text = "Edit: " + permissions.Edit.ToString();
            Delete.Text = "Delete: " + permissions.Delete.ToString();
            Display.Text = "Display: " + permissions.Display.ToString();
            Report.Text = "Report: " + permissions.Report.ToString();
        }
    }
}
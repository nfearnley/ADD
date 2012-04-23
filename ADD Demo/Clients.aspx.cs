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
            if (!IsPostBack)
            {
                String courseID = Request.Params.Get("ClientID");
                ddlClientSearch.DataBind();
                ddlClientSearch.SelectedValue = courseID;
            }
        }

        protected void dvClientDetails_ModeChanged(object sender, EventArgs e)
        {
            if (dvClientDetails.CurrentMode == DetailsViewMode.Insert || dvClientDetails.CurrentMode == DetailsViewMode.Edit)
                dvClientDetails.Fields[11].Visible = true;
            else
                dvClientDetails.Fields[11].Visible = false;
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            if (ddlCourses.SelectedValue != "-1" && ddlSessionsByCourse.SelectedValue != "-1")
            {
                ClientSession clientSession = new ClientSession();

                clientSession.client = Client.GetClient(int.Parse(ddlClientSearch.SelectedValue)).ElementAt(0);
                clientSession.session = Classes.Session.GetSession(int.Parse(ddlSessionsByCourse.SelectedValue)).ElementAt(0);
                clientSession.ClientSessionPrice = decimal.Parse(tbPrice.Text);
                clientSession.ClientSessionPaid = cbPaid.Checked;
                clientSession.status = Status.GetStatus(1).ElementAt(0);

                ClientSession.AddClientSession(clientSession);
            }
            else
            {
                lblStatusText.Text = "You must select a Course and a Session to Enroll";
            }

        }

        protected void ddlSessionsByCourse_DataBound(object sender, EventArgs e)
        {
            addListItem(ddlSessionsByCourse);
        }

        protected void ddlCourses_DataBound(object sender, EventArgs e)
        {
            addListItem(ddlCourses);
        }

        protected void ddlClientSearch_DataBound(object sender, EventArgs e)
        {
            addListItem(ddlClientSearch);
        }

        protected void addListItem(DropDownList list)
        {
            ListItem item = new ListItem("Please Select: ", "-1");
            list.Items.Insert(0, item);
            list.SelectedIndex = 0;
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean enabled = (ddlCourses.SelectedValue != "-1");
            ddlSessionsByCourse.Enabled = enabled;
            cbPaid.Enabled = enabled;

            if (enabled)
            {
                IEnumerable<Course> courses = (IEnumerable<Course>)ODSGetCourse.Select();

                foreach (Course course in courses)
                {
                    tbPrice.Text = course.CoursePrice.ToString();
                }
            }
            else
            {
                tbPrice.Text = "";
            }
        }

        protected void ddlSessionsByCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEnroll.Enabled = ddlSessionsByCourse.SelectedValue != "-1";
        }
    }
}
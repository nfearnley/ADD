using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADD_Demo.Classes;

namespace ADD_Demo
{
    public partial class Instructors : System.Web.UI.Page
    {
        protected void InstructorDetailsDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            int instructorID = (int)e.ReturnValue;
            InstructorList.DataBind();
            InstructorList.SelectedValue = instructorID.ToString();
        }

        protected void InstructorDetailsDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows != 0)
            {
                InstructorList.DataBind();
            }
        }

        protected void InstructorList_DataBound(object sender, EventArgs e)
        {
            ListItem item = new ListItem("Please Select: ", "-1");
            InstructorList.Items.Insert(0, item);
            InstructorList.SelectedIndex = 0;
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            InstructorDetails.ChangeMode(DetailsViewMode.Insert);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String instructorID = Request.Params.Get("InstructorID");
                InstructorList.DataBind();
                InstructorList.SelectedValue = instructorID;
            }
        }

        protected void AddQualificationButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void InstructorQualificationsDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            InstructorQualification instructorQualification = new InstructorQualification();
            instructorQualification.InstructorID = int.Parse(InstructorList.SelectedValue);
            instructorQualification.CourseID = int.Parse(UnqualifiedQualificationList.SelectedValue);
            e.InputParameters["instructorQualifications"] = instructorQualification;
        }

    }
}
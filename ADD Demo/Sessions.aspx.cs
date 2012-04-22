using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADD_Demo
{
    public partial class Sessions : System.Web.UI.Page
    {
        protected void InstructorDetailsDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            String instructorID = (String)e.ReturnValue;
            if (instructorID != "")
            {
                // InstructorList.DataBind();
                // InstructorList.SelectedValue = instructorID;
            }
        }

        protected void InstructorDetailsDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows != 0)
            {
                //InstructorList.DataBind();
            }
        }

        protected void InstructorList_DataBound(object sender, EventArgs e)
        {
            ListItem item = new ListItem("Please Select: ", "-1");
            //InstructorList.Items.Insert(0, item);
            //InstructorList.SelectedIndex = 0;
        }
    }
}
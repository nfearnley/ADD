using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADD_Demo.Classes;
namespace ADD_Demo
{
    public partial class Sessions : System.Web.UI.Page
    {
        Classes.Session session;
        bool EditMode = false;
        protected void Page_Load(object sender, EventArgs e)
        {
                // InstructorList.DataBind();
                // InstructorList.SelectedValue = instructorID;
            session = Classes.Session.GetSession(int.Parse(ddlSessions.SelectedValue)).ElementAt(0);
            tbCourseCode.Text = Course.GetCourse(session.CourseID).ElementAt(0).CourseCode;
            tbInstructor.Text = Instructor.GetInstructor(session.InstructorID).ElementAt(0).FullName;
            tbRoomName.Text = Room.GetRoom(session.RoomID).ElementAt(0).RoomName;
            tbLength.Text = session.Length.ToString();
            tbDate.Text = session.Date.ToShortDateString();
            calDate.SelectedDate = session.Date;

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EditMode = !EditMode;
            tbCourseCode.Visible = !tbCourseCode.Visible;
            calDate.Visible = !calDate.Visible;
            tbInstructor.Visible = !tbInstructor.Visible;
            tbLength.ReadOnly = !tbLength.ReadOnly;
            tbRoomName.Visible = !tbRoomName.Visible;
            btnDelete.Enabled = !btnDelete.Enabled;
            ddlCourseCode.Visible=!ddlCourseCode.Visible;
            ddlInstructor.Visible = !ddlInstructor.Visible;
            ddlRoomName.Visible = !ddlRoomName.Visible;
            ddlSessions.Visible = !ddlSessions.Visible;
            if (EditMode)
            {                
                //InstructorList.DataBind();
            }
            else 
            {
                btnEdit.Text = "Edit";
            //InstructorList.Items.Insert(0, item);
            //InstructorList.SelectedIndex = 0;
                newSession.Date = calDate.SelectedDate;
                newSession.InstructorID = int.Parse(ddlCourseCode.SelectedValue);
                newSession.Length = int.Parse(tbLength.Text);
                newSession.RoomID = int.Parse(ddlRoomName.SelectedValue);
                newSession.SessionID = session.SessionID;
                Classes.Session.UpdateSession(newSession, session);
                Response.Redirect("~/Sessions.aspx?SessionID=" + newSession.SessionID);
            }
        }
    }
}
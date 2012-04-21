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
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseID = int.Parse(ddlCourses.SelectedValue);
            Course course = (Course.GetCourse(courseID)).ElementAt(0);
            IEnumerable<Session> sessions = Classes.Session.GetSessionsByCourseID(courseID);
            //IEnumerable<ClientSession> clientSessions = (ClientSession.GetClientSessionsByClientID(clientID));
            DataTable sessionsTable = new DataTable("SessionsTable");
            foreach (Session sesh in sessions)
            {
                using (DatabaseConnection db = new DatabaseConnection("dbo.GetInstructor"))
                {
                    // Set Parameters
                    db.comm.Parameters.AddWithValue("InstructorID", sesh.InstructorID);

                    // Open Connection
                    db.conn.Open();

                    // Execute Command               
                    SqlDataAdapter MyAdapter = new SqlDataAdapter();
                    MyAdapter.SelectCommand = db.comm;
                    DataTable table = new DataTable();

                    // Read Response
                    MyAdapter.Fill(table);
                    modInstructorTable(table);
                    sessionsTable.Merge(table);
                    db.Dispose();
                }
                using (DatabaseConnection db = new DatabaseConnection("dbo.GetRoom"))
                {
                    // Set Parameters
                    db.comm.Parameters.AddWithValue("RoomID", sesh.RoomID);

                    // Open Connection
                    db.conn.Open();

                    // Execute Command               
                    SqlDataAdapter MyAdapter = new SqlDataAdapter();
                    MyAdapter.SelectCommand = db.comm;
                    DataTable table = new DataTable();

                    // Read Response
                    MyAdapter.Fill(table);
                    modRoomTable(table);
                    sessionsTable.Merge(table);
                    db.Dispose();
                }
            }
            gvSessions.DataSource = sessionsTable.DefaultView;
            gvSessions.DataBind();
        }
        private void modRoomTable(DataTable oldTable)
        {
            DataColumnCollection dcc = oldTable.Columns;
            dcc.Remove("Seats");
        }
        private void modInstructorTable(DataTable oldTable)
        {
            DataColumnCollection dcc = oldTable.Columns;
            dcc.Remove("InstructorID");
            dcc.Remove("AddressCity");
            dcc.Remove("AddressCountry");
            dcc.Remove("AddressLine1");
            dcc.Remove("AddressLine2");
            dcc.Remove("AddressPostalCode");
            dcc.Remove("AddressRegion");
            dcc.Remove("AddressAltPhone");
            dcc.Remove("AddressHomePhone");
            //dcc["FirstName"] + dcc["LastName"].ToString()
        }

    }
}
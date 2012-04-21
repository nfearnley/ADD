using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Session
    {
        public int CourseID { get; set; }
        public int SessionID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public int RoomID { get; set; }
        public DateTime DateTime { get; set; }
        public int Length { get; set; }

        public Session()
        { }

        public static IEnumerable<Session> GetSession(int sessionID)
        {
            IEnumerable<Session> sessions = new List<Session>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetSession"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("SessionID", sessionID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                sessions = Read(reader);
            }

            return sessions;
        }

        public static IEnumerable<Session> GetSessionsByInstructorID(int instructorID)
        {
            IEnumerable<Session> sessions = new List<Session>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetSessionsByInstructorID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("InstructorID", instructorID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                sessions = Read(reader);
            }

            return sessions;
        }

        public static IEnumerable<Session> GetSessionsByRoomID(int roomID)
        {
            IEnumerable<Session> sessions = new List<Session>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetSessionsByRoomID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("RoomID", roomID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                sessions = Read(reader);
            }

            return sessions;
        }

        public static IEnumerable<Session> GetSessionsByCourseID(int courseID)
        {
            IEnumerable<Session> sessions = new List<Session>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetSessionsByCourseID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CourseID", courseID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                sessions = Read(reader);
            }

            return sessions;
        }

        public static IEnumerable<Session> GetSessions()
        {
            IEnumerable<Session> sessions = new List<Session>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetSessions"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                sessions = Read(reader);
            }

            return sessions;
        }

        public static int AddSession(Session session)
        {
            int sessionID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddSession"))
            {
                // Set Parameters
                AddParameters(session, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                sessionID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return sessionID;
        }

        public static int RemoveSession(Session oldSession)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveSession"))
            {
                // Set Parameters
                AddOldParameters(oldSession, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int UpdateSession(Session session, Session oldSession)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateSession"))
            {
                // Set Parameters
                AddParameters(session, db.comm);
                AddOldParameters(oldSession, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int CalculateNumberOfAvailableSeatsForSession(int sessionID)
        {
            int numOfAvailableSeats = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.CalculateNumberOfAvailableSeatsForSession"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("SessionID", sessionID);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                numOfAvailableSeats = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return numOfAvailableSeats;
        }

        public static IEnumerable<Session> GetSessionsWithinNext6WeeksByCourseID(int courseID)
        {
            IEnumerable<Session> sessions = new List<Session>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetSessionsWithinNext6WeeksByCourseID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CourseID", courseID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                sessions = Read(reader);
            }

            return sessions;
        }

        private static IList<Session> Read(SqlDataReader reader)
        {
            IList<Session> sessions = new List<Session>();
            while (reader.Read())
            {
                Session session = new Session();
                session.CourseID = (int)reader["CourseID"];
                session.SessionID = (int)reader["SessionID"];
                session.CourseID = (int)reader["CourseID"];
                session.InstructorID = (int)reader["InstructorID"];
                session.RoomID = (int)reader["RoomID"];
                session.DateTime = (DateTime)reader["DateTime"];
                session.Length = (int)reader["Length"];
                sessions.Add(session);
            }
            return sessions;
        }

        private static void AddParameters(Session session, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CourseID", session.CourseID);
            comm.Parameters.AddWithValue("InstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("CourseID", session.CourseID);
            comm.Parameters.AddWithValue("RoomID", session.RoomID);
            comm.Parameters.AddWithValue("DateTime", session.DateTime);
            comm.Parameters.AddWithValue("Length", session.Length);
        }

        private static void AddOldParameters(Session session, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCourseID", session.CourseID);
            comm.Parameters.AddWithValue("OldSessionID", session.SessionID);
            comm.Parameters.AddWithValue("OldCourseID", session.CourseID);
            comm.Parameters.AddWithValue("OldInstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("OldRoomID", session.RoomID);
            comm.Parameters.AddWithValue("OldDateTime", session.DateTime);
            comm.Parameters.AddWithValue("OldLength", session.Length);
        }
    }
}
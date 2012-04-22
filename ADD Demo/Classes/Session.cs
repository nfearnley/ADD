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
        public int SessionID { get; set; }
        public DateTime SessionDateTime { get; set; }
        public int SessionLength { get; set; }
        public int SessionEnrolled { get; set; }
        public int SessionAvailableSeats { get; set; }
        public Course course { get; set; }
        public int CourseID { get { return course.CourseID; } set { course.CourseID = value; } }
        public string CourseCode { get { return course.CourseCode; } }
        public string CourseDescription { get { return course.CourseDescription; } }
        public string CourseOutline { get { return course.CourseOutline; } }
        public decimal CoursePrice { get { return course.CoursePrice; } }
        public Instructor instructor { get; set; }
        public int InstructorID { get { return instructor.InstructorID; } set { instructor.InstructorID = value; } }
        public string InstructorAddressCity { get { return instructor.InstructorAddressCity; } }
        public string InstructorAddressCountry { get { return instructor.InstructorAddressCountry; } }
        public string InstructorAddressLine1 { get { return instructor.InstructorAddressLine1; } }
        public string InstructorAddressLine2 { get { return instructor.InstructorAddressLine2; } }
        public string InstructorAddressPostalCode { get { return instructor.InstructorAddressPostalCode; } }
        public string InstructorAddressRegion { get { return instructor.InstructorAddressRegion; } }
        public string InstructorAltPhone { get { return instructor.InstructorAltPhone; } }
        public string InstructorFirstName { get { return instructor.InstructorFirstName; } }
        public string InstructorHomePhone { get { return instructor.InstructorHomePhone; } }
        public string InstructorLastName { get { return instructor.InstructorLastName; } }
        public string InstructorFullName { get { return instructor.InstructorFullName; } }
        public Room room { get; set; }
        public int RoomID { get { return room.RoomID; } set { room.RoomID = value; } }
        public string RoomName { get { return room.RoomName; } }
        public int RoomSeats { get { return room.RoomSeats; } }

        public Session()
        {
            course = new Course();
            instructor = new Instructor();
            room = new Room();
        }

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
                sessions = ReadSessions(reader);
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
                sessions = ReadSessions(reader);
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
                sessions = ReadSessions(reader);
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
                sessions = ReadSessions(reader);
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
                sessions = ReadSessions(reader);
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
                sessions = ReadSessions(reader);
            }

            return sessions;
        }

        private static IList<Session> ReadSessions(SqlDataReader reader)
        {
            IList<Session> sessions = new List<Session>();
            while (reader.Read())
            {
                sessions.Add(ReadSession(reader));
            }
            return sessions;
        }

        public static Session ReadSession(SqlDataReader reader)
        {
            Session session = new Session();
            session.SessionID = (int)reader["SessionID"];
            session.SessionDateTime = (DateTime)reader["SessionDateTime"];
            session.SessionLength = (int)reader["SessionLength"];
            session.SessionEnrolled = (int)reader["SessionEnrolled"];
            session.SessionAvailableSeats = (int)reader["SessionAvailableSeats"];
            session.course = Course.ReadCourse(reader);
            session.instructor = Instructor.ReadInstructor(reader);
            session.room = Room.ReadRoom(reader);
            return session;
        }

        private static void AddParameters(Session session, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("InstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("CourseID", session.CourseID);
            comm.Parameters.AddWithValue("RoomID", session.RoomID);
            comm.Parameters.AddWithValue("DateTime", session.SessionDateTime);
            comm.Parameters.AddWithValue("Length", session.SessionLength);
        }

        private static void AddOldParameters(Session session, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldSessionID", session.SessionID);
            comm.Parameters.AddWithValue("OldCourseID", session.CourseID);
            comm.Parameters.AddWithValue("OldInstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("OldRoomID", session.RoomID);
            comm.Parameters.AddWithValue("OldDateTime", session.SessionDateTime);
            comm.Parameters.AddWithValue("OldLength", session.SessionLength);
        }
    }
}
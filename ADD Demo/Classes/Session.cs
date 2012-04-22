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
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public int RoomID { get; set; }
        public string CourseCode { get { return course.CourseCode; } set { course.CourseCode = value; } }
        public string CourseDescription { get { return course.Description; } set { course.Description = value; } }
        public string CourseOutline { get { return course.Outline; } set { course.Outline = value; } }
        public decimal CoursePrice { get { return course.Price; } set { course.Price = value; } }
        public string InstructorAddressCity { get { return instructor.AddressCity; } set { instructor.AddressCity = value;  } }
        public string InstructorAddressCountry { get { return instructor.AddressCountry; } set { instructor.AddressCountry = value; } }
        public string InstructorAddressLine1 { get { return instructor.AddressLine1; } set { instructor.AddressLine1 = value; } }
        public string InstructorAddressLine2 { get { return instructor.AddressLine2; } set { instructor.AddressLine2 = value; } }
        public string InstructorAddressPostalCode { get { return instructor.AddressPostalCode; } set { instructor.AddressPostalCode = value; } }
        public string InstructorAddressRegion { get { return instructor.AddressRegion; } set { instructor.AddressRegion = value; } }
        public string InstructorAltPhone { get { return instructor.AltPhone; } set { instructor.AltPhone = value; } }
        public string InstructorFirstName { get { return instructor.FirstName; } set { instructor.FirstName = value; } }
        public string InstructorHomePhone { get { return instructor.HomePhone; } set { instructor.HomePhone = value; } }
        public string InstructorLastName { get { return instructor.LastName; } set { instructor.LastName = value; } }
        public string InstructorFullName { get { return instructor.FullName; } }
        public string RoomName { get; set; }
        public int Seats { get; set; }
        public DateTime DateTime { get; set; }
        public int Length { get; set; }
        public int Enrolled { get; set; }
        public int AvailableSeats { get; set; }
        public Course course { get; set; }
        public Instructor instructor { get; set; }
        public Room room { get; set; }

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
                session.SessionID = (int)reader["SessionID"];
                session.CourseID = (int)reader["CourseID"];
                session.InstructorID = (int)reader["InstructorID"];
                session.RoomID = (int)reader["RoomID"];
                session.DateTime = (DateTime)reader["DateTime"];
                session.Length = (int)reader["Length"];
                session.Enrolled = (int)reader["Enrolled"];
                session.AvailableSeats = (int)reader["AvailableSeats"];
                session.course = Course.ReadCourse(reader);
                session.instructor = Instructor.ReadInstructor(reader);
                session.room = Room.ReadRoom(reader);
                sessions.Add(session);
            }
            return sessions;
        }

        private static void AddParameters(Session session, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("InstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("CourseID", session.CourseID);
            comm.Parameters.AddWithValue("RoomID", session.RoomID);
            comm.Parameters.AddWithValue("DateTime", session.DateTime);
            comm.Parameters.AddWithValue("Length", session.Length);
        }

        private static void AddOldParameters(Session session, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldSessionID", session.SessionID);
            comm.Parameters.AddWithValue("OldCourseID", session.CourseID);
            comm.Parameters.AddWithValue("OldInstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("OldRoomID", session.RoomID);
            comm.Parameters.AddWithValue("OldDateTime", session.DateTime);
            comm.Parameters.AddWithValue("OldLength", session.Length);
        }
    }
}
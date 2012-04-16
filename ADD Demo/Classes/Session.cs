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
        public int InstructorID { get; set; }
        public int RoomID { get; set; }
        public String Length { get; set; }
        public DateTime Date { get; set; }

        public Session()
        { }

        public Session(int instructorID, int roomID, String length, DateTime datetime)
        {
            InstructorID = instructorID;
            RoomID = roomID;
            Length = length;
            Date = datetime;
        }

        public static Session GetSession(int sessionID)
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetSession", conn);
            comm.Parameters.AddWithValue("SessionID", sessionID);
            Session session = new Session();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    session.Date = (DateTime)reader["DateTime"];
                    session.InstructorID = (int)reader["InstructorID"];
                    session.Length = reader["Length"] as String;
                    session.RoomID = (int)reader["RoomID"];
                    session.SessionID = (int)reader["SessionID"];
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return session;
        }

        public static IEnumerable<Session> GetSessionsByInstructorID(int instructorID)
        {

            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetSessionsByInstructorID", conn);
            comm.Parameters.AddWithValue("InstructorID", instructorID);
            List<Session> sessions = new List<Session>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Session session = new Session();
                    session.Date = (DateTime)reader["DateTime"];
                    session.InstructorID = (int)reader["InstructorID"];
                    session.Length = reader["Length"] as String;
                    session.RoomID = (int)reader["RoomID"];
                    session.SessionID = (int)reader["SessionID"];
                    sessions.Add(session);
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return sessions;
        }

        public static IEnumerable<Session> GetSessionsByRoomID(int roomID)
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetSessionsByRoomID", conn);
            comm.Parameters.AddWithValue("RoomID", roomID);
            List<Session> sessions = new List<Session>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Session session = new Session();
                    session.Date = (DateTime)reader["DateTime"];
                    session.InstructorID = (int)reader["InstructorID"];
                    session.Length = reader["Length"] as String;
                    session.RoomID = (int)reader["RoomID"];
                    session.SessionID = (int)reader["SessionID"];
                    sessions.Add(session);
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return sessions;
        }

        public static List<Session> GetSessionsByCourseID(int courseID)
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetSessionsByCourseID", conn);
            comm.Parameters.AddWithValue("CourseID", courseID);
            List<Session> sessions = new List<Session>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Session session = new Session();
                    session.Date = (DateTime)reader["DateTime"];
                    session.InstructorID = (int)reader["InstructorID"];
                    session.Length = reader["Length"] as String;
                    session.RoomID = (int)reader["RoomID"];
                    session.SessionID = (int)reader["SessionID"];
                    sessions.Add(session);
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return sessions;
        }

        public static List<Session> GetSessions()
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetSessions", conn);
            List<Session> sessions = new List<Session>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Session session = new Session();
                    session.Date = (DateTime)reader["DateTime"];
                    session.InstructorID = (int)reader["InstructorID"];
                    session.Length = reader["Length"] as String;
                    session.RoomID = (int)reader["RoomID"];
                    session.SessionID = (int)reader["SessionID"];
                    sessions.Add(session);
                }
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return sessions;
        }

        public static int AddSession(Session session)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddSession", conn);
            comm.Parameters.AddWithValue("SessionID", session.SessionID);
            comm.Parameters.AddWithValue("RoomID", session.RoomID);
            comm.Parameters.AddWithValue("Length", session.Length);
            comm.Parameters.AddWithValue("InstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("DateTime", session.Date);
            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                result = comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return result;
        }

        public static int RemoveSession(int sessionID)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveSession", conn);
            comm.Parameters.AddWithValue("SessionID", sessionID);
            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                result = comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return result;
        }

        public static int UpdateSession(Session session)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.UpdateSession", conn);
            comm.Parameters.AddWithValue("SessionID", session.SessionID);
            comm.Parameters.AddWithValue("RoomID", session.RoomID);
            comm.Parameters.AddWithValue("Length", session.Length);
            comm.Parameters.AddWithValue("InstructorID", session.InstructorID);
            comm.Parameters.AddWithValue("DateTime", session.Date);
            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                result = comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                // Dispose of Command
                comm.Dispose();

                // Dispose of Connection
                conn.Dispose();
            }
            return result;
        }
    }
}
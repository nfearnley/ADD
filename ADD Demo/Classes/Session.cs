using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Session
    {
        private int SessionID;
        private int InstructorID;
        private int RoomID;
        private String Length;
        private DateTime dateTime;

        public Session()
        { }

        public Session(int instructorID, int roomID, String length, DateTime datetime)
        {
            InstructorID = instructorID;
            RoomID = roomID;
            Length = length;
            dateTime = datetime;
        }

        public static Session GetSession(int sessionID)
        {
            return new Session();
        }

        public static List<Session> GetSessionsByInstructorID(int instructorID)
        {
            return new List<Session>();
        }

        public static List<Session> GetSessionsByRoomID(int roomID)
        {
            return new List<Session>();
        }

        public static List<Session> GetSessionsByCourseID(int courseID)
        {
            return new List<Session>();
        }

        public static List<Session> GetSessions()
        {
            return new List<Session>();
        }

        public static void AddSession(Session session)
        { 
            
        }

        public static bool RemoveSession(int sessionID)
        {
            return false;
        }

        public static bool UpdateSession(Session session)
        {
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int Seats { get; set; }

        public Room()
        { }

        public static IEnumerable<Room> GetRoom(int roomID)
        {
            IEnumerable<Room> rooms = new List<Room>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetRoom"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("RoomID", roomID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                rooms = Read(reader);
            }

            return rooms;
        }

        public static IEnumerable<Room> GetRooms()
        {
            IEnumerable<Room> rooms = new List<Room>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetRooms"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                rooms = Read(reader);
            }

            return rooms;
        }

        public static int AddRoom(Room room)
        {
            int roomID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddRoom"))
            {
                // Set Parameters
                AddParameters(room, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                roomID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return roomID;
        }

        public static int RemoveRoom(Room oldRoom)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveRoom"))
            {
                // Set Parameters
                AddOldParameters(oldRoom, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int UpdateRoom(Room room, Room oldRoom)
        {
            int rowsAffected = 0;

            // Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.UpdateRoom");
            {
                // Set Parameters
                AddParameters(room, db.comm);
                AddOldParameters(oldRoom, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<Room> Read(SqlDataReader reader)
        {
            IList<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                Room room = new Room();
                room.RoomID = (int)reader["RoomID"];
                room.RoomName = (string)reader["RoomName"];
                room.Seats = (int)reader["Seats"];
                rooms.Add(room);
            }
            return rooms;
        }

        private static void AddParameters(Room room, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("RoomName", room.RoomName);
            comm.Parameters.AddWithValue("Seats", room.Seats);
        }

        private static void AddOldParameters(Room room, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldRoomID", room.RoomID);
            comm.Parameters.AddWithValue("OldRoomName", room.RoomName);
            comm.Parameters.AddWithValue("OldSeats", room.Seats);
        }
    }
}
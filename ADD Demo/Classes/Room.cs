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

        public static Room GetRoom(int roomID)
        {
            Room room = new Room();

            //Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetRoom");
            db.comm.Parameters.AddWithValue("RoomID", roomID);
            try
            {
                db.conn.Open();
                SqlDataReader reader = db.comm.ExecuteReader();
                IList<Room> rooms = Read(reader);
                room = rooms[0];
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return room;
        }

        public static IEnumerable<Room> GetRooms()
        {
            IEnumerable<Room> rooms = new List<Room>();

            //Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetRooms");

            try
            {
                db.conn.Open();
                SqlDataReader reader = db.comm.ExecuteReader();
                rooms = Read(reader);
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return rooms;
        }

        public static int AddRoom(Room room)
        {
            int roomID = -1;

            //Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.AddRoom");
            AddParameters(room, db.comm);

            try
            {
                db.conn.Open();
                roomID = Convert.ToInt32(db.comm.ExecuteScalar());
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return roomID;
        }

        public static int RemoveRoom(Room oldRoom)
        {
            int rowsAffected = 0;

            //Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.RemoveRoom");
            AddOldParameters(oldRoom, db.comm);

            try
            {
                db.conn.Open();
                rowsAffected = db.comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return rowsAffected;
        }

        public static int UpdateRoom(Room room, Room oldRoom)
        {
            int rowsAffected = 0;

            //Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.UpdateRoom");
            AddParameters(room, db.comm);
            AddOldParameters(oldRoom, db.comm);

            try
            {
                db.conn.Open();
                rowsAffected = db.comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
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
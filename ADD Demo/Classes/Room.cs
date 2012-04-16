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
        public int Seats { get; set; }
        public String RoomName { get; set; }

        public Room()
        { }

        public Room(int seats, String roomName)
        {
            Seats = seats;
            RoomName = roomName;
        }

        public static Room GetRoom(int roomID)
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetRoom", conn);
            comm.Parameters.AddWithValue("RoomID", roomID);
            Room room = new Room();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    room.RoomID = (int)reader["RoomID"];
                    room.RoomName = reader["RoomName"] as String;
                    room.Seats = (int)reader["Seats"];
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
            return room;
        }

        public static IEnumerable<Room> GetRooms()
        {
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetRooms", conn);
            List<Room> rooms = new List<Room>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Room room = new Room();
                    room.RoomID = (int)reader["RoomID"];
                    room.RoomName = reader["RoomName"] as String;
                    room.Seats = (int)reader["Seats"];
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
            return rooms;
        }

        public static int AddRoom(Room room)
        {
            int result = 0;
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddRoom", conn);
            comm.Parameters.AddWithValue("RoomID", room.RoomID);
            comm.Parameters.AddWithValue("RoomID", room.RoomID);
            comm.Parameters.AddWithValue("RoomID", room.RoomID);
            try
            {
                conn.Open();
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

        public static int RemoveRoom(int roomID)
        {
            int result = 0;
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveRoom", conn);
            comm.Parameters.AddWithValue("RoomID", roomID);
            try
            {
                conn.Open();
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

        public static int UpdateRoom(Room room)
        {
            int result = 0;
            //Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.UpdateRoom", conn);
            comm.Parameters.AddWithValue("RoomID", room.RoomID);
            comm.Parameters.AddWithValue("RoomID", room.RoomID);
            comm.Parameters.AddWithValue("RoomID", room.RoomID);
            try
            {
                conn.Open();
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
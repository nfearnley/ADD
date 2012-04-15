using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Room
    {
        private int RoomID;
        private int Seats;
        private String RoomName;

        public Room()
        { }

        public Room(int seats, String roomName)
        {
            Seats = seats;
            RoomName = roomName;
        }

        public static Room GetRoom(int roomID)
        {
            return new Room();
        }

        public static List<Room> GetRooms()
        {
            return new List<Room>();
        }

        public static void AddRoom(Room room)
        { 
            
        }

        public static bool RemoveRoom(int roomID)
        {
            return false;
        }

        public static bool UpdateRoom(Room room)
        {
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Status
    {
        private int StatusID;
        private String StatusName;

        public Status()
        { }

        public Status(String statusName)
        {
            StatusName = statusName;
        }

        public static Status GetStatus(int statusID)
        {
            return new Status();
        }

        public static List<Status> GetStatuses()
        {
            return new List<Status>();
        }

        public static void AddStatus(Status status)
        { 
            
        }

        public static bool RemoveStatus(int statusID)
        {
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class ClientSession
    {
        private int ClientSessionID;
        private int SessionID;
        private int StatusID;
        private int ClientID;
        private bool Paid;
        private float Price;

        public ClientSession()
        { }

        public ClientSession(int sessionID, int statusID, int clientID, bool paid, float price)
        { 
            SessionID = sessionID;
            StatusID = statusID;
            ClientID = clientID;
            Paid = paid;
            Price = price;
        }

        public static List<ClientSession> GetUnpaidClientSessions(int CompanyID)
        {
            return new List<ClientSession>();
        }

        public static ClientSession GetClientSession(int clientSessionID)
        {
            return new ClientSession();
        }

        public static List<ClientSession> GetClientSessionsByClientID(int clientID)
        {
            return new List<ClientSession>();
        }

        public static List<ClientSession> GetClientSessionsBySessionID(int sessionID)
        {
            return new List<ClientSession>();
        }

        public static List<ClientSession> GetClientSessionsByStatusID(int statusID)
        {
            return new List<ClientSession>();
        }

        public static void AddClientSession()
        { 
            
        }

        public static bool UpdateClientSession(ClientSession clientSession)
        {
            return false;
        }

        public static bool RemoveClientSession(int clientSessionID)
        {
            return false;
        }
    }
}
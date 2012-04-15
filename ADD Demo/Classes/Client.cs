using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Client
    {
        private int clientID;
        private String WorkPhone;
        private String LastName;
        private String HomePhone;
        private String FirstName;
        private String FaxPhone;
        private String AddressRegion;
        private String AddressPostalCode;
        private String AddressLine1;
        private String AddressLine2;
        private String AddressCountry;
        private String AddressCity;
        private int CompanyID;

        public Client()
        { }

        public Client(String wPhone, String lName, String hPhone, String fName, String fPhone, String region, String code, String line1, String line2, String country, String city, int companyID)
        { 
            WorkPhone = wPhone;
            LastName = lName;
            HomePhone = hPhone;
            FirstName = fName;
            FaxPhone = fPhone;
            AddressRegion = region;
            AddressPostalCode = code;
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressCountry = country;
            AddressCity = city;
            CompanyID = companyID;
        }

        public static Client GetClient(int clientID)
        {
            return new Client();
        }

        public static List<Client> GetClientsByCompanyID(int companyID)
        {
            return new List<Client>();
        }

        public static List<Client> GetClients()
        {
            return new List<Client>();
        }

        public static void AddClient(Client client)
        {
        
        }

        public static bool RemoveClient(int clientID)
        {
            return false;
        }

        public static bool UpdateClient(Client client)
        {
            return false;
        }
    }
}
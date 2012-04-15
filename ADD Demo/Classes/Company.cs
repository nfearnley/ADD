using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Company
    {
        private int CompanyID;
        private String BillingAddressCity;
        private String BillingAddressCountry;
        private String BillingAddressLine1;
        private String BillingAddressLine2;
        private String BillingAddressPostalCode;
        private String BillingAddressRegion;
        private String BillingName;

        public Company(String city, String country, String line1, String line2, String code, String region, String name)
        {
            BillingAddressCity = city;
            BillingAddressCountry = country;
            BillingAddressLine1 = line1;
            BillingAddressLine2 = line2;
            BillingAddressPostalCode = code;
            BillingAddressRegion = region;
            BillingName = name;
        }

        public Company()
        {
        
        }

        public static Company GetCompany(int companyID)
        {
            Company retCompany = new Company();
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlCommand cmd = new SqlCommand("GetCompany", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
            }
            catch 
            {
                conn.Close();
            }
            return new Company();
        }

        public static List<Company> GetCompanies(int companyID)
        {
            return new List<Company>();

        }

        public static void AddCompany(String city, String country, String line1, String line2, String code, String region, String name)
        {}

        public static Company RemoveCompany(int companyID)
        {
            return new Company();
        }

        public static bool UpdateCompany(String city, String country, String line1, String line2, String code, String region, String name)
        {
            return false;
        }
    }
}
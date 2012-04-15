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
        {}

        public static Company GetCompany(int companyID)
        {
            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            // Setup Command
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.GetCompany";
            comm.Parameters.AddWithValue("@CompanyID", companyID);
            comm.Connection = conn;
            Company company = new Company();
            try
            {
                // Open Connection
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if(reader.Read())
                {
                    company.BillingAddressCity = reader["BillingAddressCity"] as String;
                    company.BillingAddressCountry = reader["BillingAddressCountry"] as String;
                    company.BillingAddressPostalCode = reader["BillingAddressPostalCode"] as String;
                    company.BillingAddressLine1 = reader["BillingAddressLine1"] as String;
                    company.BillingAddressLine2 = reader["BillingAddressLine2"] as String;
                    company.BillingAddressRegion = reader["BillingAddressRegion"] as String;
                    company.BillingName = reader["BillingName"] as String;
                    company.CompanyID = (int)reader["CompanyID"];
                }                
            }
            catch 
            {
                conn.Close();
            }
            conn.Close();
            return company;
        }

        public static List<Company> GetCompanies(int companyID)
        {
            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            // Setup Command
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.GetCompanies";
            comm.Connection = conn;
            List<Company> companies = new List<Company>();
            try
            {
                // Open Connection
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    Company company = new Company();
                    company.BillingAddressCity = reader["BillingAddressCity"] as String;
                    company.BillingAddressCountry = reader["BillingAddressCountry"] as String;
                    company.BillingAddressPostalCode = reader["BillingAddressPostalCode"] as String;
                    company.BillingAddressLine1 = reader["BillingAddressLine1"] as String;
                    company.BillingAddressLine2 = reader["BillingAddressLine2"] as String;
                    company.BillingAddressRegion = reader["BillingAddressRegion"] as String;
                    company.BillingName = reader["BillingName"] as String;
                    company.CompanyID = (int)reader["CompanyID"];
                    companies.Add(company);
                }
            }
            catch
            {
                conn.Close();
            }
            conn.Close();
            return companies;
        }

        public static void AddCompany(Company company)
        {
            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            // Setup Command
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.AddCompany";
            comm.Parameters.AddWithValue("@BillingAddressCity", company.BillingAddressCity);
            comm.Parameters.AddWithValue("@BillingAddressCountry", company.BillingAddressCountry);
            comm.Parameters.AddWithValue("@BillingAddressLine1", company.BillingAddressLine1);
            comm.Parameters.AddWithValue("@BillingAddressLine2", company.BillingAddressLine2);
            comm.Parameters.AddWithValue("@BillingAddressPostalCode", company.BillingAddressPostalCode);
            comm.Parameters.AddWithValue("@BillingAddressRegion", company.BillingAddressRegion);
            comm.Parameters.AddWithValue("@BillingName", company.BillingName);
            comm.Connection = conn;
            List<Company> companies = new List<Company>();
            try
            {
                // Open Connection
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
            }
            conn.Close();
        }

        public static bool RemoveCompany(int companyID)
        {
            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            // Setup Command
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.RemoveCompany";
            comm.Parameters.AddWithValue("@CompanyID",companyID);
            try
            {
                // Open Connection
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }

        public static bool UpdateCompany(Company company)
        {
            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            // Setup Command
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.UpdateCompany";
            comm.Parameters.AddWithValue("@BillingAddressCity", company.BillingAddressCity);
            comm.Parameters.AddWithValue("@BillingAddressCountry", company.BillingAddressCountry);
            comm.Parameters.AddWithValue("@BillingAddressLine1", company.BillingAddressLine1);
            comm.Parameters.AddWithValue("@BillingAddressLine2", company.BillingAddressLine2);
            comm.Parameters.AddWithValue("@BillingAddressPostalCode", company.BillingAddressPostalCode);
            comm.Parameters.AddWithValue("@BillingAddressRegion", company.BillingAddressRegion);
            comm.Parameters.AddWithValue("@BillingName", company.BillingName);
            comm.Parameters.AddWithValue("@CompanyID", company.CompanyID);
            comm.Connection = conn;
            List<Company> companies = new List<Company>();
            try
            {
                // Open Connection
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }
    }
}
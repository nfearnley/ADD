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
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCompany", conn);
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
            return company;
        }

        public static List<Company> GetCompanies(int companyID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCompanies", conn);
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
            return companies;
        }

        public static void AddCompany(Company company)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddCompany", conn);
            comm.Parameters.AddWithValue("@BillingAddressCity", company.BillingAddressCity);
            comm.Parameters.AddWithValue("@BillingAddressCountry", company.BillingAddressCountry);
            comm.Parameters.AddWithValue("@BillingAddressLine1", company.BillingAddressLine1);
            comm.Parameters.AddWithValue("@BillingAddressLine2", company.BillingAddressLine2);
            comm.Parameters.AddWithValue("@BillingAddressPostalCode", company.BillingAddressPostalCode);
            comm.Parameters.AddWithValue("@BillingAddressRegion", company.BillingAddressRegion);
            comm.Parameters.AddWithValue("@BillingName", company.BillingName);
            try
            {
                // Open Connection
                conn.Open();
                comm.ExecuteNonQuery();
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
        }

        public static bool RemoveCompany(int companyID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveCompany", conn);
            comm.Parameters.AddWithValue("@CompanyID",companyID);
            try
            {
                // Open Connection
                conn.Open();
                comm.ExecuteNonQuery();
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
            return true;
        }

        public static bool UpdateCompany(Company company)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();

            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.UpdateCompany", conn);
            comm.Parameters.AddWithValue("@BillingAddressCity", company.BillingAddressCity);
            comm.Parameters.AddWithValue("@BillingAddressCountry", company.BillingAddressCountry);
            comm.Parameters.AddWithValue("@BillingAddressLine1", company.BillingAddressLine1);
            comm.Parameters.AddWithValue("@BillingAddressLine2", company.BillingAddressLine2);
            comm.Parameters.AddWithValue("@BillingAddressPostalCode", company.BillingAddressPostalCode);
            comm.Parameters.AddWithValue("@BillingAddressRegion", company.BillingAddressRegion);
            comm.Parameters.AddWithValue("@BillingName", company.BillingName);
            comm.Parameters.AddWithValue("@CompanyID", company.CompanyID);
            try
            {
                // Open Connection
                conn.Open();
                comm.ExecuteNonQuery();
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
            return true;
        }
    }
}
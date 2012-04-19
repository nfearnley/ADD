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
        public int CompanyID { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressCountry { get; set; }
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; } // can be null
        public string BillingAddressPostalCode { get; set; }
        public string BillingAddressRegion { get; set; }
        public string BillingName { get; set; }

        public Company()
        {}

        public static IEnumerable<Company> GetCompany(int companyID)
        {
            IEnumerable<Company> companies = new List<Company>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetCompany"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CompanyID", companyID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                companies = Read(reader);
            }

            return companies;
        }

        public static IEnumerable<Company> GetCompanies()
        {
            IEnumerable<Company> companies = new List<Company>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetCompanies"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                companies = Read(reader);
            }

            return companies;
        }

        public static int AddCompany(Company company)
        {
            int companyID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddCompany"))
            {
                // Set Parameters
                AddParameters(company, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                companyID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return companyID;
        }

        public static int RemoveCompany(Company oldCompany)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveCompany"))
            {
                // Set Parameters
                AddOldParameters(oldCompany, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int UpdateCompany(Company company, Company oldCompany)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateCompany"))
            {
                // Set Parameters
                AddParameters(company, db.comm);
                AddOldParameters(oldCompany, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<Company> Read(SqlDataReader reader)
        {
            IList<Company> companies = new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.CompanyID = (int)reader["CompanyID"];
                company.BillingAddressCity = (string)reader["BillingAddressCity"];
                company.BillingAddressCountry = (string)reader["BillingAddressCountry"];
                company.BillingAddressPostalCode = (string)reader["BillingAddressPostalCode"];
                company.BillingAddressLine1 = (string)reader["BillingAddressLine1"];
                company.BillingAddressLine2 = reader["BillingAddressLine2"] as string; // Allow null
                company.BillingAddressRegion = (string)reader["BillingAddressRegion"];
                company.BillingName = (string)reader["BillingName"];
                companies.Add(company);
            }
            return companies;
        }

        private static void AddParameters(Company company, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("BillingAddressCity", company.BillingAddressCity);
            comm.Parameters.AddWithValue("BillingAddressCountry", company.BillingAddressCountry);
            comm.Parameters.AddWithValue("BillingAddressLine1", company.BillingAddressLine1);
            comm.Parameters.AddWithValue("BillingAddressLine2", company.BillingAddressLine2 == null ? (object)DBNull.Value : company.BillingAddressLine2); // Check for null
            comm.Parameters.AddWithValue("BillingAddressPostalCode", company.BillingAddressPostalCode);
            comm.Parameters.AddWithValue("BillingAddressRegion", company.BillingAddressRegion);
            comm.Parameters.AddWithValue("BillingName", company.BillingName);
        }

        private static void AddOldParameters(Company company, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCompanyID", company.CompanyID);
            comm.Parameters.AddWithValue("OldBillingAddressCity", company.BillingAddressCity);
            comm.Parameters.AddWithValue("OldBillingAddressCountry", company.BillingAddressCountry);
            comm.Parameters.AddWithValue("OldBillingAddressLine1", company.BillingAddressLine1);
            comm.Parameters.AddWithValue("OldBillingAddressLine2", company.BillingAddressLine2 == null ? (object)DBNull.Value : company.BillingAddressLine2); // Check for null
            comm.Parameters.AddWithValue("OldBillingAddressPostalCode", company.BillingAddressPostalCode);
            comm.Parameters.AddWithValue("OldBillingAddressRegion", company.BillingAddressRegion);
            comm.Parameters.AddWithValue("OldBillingName", company.BillingName);
        }
    }
}
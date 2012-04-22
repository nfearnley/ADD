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
        public string CompanyBillingAddressCity { get; set; }
        public string CompanyBillingAddressCountry { get; set; }
        public string CompanyBillingAddressLine1 { get; set; }
        public string CompanyBillingAddressLine2 { get; set; } // can be null
        public string CompanyBillingAddressPostalCode { get; set; }
        public string CompanyBillingAddressRegion { get; set; }
        public string CompanyBillingName { get; set; }

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
                companies = ReadCompanies(reader);
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
                companies = ReadCompanies(reader);
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

        private static IList<Company> ReadCompanies(SqlDataReader reader)
        {
            IList<Company> companies = new List<Company>();
            while (reader.Read())
            {
                
                companies.Add(ReadCompany(reader));
            }
            return companies;
        }

        public static Company ReadCompany(SqlDataReader reader)
        {
            Company company = new Company();
            company.CompanyID = (int)reader["CompanyID"];
            company.CompanyBillingAddressCity = (string)reader["CompanyBillingAddressCity"];
            company.CompanyBillingAddressCountry = (string)reader["CompanyBillingAddressCountry"];
            company.CompanyBillingAddressPostalCode = (string)reader["CompanyBillingAddressPostalCode"];
            company.CompanyBillingAddressLine1 = (string)reader["CompanyBillingAddressLine1"];
            company.CompanyBillingAddressLine2 = reader["CompanyBillingAddressLine2"] as string; // Allow null
            company.CompanyBillingAddressRegion = (string)reader["CompanyBillingAddressRegion"];
            company.CompanyBillingName = (string)reader["CompanyBillingName"];
            return company;
        }

        private static void AddParameters(Company company, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("BillingAddressCity", company.CompanyBillingAddressCity);
            comm.Parameters.AddWithValue("BillingAddressCountry", company.CompanyBillingAddressCountry);
            comm.Parameters.AddWithValue("BillingAddressLine1", company.CompanyBillingAddressLine1);
            comm.Parameters.AddWithValue("BillingAddressLine2", company.CompanyBillingAddressLine2 == null ? (object)DBNull.Value : company.CompanyBillingAddressLine2); // Check for null
            comm.Parameters.AddWithValue("BillingAddressPostalCode", company.CompanyBillingAddressPostalCode);
            comm.Parameters.AddWithValue("BillingAddressRegion", company.CompanyBillingAddressRegion);
            comm.Parameters.AddWithValue("BillingName", company.CompanyBillingName);
        }

        private static void AddOldParameters(Company company, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCompanyID", company.CompanyID);
            comm.Parameters.AddWithValue("OldBillingAddressCity", company.CompanyBillingAddressCity);
            comm.Parameters.AddWithValue("OldBillingAddressCountry", company.CompanyBillingAddressCountry);
            comm.Parameters.AddWithValue("OldBillingAddressLine1", company.CompanyBillingAddressLine1);
            comm.Parameters.AddWithValue("OldBillingAddressLine2", company.CompanyBillingAddressLine2 == null ? (object)DBNull.Value : company.CompanyBillingAddressLine2); // Check for null
            comm.Parameters.AddWithValue("OldBillingAddressPostalCode", company.CompanyBillingAddressPostalCode);
            comm.Parameters.AddWithValue("OldBillingAddressRegion", company.CompanyBillingAddressRegion);
            comm.Parameters.AddWithValue("OldBillingName", company.CompanyBillingName);
        }
    }
}
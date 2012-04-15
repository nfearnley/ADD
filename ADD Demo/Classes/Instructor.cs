using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ADD_Demo.Classes
{
    public class Instructor
    {

        public int InstructorID { get; set; }
        public String AddressCity { get; set; }
        public String AddressCountry { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String AddressPostalCode { get; set; }
        public String AddressRegion { get; set; }
        public String AltPhone { get; set; }
        public String FirstName { get; set; }
        public String HomePhone { get; set; }
        public String LastName { get; set; }

        public Instructor()
        { }

        public static Instructor GetInstructor(int instructorID)
        {

            throw new NotSupportedException();
        }

        public static IEnumerable<Instructor> GetInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();

            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            // Setup Command
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.GetInstructors";
            comm.Connection = conn;

            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Instructor instructor = new Instructor();
                    instructor.InstructorID = (int)reader["InstructorID"];
                    instructor.AddressCity = reader["AddressCity"] as String;
                    instructor.AddressCountry = reader["AddressCity"] as String;
                    instructor.AddressLine1 = reader["AddressLine1"] as String;
                    instructor.AddressLine2 = reader["AddressLine2"] as String;
                    instructor.AddressPostalCode = reader["AddressPostalCode"] as String;
                    instructor.AddressRegion = reader["AddressRegion"] as String;
                    instructor.AltPhone = reader["AltPhone"] as String;
                    instructor.FirstName = reader["FirstName"] as String;
                    instructor.HomePhone = reader["HomePhone"] as String;
                    instructor.LastName = reader["LastName"] as String;
                    instructors.Add(instructor);
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

            return instructors;
            throw new NotSupportedException();
        }

        public static void AddInstructor(Instructor inst)
        {
            throw new NotSupportedException();
        }

        public static Instructor RemoveInstructor(int instructorID)
        {
            throw new NotSupportedException();
        }

        public static bool UpdateInstructor(Instructor inst)
        {
            throw new NotSupportedException();
        }
    }
}
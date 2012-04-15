using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ADD_Demo.Classes
{
    public class Instructor : DatabaseConnection
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
            Instructor instructor = new Instructor();

            // Get Connection
            SqlConnection conn = GetConnection();

            // Get Command
            SqlCommand comm = GetCommand("dbo.GetInstructor", conn);
            comm.Parameters.AddWithValue("InstructorID", instructorID);

            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    instructor.InstructorID = (int)reader["InstructorID"];
                    instructor.AddressCity = reader["AddressCity"] as String;
                    instructor.AddressCountry = reader["AddressCountry"] as String;
                    instructor.AddressLine1 = reader["AddressLine1"] as String;
                    instructor.AddressLine2 = reader["AddressLine2"] as String;
                    instructor.AddressPostalCode = reader["AddressPostalCode"] as String;
                    instructor.AddressRegion = reader["AddressRegion"] as String;
                    instructor.AltPhone = reader["AltPhone"] as String;
                    instructor.FirstName = reader["FirstName"] as String;
                    instructor.HomePhone = reader["HomePhone"] as String;
                    instructor.LastName = reader["LastName"] as String;
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

            return instructor;
        }

        public static IEnumerable<Instructor> GetInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();

            // Get Connection
            SqlConnection conn = GetConnection();

            // Get Command
            SqlCommand comm = GetCommand("dbo.GetInstructors", conn);

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
                    instructor.AddressCountry = reader["AddressCountry"] as String;
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
        }

        public static int AddInstructor(Instructor instructor)
        {
            int result = 0;

            // Get Connection
            SqlConnection conn = GetConnection();

            // Get Command
            SqlCommand comm = GetCommand("dbo.AddInstructor", conn);
            comm.Parameters.AddWithValue("AddressCity", instructor.AddressCity);
            comm.Parameters.AddWithValue("AddressCountry", instructor.AddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", instructor.AddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", instructor.AddressLine2 == null ? (object)DBNull.Value : instructor.AddressLine2);
            comm.Parameters.AddWithValue("AddressPostalCode", instructor.AddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", instructor.AddressRegion);
            comm.Parameters.AddWithValue("AltPhone", instructor.AltPhone == null ? (object)DBNull.Value : instructor.AltPhone);
            comm.Parameters.AddWithValue("FirstName", instructor.FirstName);
            comm.Parameters.AddWithValue("HomePhone", instructor.HomePhone);
            comm.Parameters.AddWithValue("LastName", instructor.LastName);

            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                result = comm.ExecuteNonQuery();
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

            return result;
        }

        public static int RemoveInstructor(Instructor oldInstructor)
        {
            int result = 0;

            // Get Connection
            SqlConnection conn = GetConnection();

            // Get Command
            SqlCommand comm = GetCommand("dbo.RemoveInstructor", conn);
            comm.Parameters.AddWithValue("OldInstructorID", oldInstructor.InstructorID);
            comm.Parameters.AddWithValue("OldAddressCity", oldInstructor.AddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", oldInstructor.AddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", oldInstructor.AddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", oldInstructor.AddressLine2 == null ? (object)DBNull.Value : oldInstructor.AddressLine2);
            comm.Parameters.AddWithValue("OldAddressPostalCode", oldInstructor.AddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", oldInstructor.AddressRegion);
            comm.Parameters.AddWithValue("OldAltPhone", oldInstructor.AltPhone == null ? (object)DBNull.Value : oldInstructor.AltPhone);
            comm.Parameters.AddWithValue("OldFirstName", oldInstructor.FirstName);
            comm.Parameters.AddWithValue("OldHomePhone", oldInstructor.HomePhone);
            comm.Parameters.AddWithValue("OldLastName", oldInstructor.LastName);

            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                result = comm.ExecuteNonQuery();
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

            return result;
        }

        public static int UpdateInstructor(Instructor instructor, Instructor oldInstructor)
        {
            int result = 0;

            // Get Connection
            SqlConnection conn = GetConnection();

            // Get Command
            SqlCommand comm = GetCommand("dbo.UpdateInstructor", conn);
            comm.Parameters.AddWithValue("AddressCity", instructor.AddressCity);
            comm.Parameters.AddWithValue("AddressCountry", instructor.AddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", instructor.AddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", instructor.AddressLine2 == null ? (object)DBNull.Value : instructor.AddressLine2);
            comm.Parameters.AddWithValue("AddressPostalCode", instructor.AddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", instructor.AddressRegion);
            comm.Parameters.AddWithValue("AltPhone", instructor.AltPhone == null ? (object)DBNull.Value : instructor.AltPhone);
            comm.Parameters.AddWithValue("FirstName", instructor.FirstName);
            comm.Parameters.AddWithValue("HomePhone", instructor.HomePhone);
            comm.Parameters.AddWithValue("LastName", instructor.LastName);
            comm.Parameters.AddWithValue("OldInstructorID", oldInstructor.InstructorID);
            comm.Parameters.AddWithValue("OldAddressCity", oldInstructor.AddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", oldInstructor.AddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", oldInstructor.AddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", oldInstructor.AddressLine2 == null ? (object)DBNull.Value : oldInstructor.AddressLine2);
            comm.Parameters.AddWithValue("OldAddressPostalCode", oldInstructor.AddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", oldInstructor.AddressRegion);
            comm.Parameters.AddWithValue("OldAltPhone", oldInstructor.AltPhone == null ? (object)DBNull.Value : oldInstructor.AltPhone);
            comm.Parameters.AddWithValue("OldFirstName", oldInstructor.FirstName);
            comm.Parameters.AddWithValue("OldHomePhone", oldInstructor.HomePhone);
            comm.Parameters.AddWithValue("OldLastName", oldInstructor.LastName);

            try
            {
                // Open Connection
                conn.Open();

                // ExecuteCommand
                result = comm.ExecuteNonQuery();
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

            return result;
        }
    }
}
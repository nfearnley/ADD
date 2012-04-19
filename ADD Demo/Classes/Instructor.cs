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
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } // Can be null
        public string AddressPostalCode { get; set; }
        public string AddressRegion { get; set; }
        public string AltPhone { get; set; } // Can be null
        public string FirstName { get; set; }
        public string HomePhone { get; set; }
        public string LastName { get; set; }

        public Instructor()
        { }

        // Get Instructor
        public static IEnumerable<Instructor> GetInstructor(int instructorID)
        {
            IEnumerable<Instructor> instructors = new List<Instructor>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInstructor"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("InstructorID", instructorID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                instructors = Read(reader);
            }

            return instructors;
        }

        // Get all Instructors
        public static IEnumerable<Instructor> GetInstructors()
        {
            IEnumerable<Instructor> instructors = new List<Instructor>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInstructors"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                instructors = Read(reader);
            }

            return instructors;
        }

        // Add Instructor, return InstructorID
        public static int AddInstructor(Instructor instructor)
        {
            int instructorID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddInstructor"))
            {
                // Set Parameters
                AddParameters(instructor, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                instructorID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return instructorID;
        }

        // Remove Instructor, return number of rows affected
        public static int RemoveInstructor(Instructor oldInstructor)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveInstructor"))
            {
                // Set Parameters
                AddOldParameters(oldInstructor, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        // Update Instructor, return number of rows affected
        public static int UpdateInstructor(Instructor instructor, Instructor oldInstructor)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateInstructor"))
            {
                // Set Parameters
                AddParameters(instructor, db.comm);
                AddOldParameters(oldInstructor, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        // Read Response
        private static IList<Instructor> Read(SqlDataReader reader)
        {
            IList<Instructor> instructors = new List<Instructor>();
            while (reader.Read())
            {
                Instructor instructor = new Instructor();
                instructor.InstructorID = (int)reader["InstructorID"];
                instructor.AddressCity = (string)reader["AddressCity"];
                instructor.AddressCountry = (string)reader["AddressCountry"];
                instructor.AddressLine1 = (string)reader["AddressLine1"];
                instructor.AddressLine2 = reader["AddressLine2"] as string; // Allow null
                instructor.AddressPostalCode = (string)reader["AddressPostalCode"];
                instructor.AddressRegion = (string)reader["AddressRegion"];
                instructor.AltPhone = reader["AltPhone"] as string; // Allow null
                instructor.FirstName = (string)reader["FirstName"];
                instructor.HomePhone = (string)reader["HomePhone"];
                instructor.LastName = (string)reader["LastName"];
                instructors.Add(instructor);
            }
            return instructors;
        }

        // Set Parameters
        private static void AddParameters(Instructor instructor, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("AddressCity", instructor.AddressCity);
            comm.Parameters.AddWithValue("AddressCountry", instructor.AddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", instructor.AddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", instructor.AddressLine2 == null ? (object)DBNull.Value : instructor.AddressLine2); // Check for null
            comm.Parameters.AddWithValue("AddressPostalCode", instructor.AddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", instructor.AddressRegion);
            comm.Parameters.AddWithValue("AltPhone", instructor.AltPhone == null ? (object)DBNull.Value : instructor.AltPhone); // Check for null
            comm.Parameters.AddWithValue("FirstName", instructor.FirstName);
            comm.Parameters.AddWithValue("HomePhone", instructor.HomePhone);
            comm.Parameters.AddWithValue("LastName", instructor.LastName);
        }

        // Set Parameters
        private static void AddOldParameters(Instructor instructor, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldInstructorID", instructor.InstructorID);
            comm.Parameters.AddWithValue("OldAddressCity", instructor.AddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", instructor.AddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", instructor.AddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", instructor.AddressLine2 == null ? (object)DBNull.Value : instructor.AddressLine2); // Check for null
            comm.Parameters.AddWithValue("OldAddressPostalCode", instructor.AddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", instructor.AddressRegion);
            comm.Parameters.AddWithValue("OldAltPhone", instructor.AltPhone == null ? (object)DBNull.Value : instructor.AltPhone); // Check for null
            comm.Parameters.AddWithValue("OldFirstName", instructor.FirstName);
            comm.Parameters.AddWithValue("OldHomePhone", instructor.HomePhone);
            comm.Parameters.AddWithValue("OldLastName", instructor.LastName);
        }
    }
}
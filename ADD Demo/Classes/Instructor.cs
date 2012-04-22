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
        public string InstructorAddressCity { get; set; }
        public string InstructorAddressCountry { get; set; }
        public string InstructorAddressLine1 { get; set; }
        public string InstructorAddressLine2 { get; set; } // Can be null
        public string InstructorAddressPostalCode { get; set; }
        public string InstructorAddressRegion { get; set; }
        public string InstructorAltPhone { get; set; } // Can be null
        public string InstructorFirstName { get; set; }
        public string InstructorHomePhone { get; set; }
        public string InstructorLastName { get; set; }
        public string InstructorFullName { get { return InstructorFirstName + " " + InstructorLastName; } }

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
                instructors = ReadInstructors(reader);
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
                instructors = ReadInstructors(reader);
            }

            return instructors;
        }

        // Get Instructor
        public static IEnumerable<Instructor> GetInstructorsByCourseID(int courseID)
        {
            IEnumerable<Instructor> instructors = new List<Instructor>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInstructorQualificationsByCourseID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CourseID", courseID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                instructors = ReadInstructors(reader);
            }

            return instructors;
        }

        // Get Instructor
        public static IEnumerable<Instructor> GetUnqualifiedInstructorsByCourseID(int courseID)
        {
            IEnumerable<Instructor> instructors = new List<Instructor>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetUnqualifiedInstructorsByCourseID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CourseID", courseID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                instructors = ReadInstructors(reader);
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
        private static IList<Instructor> ReadInstructors(SqlDataReader reader)
        {
            IList<Instructor> instructors = new List<Instructor>();
            while (reader.Read())
            {
                instructors.Add(ReadInstructor(reader));
            }
            return instructors;
        }

        public static Instructor ReadInstructor(SqlDataReader reader)
        {
            Instructor instructor = new Instructor();
            instructor.InstructorID = (int)reader["InstructorID"];
            instructor.InstructorAddressCity = (string)reader["InstructorAddressCity"];
            instructor.InstructorAddressCountry = (string)reader["InstructorAddressCountry"];
            instructor.InstructorAddressLine1 = (string)reader["InstructorAddressLine1"];
            instructor.InstructorAddressLine2 = reader["InstructorAddressLine2"] as string; // Allow null
            instructor.InstructorAddressPostalCode = (string)reader["InstructorAddressPostalCode"];
            instructor.InstructorAddressRegion = (string)reader["InstructorAddressRegion"];
            instructor.InstructorAltPhone = reader["InstructorAltPhone"] as string; // Allow null
            instructor.InstructorFirstName = (string)reader["InstructorFirstName"];
            instructor.InstructorHomePhone = (string)reader["InstructorHomePhone"];
            instructor.InstructorLastName = (string)reader["InstructorLastName"];
            return instructor;
        }

        // Set Parameters
        private static void AddParameters(Instructor instructor, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("AddressCity", instructor.InstructorAddressCity);
            comm.Parameters.AddWithValue("AddressCountry", instructor.InstructorAddressCountry);
            comm.Parameters.AddWithValue("AddressLine1", instructor.InstructorAddressLine1);
            comm.Parameters.AddWithValue("AddressLine2", instructor.InstructorAddressLine2 == null ? (object)DBNull.Value : instructor.InstructorAddressLine2); // Check for null
            comm.Parameters.AddWithValue("AddressPostalCode", instructor.InstructorAddressPostalCode);
            comm.Parameters.AddWithValue("AddressRegion", instructor.InstructorAddressRegion);
            comm.Parameters.AddWithValue("AltPhone", instructor.InstructorAltPhone == null ? (object)DBNull.Value : instructor.InstructorAltPhone); // Check for null
            comm.Parameters.AddWithValue("FirstName", instructor.InstructorFirstName);
            comm.Parameters.AddWithValue("HomePhone", instructor.InstructorHomePhone);
            comm.Parameters.AddWithValue("LastName", instructor.InstructorLastName);
        }

        // Set Parameters
        private static void AddOldParameters(Instructor instructor, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldInstructorID", instructor.InstructorID);
            comm.Parameters.AddWithValue("OldAddressCity", instructor.InstructorAddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", instructor.InstructorAddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", instructor.InstructorAddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", instructor.InstructorAddressLine2 == null ? (object)DBNull.Value : instructor.InstructorAddressLine2); // Check for null
            comm.Parameters.AddWithValue("OldAddressPostalCode", instructor.InstructorAddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", instructor.InstructorAddressRegion);
            comm.Parameters.AddWithValue("OldAltPhone", instructor.InstructorAltPhone == null ? (object)DBNull.Value : instructor.InstructorAltPhone); // Check for null
            comm.Parameters.AddWithValue("OldFirstName", instructor.InstructorFirstName);
            comm.Parameters.AddWithValue("OldHomePhone", instructor.InstructorHomePhone);
            comm.Parameters.AddWithValue("OldLastName", instructor.InstructorLastName);
        }
    }
}
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
            Instructor instructor = new Instructor();

            // Get Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetInstructor");
            db.comm.Parameters.AddWithValue("InstructorID", instructorID);

            try
            {
                // Open Connection
                db.conn.Open();

                // ExecuteCommand
                SqlDataReader reader = db.comm.ExecuteReader();

                IList<Instructor> instructors = Read(reader);
                instructor = instructors[0];
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return instructor;
        }

        public static IEnumerable<Instructor> GetInstructors()
        {
            IEnumerable<Instructor> instructors = new List<Instructor>();

            // Get Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetInstructors");

            try
            {
                // Open Connection
                db.conn.Open();

                // ExecuteCommand
                SqlDataReader reader = db.comm.ExecuteReader();

                instructors = Read(reader);
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return instructors;
        }

        public static int AddInstructor(Instructor instructor)
        {
            int InstructorID = -1;

            // Get Connection
            DatabaseConnection db = new DatabaseConnection("dbo.AddInstructor");

            // Get Command
            AddParameters(instructor, db.comm);

            try
            {
                // Open Connection
                db.conn.Open();

                // ExecuteCommand
                InstructorID = Convert.ToInt32(db.comm.ExecuteScalar());
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }

            return InstructorID;
        }

        public static int RemoveInstructor(Instructor oldInstructor)
        {
            int rowsAffected = 0;

            // Get Connection
            DatabaseConnection db = new DatabaseConnection("dbo.RemoveInstructor");
            AddOldParameters(oldInstructor, db.comm);

            try
            {
                // Open Connection
                db.conn.Open();

                // ExecuteCommand
                rowsAffected = db.comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return rowsAffected;
        }

        public static int UpdateInstructor(Instructor instructor, Instructor oldInstructor)
        {
            int rowsAffected = 0;

            // Get Connection
            DatabaseConnection db = new DatabaseConnection("dbo.UpdateInstructor");
            AddParameters(instructor, db.comm);
            AddOldParameters(oldInstructor, db.comm);

            try
            {
                // Open Connection
                db.conn.Open();

                // ExecuteCommand
                rowsAffected = db.comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }

            return rowsAffected;
        }

        private static IList<Instructor> Read(SqlDataReader reader)
        {
            IList<Instructor> instructors = new List<Instructor>();
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
            return instructors;
        }

        private static void AddParameters(Instructor instructor, SqlCommand comm)
        {
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
        }

        private static void AddOldParameters(Instructor instructor, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldInstructorID", instructor.InstructorID);
            comm.Parameters.AddWithValue("OldAddressCity", instructor.AddressCity);
            comm.Parameters.AddWithValue("OldAddressCountry", instructor.AddressCountry);
            comm.Parameters.AddWithValue("OldAddressLine1", instructor.AddressLine1);
            comm.Parameters.AddWithValue("OldAddressLine2", instructor.AddressLine2 == null ? (object)DBNull.Value : instructor.AddressLine2);
            comm.Parameters.AddWithValue("OldAddressPostalCode", instructor.AddressPostalCode);
            comm.Parameters.AddWithValue("OldAddressRegion", instructor.AddressRegion);
            comm.Parameters.AddWithValue("OldAltPhone", instructor.AltPhone == null ? (object)DBNull.Value : instructor.AltPhone);
            comm.Parameters.AddWithValue("OldFirstName", instructor.FirstName);
            comm.Parameters.AddWithValue("OldHomePhone", instructor.HomePhone);
            comm.Parameters.AddWithValue("OldLastName", instructor.LastName);
        }
    }
}
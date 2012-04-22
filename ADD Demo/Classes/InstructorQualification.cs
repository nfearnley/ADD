using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class InstructorQualification
    {
        public int CourseID { get { return course.CourseID; } set { course.CourseID = value; } }
        public int InstructorID { get { return instructor.InstructorID; } set { instructor.InstructorID = value; } }
        public string CourseCode { get { return course.CourseCode; } set { course.CourseCode = value; } }
        public string CourseDescription { get { return course.Description; } set { course.Description = value; } }
        public string CourseOutline { get { return course.Outline; } set { course.Outline = value; } }
        public decimal CoursePrice { get { return course.Price; } set { course.Price = value; } }
        public string InstructorAddressCity { get { return instructor.AddressCity; } set { instructor.AddressCity = value;  } }
        public string InstructorAddressCountry { get { return instructor.AddressCountry; } set { instructor.AddressCountry = value; } }
        public string InstructorAddressLine1 { get { return instructor.AddressLine1; } set { instructor.AddressLine1 = value; } }
        public string InstructorAddressLine2 { get { return instructor.AddressLine2; } set { instructor.AddressLine2 = value; } }
        public string InstructorAddressPostalCode { get { return instructor.AddressPostalCode; } set { instructor.AddressPostalCode = value; } }
        public string InstructorAddressRegion { get { return instructor.AddressRegion; } set { instructor.AddressRegion = value; } }
        public string InstructorAltPhone { get { return instructor.AltPhone; } set { instructor.AltPhone = value; } }
        public string InstructorFirstName { get { return instructor.FirstName; } set { instructor.FirstName = value; } }
        public string InstructorHomePhone { get { return instructor.HomePhone; } set { instructor.HomePhone = value; } }
        public string InstructorLastName { get { return instructor.LastName; } set { instructor.LastName = value; } }
        public string InstructorFullName { get { return instructor.FullName; } }
        public Course course { get; set; }
        public Instructor instructor { get; set; }

        public InstructorQualification()
        {
            course = new Course();
            instructor = new Instructor();
        }

        // Get InstructorQualifications by CourseID
        public static IEnumerable<InstructorQualification> GetInstructorQualificationsByCourseID(int courseID)
        {
            IEnumerable<InstructorQualification> instructorQualifications = new List<InstructorQualification>();

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
                instructorQualifications = Read(reader);
            }

            return instructorQualifications;
        }

        // Get InstructorQualifications by InstructorID
        public static IEnumerable<InstructorQualification> GetInstructorQualificationsByInstructorID(int instructorID)
        {
            IEnumerable<InstructorQualification> instructorQualifications = new List<InstructorQualification>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInstructorQualificationsByInstructorID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("InstructorID", instructorID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                instructorQualifications = Read(reader);
            }

            return instructorQualifications;
        }

        // Get all InstructorQualifications
        public static IEnumerable<InstructorQualification> GetInstructorQualifications()
        {
            IEnumerable<InstructorQualification> instructorQualifications = new List<InstructorQualification>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetInstructorQualifications"))
            {
                // Open Connection
                db.conn.Open();
                SqlDataReader reader = db.comm.ExecuteReader();
                instructorQualifications = Read(reader);
            }

            return instructorQualifications;
        }

        // Add InstructorQualification, return number of rows affected
        public static int AddInstructorQualification(InstructorQualification instructorQualification)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddInstructorQualification"))
            {
                // Set Parameters
                AddParameters(instructorQualification, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        // Remove InstructorQualification, return number of rows affected
        public static int RemoveInstructorQualification(InstructorQualification oldInstructorQualification)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveInstructorQualification"))
            {
                // Set Parameters
                AddOldParameters(oldInstructorQualification, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        // Read Response
        private static IList<InstructorQualification> Read(SqlDataReader reader)
        {
            IList<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
            while (reader.Read())
            {
                InstructorQualification instructorQualification = new InstructorQualification();
                instructorQualification.course = Course.ReadCourse(reader);
                instructorQualification.instructor = Instructor.ReadInstructor(reader);
                instructorQualifications.Add(instructorQualification);
            }
            return instructorQualifications;
        }

        // Set Parameters
        private static void AddParameters(InstructorQualification instructorQualification, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CourseID", instructorQualification.CourseID);
            comm.Parameters.AddWithValue("InstructorID", instructorQualification.InstructorID);
        }

        // Set Parameters
        private static void AddOldParameters(InstructorQualification instructorQualification, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCourseID", instructorQualification.CourseID);
            comm.Parameters.AddWithValue("OldInstructorID", instructorQualification.InstructorID);
        }
    }
}
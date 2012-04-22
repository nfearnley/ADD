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
        public Course course { get; set; }
        public int CourseID { get { return course.CourseID; } set { course.CourseID = value; } }
        public string CourseCode { get { return course.CourseCode; } }
        public string CourseDescription { get { return course.CourseDescription; } }
        public string CourseOutline { get { return course.CourseOutline; } }
        public decimal CoursePrice { get { return course.CoursePrice; } }
        public Instructor instructor { get; set; }
        public int InstructorID { get { return instructor.InstructorID; } set { instructor.InstructorID = value; } }
        public string InstructorAddressCity { get { return instructor.InstructorAddressCity; } }
        public string InstructorAddressCountry { get { return instructor.InstructorAddressCountry; } }
        public string InstructorAddressLine1 { get { return instructor.InstructorAddressLine1; } }
        public string InstructorAddressLine2 { get { return instructor.InstructorAddressLine2; } }
        public string InstructorAddressPostalCode { get { return instructor.InstructorAddressPostalCode; } }
        public string InstructorAddressRegion { get { return instructor.InstructorAddressRegion; } }
        public string InstructorAltPhone { get { return instructor.InstructorAltPhone; } }
        public string InstructorFirstName { get { return instructor.InstructorFirstName; } }
        public string InstructorHomePhone { get { return instructor.InstructorHomePhone; } }
        public string InstructorLastName { get { return instructor.InstructorLastName; } }
        public string InstructorFullName { get { return instructor.InstructorFullName; } }

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
                instructorQualifications = ReadInstructorQualifications(reader);
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
                instructorQualifications = ReadInstructorQualifications(reader);
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
                instructorQualifications = ReadInstructorQualifications(reader);
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
        private static IList<InstructorQualification> ReadInstructorQualifications(SqlDataReader reader)
        {
            IList<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
            while (reader.Read())
            {
                instructorQualifications.Add(ReadInstructorQualification(reader));
            }
            return instructorQualifications;
        }

        public static InstructorQualification ReadInstructorQualification(SqlDataReader reader)
        {
            InstructorQualification instructorQualification = new InstructorQualification();
            instructorQualification.course = Course.ReadCourse(reader);
            instructorQualification.instructor = Instructor.ReadInstructor(reader);
            return instructorQualification;
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
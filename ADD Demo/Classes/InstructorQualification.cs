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
        public int CourseID
        {
            get
            {
                return Course.CourseID;
            }
            set
            {
                Course.CourseID = value;
            }
        }
        public int InstructorID
        {
            get
            {
                return Instructor.InstructorID;
            }
            set
            {
                Instructor.InstructorID = value;
            }
        }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }

        public InstructorQualification()
        {
            Course = new Course();
            Instructor = new Instructor();
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
                instructorQualification.Course = Course.ReadCourse(reader);
                instructorQualification.Instructor = Instructor.ReadInstructor(reader);
                instructorQualifications.Add(instructorQualification);
            }
            return instructorQualifications;
        }

        // Set Parameters
        private static void AddParameters(InstructorQualification instructorQualification, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CourseID", instructorQualification.Course.CourseID);
            comm.Parameters.AddWithValue("InstructorID", instructorQualification.Instructor.InstructorID);
        }

        // Set Parameters
        private static void AddOldParameters(InstructorQualification instructorQualification, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCourseID", instructorQualification.Course.CourseID);
            comm.Parameters.AddWithValue("OldInstructorID", instructorQualification.Instructor.InstructorID);
        }
    }
}
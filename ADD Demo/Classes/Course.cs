using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ADD_Demo.Classes
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public string CourseOutline { get; set; }
        public decimal CoursePrice { get; set; }

        public Course()
        { }

        public static IEnumerable<Course> GetCourse(int courseID)
        {
            IEnumerable<Course> courses = new List<Course>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetCourse"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("CourseID", courseID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                courses = ReadCourses(reader);
            }

            return courses;
        }

        public static IEnumerable<Course> GetCourses()
        {
            IEnumerable<Course> courses = new List<Course>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetCourses"))
            {
                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                courses = ReadCourses(reader);
            }

            return courses;
        }

        public static IEnumerable<Course> GetUnqualifiedCoursesByInstructorID(int instructorID)
        {
            IEnumerable<Course> courses = new List<Course>();

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.GetUnqualifiedCoursesByInstructorID"))
            {
                // Set Parameters
                db.comm.Parameters.AddWithValue("InstructorID", instructorID);

                // Open Connection
                db.conn.Open();

                // Execute Command
                SqlDataReader reader = db.comm.ExecuteReader();

                // Read Response
                courses = ReadCourses(reader);
            }

            return courses;
        }


        public static int AddCourse(Course course)
        {
            int courseID = -1;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.AddCourse"))
            {
                // Set Parameters
                AddParameters(course, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                courseID = Convert.ToInt32(db.comm.ExecuteScalar());
            }

            return courseID;
        }

        public static int RemoveCourse(Course oldCourse)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.RemoveCourse"))
            {
                // Set Parameters
                AddOldParameters(oldCourse, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        public static int UpdateCourse(Course course, Course oldCourse)
        {
            int rowsAffected = 0;

            // Setup Connection
            using (DatabaseConnection db = new DatabaseConnection("dbo.UpdateCourse"))
            {
                // Set Parameters
                AddParameters(course, db.comm);
                AddOldParameters(oldCourse, db.comm);

                // Open Connection
                db.conn.Open();

                // Execute Command and Read Response
                rowsAffected = db.comm.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        private static IList<Course> ReadCourses(SqlDataReader reader)
        {
            IList<Course> courses = new List<Course>();
            while (reader.Read())
            {
                courses.Add(ReadCourse(reader));
            }
            return courses;
        }

        public static Course ReadCourse(SqlDataReader reader)
        {
            Course course = new Course();
            course.CourseID = (int)reader["CourseID"];
            course.CourseCode = (string)reader["CourseCode"];
            course.CourseDescription = (string)reader["CourseDescription"];
            course.CourseOutline = (string)reader["CourseOutline"];
            course.CoursePrice = (decimal)reader["CoursePrice"];
            return course;
        }

        private static void AddParameters(Course course, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CourseCode", course.CourseCode);
            comm.Parameters.AddWithValue("Description", course.CourseDescription);
            comm.Parameters.AddWithValue("Outline", course.CourseOutline);
            comm.Parameters.AddWithValue("Price", course.CoursePrice);
        }

        private static void AddOldParameters(Course course, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCourseID", course.CourseID);
            comm.Parameters.AddWithValue("OldCourseCode", course.CourseCode);
            comm.Parameters.AddWithValue("OldDescription", course.CourseDescription);
            comm.Parameters.AddWithValue("OldOutline", course.CourseOutline);
            comm.Parameters.AddWithValue("OldPrice", course.CoursePrice);
        }
    }
}
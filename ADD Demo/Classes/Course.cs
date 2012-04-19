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
        public string Description { get; set; }
        public string Outline { get; set; }
        public decimal Price { get; set; }

        public Course()
        { }

        public static Course GetCourse(int courseID)
        {
            Course course = new Course();

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
                IList<Course> courses = Read(reader);
                course = courses[0];
            }

            return course;
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
                courses = Read(reader);
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

        private static IList<Course> Read(SqlDataReader reader)
        {
            IList<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course();
                course.CourseID = (int)reader["CourseID"];
                course.CourseCode = (string)reader["CourseCode"];
                course.Description = (string)reader["Description"];
                course.Outline = (string)reader["Outline"];
                course.Price = (decimal)reader["Price"];
                courses.Add(course);
            }
            return courses;
        }

        private static void AddParameters(Course course, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CourseCode", course.CourseCode);
            comm.Parameters.AddWithValue("Description", course.Description);
            comm.Parameters.AddWithValue("Outline", course.Outline);
            comm.Parameters.AddWithValue("Price", course.Price);
        }

        private static void AddOldParameters(Course course, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCourseID", course.Price);
            comm.Parameters.AddWithValue("OldCourseCode", course.CourseCode);
            comm.Parameters.AddWithValue("OldDescription", course.Description);
            comm.Parameters.AddWithValue("OldOutline", course.Outline);
            comm.Parameters.AddWithValue("OldPrice", course.Price);
        }
    }
}
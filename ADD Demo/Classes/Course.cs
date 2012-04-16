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
        public String CourseCode { get; set; }
        public String Description { get; set; }
        public String Outline { get; set; }
        public float Price { get; set; }

        public Course()
        { }

        public Course(String courseCode,String description,String outline, float price)
        {
            CourseCode = courseCode;
            Description = description;
            Outline = outline;
            Price = price;
        }

        public static Course GetCourse(int courseID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCourse", conn);
            comm.Parameters.AddWithValue("CourseID", courseID);
            Course course = new Course();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {

                    course.CourseCode = reader["CourseCode"] as String;
                    course.Description = reader["Description"] as String;
                    course.Outline = reader["Outline"] as String;
                    course.Price = (float)reader["Price"];
                    course.CourseID = (int)reader["CourseID"];
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
            return course;
        }

        public static IEnumerable<Course> GetCourses()
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetCourses", conn);
            List<Course> courses = new List<Course>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseCode = reader["CourseCode"] as String;
                    course.Description = reader["Description"] as String;
                    course.Outline = reader["Outline"] as String;
                    course.Price = (float)reader["Price"];
                    course.CourseID = (int)reader["CourseID"];
                    courses.Add(course);
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
            return courses;
        }

        public static int AddCourse(Course course)
        {
            int result = 0;

            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddCourse", conn);
            comm.Parameters.AddWithValue("Price", course.Price);
            comm.Parameters.AddWithValue("Outline", course.Outline);
            comm.Parameters.AddWithValue("Description", course.Description);
            comm.Parameters.AddWithValue("CourseCode", course.CourseCode);            
            try
            {
                conn.Open();
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

        public static int RemoveCourse(int courseID)
        {
            int result = 0;

            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveCourse", conn);
            comm.Parameters.AddWithValue("CourseID", courseID);
            try
            {
                conn.Open();
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

        public static int UpdateCourse(Course course)
        {
            int result = 0;

            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.UpdateCourse", conn);
            comm.Parameters.AddWithValue("Price", course.Price);
            comm.Parameters.AddWithValue("Outline", course.Outline);
            comm.Parameters.AddWithValue("Description", course.Description);
            comm.Parameters.AddWithValue("CourseCode", course.CourseCode);
            try
            {
                conn.Open();
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
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
        public int CourseID { get; set; }
        public int InstructorID { get; set; }

        public InstructorQualification()
        { }

        public InstructorQualification(int courseID,int instructorID)
        {
            CourseID = courseID;
            InstructorID = instructorID;
        }

        public static IEnumerable<InstructorQualification> GetInstructorQualificationsByCourseID(int courseID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInstructorQualificationsByCourseID", conn);
            comm.Parameters.AddWithValue("CourseID", courseID);
            List<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    InstructorQualification instQual = new InstructorQualification();
                    instQual.CourseID = (int)reader["CourseID"];
                    instQual.InstructorID = (int)reader["InstructorID"];
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
            return instructorQualifications;
        }

        public static IEnumerable<InstructorQualification> GetInstructorQualificationsByInstructorID(int instructorID)
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInstructorQualificationsByInstructorID", conn);
            comm.Parameters.AddWithValue("InstructorID", instructorID);
            List<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    InstructorQualification instQual = new InstructorQualification();
                    instQual.CourseID = (int)reader["CourseID"];
                    instQual.InstructorID = (int)reader["InstructorID"];
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
            return instructorQualifications;
        }

        public static IEnumerable<InstructorQualification> GetInstructorQualifications()
        {
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.GetInstructorQualifications", conn);
            List<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    InstructorQualification instQual = new InstructorQualification();
                    instQual.CourseID = (int)reader["CourseID"];
                    instQual.InstructorID = (int)reader["InstructorID"];
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
            return instructorQualifications;
        }

        public static int AddInstructorQualification(InstructorQualification instQual)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.AddInstructorQualification", conn);
            comm.Parameters.AddWithValue("CourseID", instQual.CourseID);
            comm.Parameters.AddWithValue("InstructorID", instQual.InstructorID);
            List<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
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

        public static int RemoveInstructorQualification(int instructorID, int courseID)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveInstructorQualification", conn);
            comm.Parameters.AddWithValue("CourseID", courseID);
            comm.Parameters.AddWithValue("InstructorID", instructorID);
            List<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
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

        public static int RemoveInstructorQualification(InstructorQualification instQual)
        {
            int result = 0;
            // Setup Connection
            SqlConnection conn = DatabaseConnection.GetConnection();
            // Setup Command
            SqlCommand comm = DatabaseConnection.GetCommand("dbo.RemoveInstructorQualification", conn);
            comm.Parameters.AddWithValue("CourseID", instQual.CourseID);
            comm.Parameters.AddWithValue("InstructorID", instQual.InstructorID);
            List<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
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
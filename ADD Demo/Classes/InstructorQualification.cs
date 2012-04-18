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

        public static IEnumerable<InstructorQualification> GetInstructorQualificationsByCourseID(int courseID)
        {
            IEnumerable<InstructorQualification> instructorQualifications = new List<InstructorQualification>();

            // Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetInstructorQualificationsByCourseID");
            db.comm.Parameters.AddWithValue("CourseID", courseID);

            try
            {
                db.conn.Open();
                SqlDataReader reader = db.comm.ExecuteReader();
                instructorQualifications = Read(reader);
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }
            return instructorQualifications;
        }

        public static IEnumerable<InstructorQualification> GetInstructorQualificationsByInstructorID(int instructorID)
        {
            IEnumerable<InstructorQualification> instructorQualifications = new List<InstructorQualification>();

            // Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetInstructorQualificationsByCourseID");
            db.comm.Parameters.AddWithValue("InstructorID", instructorID);

            try
            {
                db.conn.Open();
                SqlDataReader reader = db.comm.ExecuteReader();
                instructorQualifications = Read(reader);
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }
            return instructorQualifications;
        }

        public static IEnumerable<InstructorQualification> GetInstructorQualifications()
        {
            IEnumerable<InstructorQualification> instructorQualifications = new List<InstructorQualification>();

            // Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.GetInstructorQualifications");
            
            try
            {
                db.conn.Open();
                SqlDataReader reader = db.comm.ExecuteReader();
                instructorQualifications = Read(reader);
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }
            return instructorQualifications;
        }

        public static int AddInstructorQualification(InstructorQualification instructorQualification)
        {
            int rowsAffected = 0;

            // Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.AddInstructorQualification");
            AddParameters(instructorQualification, db.comm);

            try
            {
                db.conn.Open();
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

        public static int RemoveInstructorQualification(InstructorQualification oldInstructorQualification)
        {
            int result = 0;

            // Setup Connection
            DatabaseConnection db = new DatabaseConnection("dbo.RemoveInstructorQualification");
            AddOldParameters(oldInstructorQualification, db.comm);

            try
            {
                db.conn.Open();
                result = db.comm.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                // Close Connection
                db.Dispose();
            }
            return result;
        }

        private static IList<InstructorQualification> Read(SqlDataReader reader)
        {
            IList<InstructorQualification> instructorQualifications = new List<InstructorQualification>();
            while (reader.Read())
            {
                InstructorQualification instructorQualification = new InstructorQualification();
                instructorQualification.CourseID = (int)reader["CourseID"];
                instructorQualification.InstructorID = (int)reader["InstructorID"];
                instructorQualifications.Add(instructorQualification);
            }
            return instructorQualifications;
        }

        private static void AddParameters(InstructorQualification instQual, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("CourseID", instQual.CourseID);
            comm.Parameters.AddWithValue("InstructorID", instQual.InstructorID);
        }

        private static void AddOldParameters(InstructorQualification instQual, SqlCommand comm)
        {
            comm.Parameters.AddWithValue("OldCourseID", instQual.CourseID);
            comm.Parameters.AddWithValue("OldInstructorID", instQual.InstructorID);
        }
    }
}
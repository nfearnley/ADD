using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class InstructorQualification
    {
        private int CourseID;
        private int InstructorID;

        public InstructorQualification()
        { }

        public InstructorQualification(int courseID,int instructorID)
        {
            CourseID = courseID;
            InstructorID = instructorID;
        }

        public static List<InstructorQualification> GetInstructorQualificationsByCourseID(int courseID)
        {
            return new List<InstructorQualification>();
        }

        public static List<InstructorQualification> GetInstructorQualificationsByInstructorID(int instructorID)
        {
            return new List<InstructorQualification>();
        }

        public static List<InstructorQualification> GetInstructorQualifications()
        {
            return new List<InstructorQualification>();
        }

        public static int AddInstructorQualification()
        {
            return 0;
        }

        public static int RemoveInstructorQualification(int instructorID, int courseID)
        {
            return 0;
        }

        public static int RemoveInstructorQualification(InstructorQualification instQual)
        {
            return 0;
        }
    }
}
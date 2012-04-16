using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Course
    {
        private int CourseID;
        private String CourseCode;
        private String Description;
        private String Outline;
        private float Price;

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
            return new Course();
        }

        public static List<Course> GetCourses()
        {
            return new List<Course>();
        }

        public static void AddCourse(Course course)
        { 
            
        }

        public static bool RemoveCourse(int courseID)
        {
            return false;
        }

        public static bool UpdateCourse(Course course)
        {
            return false;
        }
    }
}
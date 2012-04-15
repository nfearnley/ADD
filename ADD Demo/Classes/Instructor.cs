using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADD_Demo.Classes
{
    public class Instructor
    {
        private int InstructorID;
        private String AddressCity;
        private String AddressCountry;
        private String AddressLine1;
        private String AddressLine2;
        private String AddressPostalCode;
        private String AddressRegion;
        private String AltPhone;
        private String FirstName;
        private String HomePhone;
        private String LastName;

        public Instructor()
        { }

        public Instructor(String city, String country, String line1,String line2, String code, String region,String altPhone,String fName,String lName,String hPhone)
        { 
            AddressCity = city;
            AddressCountry = country;
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressPostalCode = code;
            AddressRegion = region;
            AltPhone = altPhone;
            FirstName = fName;
            HomePhone = hPhone;
            LastName = lName;
        }

        public static Instructor GetInstructor(int instructorID)
        { 

            return new Instructor();
        }

        public static List<Instructor> GetInstructors()
        {
            return new List<Instructor>();
        }

        public static void AddInstructor(Instructor inst)
        { 
        
        }

        public static Instructor RemoveInstructor(int instructorID)
        {
            return new Instructor();
        }

        public static bool UpdateInstructor(Instructor inst)
        {
            return false;        
        }
    }
}
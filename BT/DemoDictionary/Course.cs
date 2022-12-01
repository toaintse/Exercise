using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDictionary
{
    internal class Course
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   CourseID == course.CourseID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CourseID);
        }

        public Course()
        {
        }

        public Course(int courseID, string courseTitle)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
        }
    }
}

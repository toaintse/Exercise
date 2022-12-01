using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDictionary
{
    public delegate void GPAChangeHandler(); //dinh nghia kieu delegate

    internal class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        Dictionary<Course, double> courses = new Dictionary<Course, double>();

        public event GPAChangeHandler OnGPAChange; //dinh nghia Student co 1 event la OnGPAChange

        public void AddCourse(Course p, double g)
        {
            courses.Add(p, g);
            if (OnGPAChange != null)  OnGPAChange(); //raise len event
        }

        public void RemoveCourse(int CourseID)
        {
            Course c = new Course();
            c.CourseID = CourseID;
            courses.Remove(c);
            if (OnGPAChange != null) OnGPAChange();//raise len event
        }

        public override string ToString()
        {
            string s = $"Id: {StudentID}, Name: {StudentName}" + Environment.NewLine + "List of course:" + Environment.NewLine;
            foreach (Course c in courses.Keys)
                s += $"{c.CourseTitle} - {courses[c]}" + Environment.NewLine;
            return s;
        }
    }

}

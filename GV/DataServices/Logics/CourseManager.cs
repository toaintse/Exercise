using DataServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Logics
{
    public class CourseManager
    {
        public List<Course> GetCourses()
        {
            using(var context = new APContext())
            {
                return context.Courses
                    .Include(x => x.Subject)
                    .Include(x => x.Instructor)
                    .Include(x => x.Term)
                    .Include(x => x.Campus)
                    .ToList();
            }
        }

        public void AddCourse(Course c)
        {
            using (var context = new APContext())
            {
                context.Courses.Add(c);
                context.SaveChanges();
            }
        }

        public void Delete(int courseId)
        {
            using (var context = new APContext())
            {

                Course c = context.Courses.Include(x => x.Students).FirstOrDefault(x => x.CourseId == courseId);
                if (c != null)
                {
                    List<CourseSchedule> courseSchedules = context.CourseSchedules.Where(x => x.CourseId == courseId).ToList();
                    foreach (CourseSchedule cs in courseSchedules)
                    {
                        List<RollCallBook> rollCallBooks = context.RollCallBooks.Where(x => x.TeachingScheduleId == cs.TeachingScheduleId).ToList();
                        context.RollCallBooks.RemoveRange(rollCallBooks);
                    }
                    context.CourseSchedules.RemoveRange(courseSchedules);

                    foreach (Student s in c.Students)
                        s.Courses.Remove(c);
                        

                    context.Courses.Remove(c);
                    context.SaveChanges();
                }
            }
        }

        public void Edit(Course course)
        {
            using (var context = new APContext())
            {
                Course c = context.Courses.FirstOrDefault(x => x.CourseId == course.CourseId);
                if (c != null)
                {
                    c.CourseCode = course.CourseCode;
                    c.CourseDescription = course.CourseDescription;
                    c.SubjectId = course.SubjectId;
                    c.InstructorId = course.InstructorId;
                    c.TermId = course.TermId;
                    c.CampusId = c.CampusId;
                    context.SaveChanges();
                }
            }
        }


        public void AddCourse(Course course, List<int> studentIds)
        {
            using (var context = new APContext())
            {
                context.Courses.Add(course);
                foreach (int item in studentIds)
                {
                    Student s = context.Students.FirstOrDefault(x => x.StudentId == item);
                    if (s != null)
                        course.Students.Add(s);
                }
                context.SaveChanges();
            }
        }
       
    }
}

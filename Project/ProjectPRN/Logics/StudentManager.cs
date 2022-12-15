using ProjectPRN.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjectPRN.Logics
{
    public class StudentManager
    {
        APContext context = new APContext();
        public List<Student> GetStudents(int? stuId, int fromIndex, int numberItems, string? name)
        {
            List<Student> students = context.Students.ToList();
            if (stuId != 0)
                students = students.Where(x => x.StudentId == stuId).ToList();
            students = students.Skip(fromIndex - 1).Take(numberItems).ToList();
            if (name != null && !name.Equals(""))
                students = students.Where(x => x.FirstName.Equals(name) || x.MidName.Equals(name) || x.LastName.Equals(name)).ToList();
            return students;
        }

        public Student GetStudent(int? stuId)
        {
            Student student = context.Students.FirstOrDefault(x=>x.StudentId == stuId);
            return student;
        }

        public Student GetStudent(int stuId)
        {
            Student student = context.Students.FirstOrDefault(x=>x.StudentId == stuId);
            return student;
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public int GetTotalNumberOrders(int? stuId,string? name)
        {
            List<Student> students = context.Students.ToList();
            if (stuId != 0)
                students = students.Where(x => x.StudentId == stuId).ToList();
            if (name != null && !name.Equals(""))
                students = students.Where(x => x.FirstName.Contains(name)).ToList();
            return students.Count;
        }

        public void EditStudent(int stuId, string firstName, string midName, string lastName)
        {
            Student student = context.Students.FirstOrDefault(x => x.StudentId == stuId);
            if(student != null)
            {
                student.StudentId = stuId;
                student.FirstName = firstName;
                student.MidName = midName;
                student.LastName = lastName;
                context.SaveChanges();
            }
        }

        public void RemoveStudent(int stuId)
        {
            APContext context = new APContext();
            Student student = context.Students.Include(x=>x.Courses).Include(x=>x.RollCallBooks).FirstOrDefault(x => x.StudentId == stuId);
            foreach (Course item in student.Courses)
            {
                student.Courses.Remove(item);
            }
            foreach(RollCallBook item in student.RollCallBooks)
            {
                student.RollCallBooks.Remove(item);
            }
            context.Students.Remove(student);
            context.SaveChanges();
        }

        
    }
}

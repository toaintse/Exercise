using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StudentManager
{
    internal class StudentList
    {
        List<Student> Students =  new List<Student>();
        public void ReadFromFile(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            Student student = new Student(line);
                            Students.Add(student);
                        }
                        catch{}
                    }
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File yeu cau khong ton tai");
                return;
            }
        }

        public void Display()
        {
            Console.WriteLine("List of student:");
            foreach (Student s in Students)
                s.Display();
        }

        public void SortByID()
        {
            Students.Sort();
        }

        public void SortByName()
        {
            Students.Sort(new StudentNameComparer());
        }

        //Cach 1.
        //public int CompareByGPA(Student x, Student y)
        //{
        //    return x.Gpa.CompareTo(y.Gpa);
        //}

        //public void SortByGPA()
        //{
        //    Students.Sort(CompareByGPA);
        //}

        //Cach 2. Su dung anonymous function
        //public void SortByGPA()
        //{
        //    Students.Sort(
        //        delegate(Student x, Student y) { return x.Gpa.CompareTo(y.Gpa); }
        //        );
        //}

        //Cach 3. anonymous function -> su dung Lambda expression de rut gon Anonymous function
        public void SortByGPA()
        {
            Students.Sort((x, y) => x.Gpa.CompareTo(y.Gpa));
        }

        public List<Student> SearchByGPA(float Gpa)
        {
            return Students.Where(x => x.Gpa > Gpa).ToList();
        }

        public void SearchByMajor(string Major) //can xu ly gi do cho nay. Yeu cau bo sung.
        {
            var list = Students.Where(x => x.Major.Equals(Major))
                .Select(x => new {Code = x.Id, StudentName = x.Name })//anoymous constructor
                .ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"Id: {item.Code}, Name: {item.StudentName}");
            }
        }

    }
}

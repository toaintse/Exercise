using Ex29._11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex29._11.Logics
{
    internal class StudentList
    {
        public static void WriteToFile(List<Student> students, string Filename)
        {
            using (StreamWriter writer = new StreamWriter(Filename))
            {
                foreach (Student s in students)
                    writer.WriteLine(s.ToStringLine());
                writer.Close();
            }
        }
    }
}

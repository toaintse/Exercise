using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    static class ListExtension
    {
        static public void Display(this List<Student> list)
        {
            Console.WriteLine("List of items:");
            foreach (Student s in list)
                Console.WriteLine(s);
        }
    }
}

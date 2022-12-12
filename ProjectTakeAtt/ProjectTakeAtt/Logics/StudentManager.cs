using ProjectTakeAtt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTakeAtt.Logics
{
    internal class StudentManager
    {
        public List<Student> GetSubjects()
        {
            using (var context = new APContext())
            {
                return context.Students.ToList();
            }
        }
    }
}

using ProjectTakeAtt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTakeAtt.Logics
{
    internal class CourseManager
    {
        public List<Course> GetSubjects()
        {
            using (var context = new APContext())
            {
                return context.Courses.ToList();
            }
        }
    }
}

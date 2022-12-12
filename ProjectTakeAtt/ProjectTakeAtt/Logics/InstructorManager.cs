using ProjectTakeAtt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTakeAtt.Logics
{
    internal class InstructorManager
    {
        public List<Instructor> GetSubjects()
        {
            using (var context = new APContext())
            {
                return context.Instructors.ToList();
            }
        }
    }
}

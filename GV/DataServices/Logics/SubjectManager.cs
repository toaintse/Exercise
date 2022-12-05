using DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Logics
{
    public class SubjectManager
    {
        public List<Subject> GetSubjects()
        {
            using (var context = new APContext())
            {
                return context.Subjects.ToList();
            }
        }
    }
}

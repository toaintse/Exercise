using Microsoft.EntityFrameworkCore;
using ProjectPRN.Models;
using System;

namespace ProjectPRN.Logics
{
    public class RollCallBookManager
    {
        APContext context = new APContext();


        public List<RollCallBook> GetStudents(int? stuId)
        {
            List<RollCallBook> students = context.RollCallBooks.Include(x => x.Student).Where(x => x.StudentId == stuId).ToList();
            return students;
        }
    }
}

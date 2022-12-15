using Microsoft.AspNetCore.Mvc;
using ProjectPRN.Logics;
using ProjectPRN.Models;
using System;

namespace ProjectPRN.Controllers
{
    public class RollCallBookController : Controller
    {
        public IActionResult ViewAtt(int? stuId)
        {
            RollCallBookManager rcbManager = new RollCallBookManager();
            StudentManager studentManager = new StudentManager();
            if (stuId != 0)
            {
                List<RollCallBook> students = rcbManager.GetStudents(stuId);
                ViewBag.Students = students;
                Student stus = studentManager.GetStudent(stuId);
                ViewBag.Stus = stus;
            }

            return View("View");
        }
    }
}

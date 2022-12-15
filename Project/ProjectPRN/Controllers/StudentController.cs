using Microsoft.AspNetCore.Mvc;
using ProjectPRN.Logics;
using ProjectPRN.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using System.Security.Cryptography;

namespace ProjectPRN.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int? stuId, int pageIndex, string? nameSearch)
        {
            int totalPages, totalItems, pageSize = 20;
            StudentManager studentManager = new StudentManager();
            if (String.IsNullOrEmpty(nameSearch)) nameSearch = "";
            if (stuId == null || stuId < 0) stuId = 0;
            totalItems = studentManager.GetTotalNumberOrders(stuId,nameSearch);
            totalPages = (totalItems - 1) / pageSize + 1;
            if (pageIndex < 1 || pageIndex > totalPages || pageIndex == null) pageIndex = 1;
            List<Student> students = studentManager.GetStudents(stuId, (pageIndex - 1) * pageSize + 1, pageSize, nameSearch);

            ViewBag.Students = students;
            ViewBag.CurPage = pageIndex;
            ViewBag.TotalPages = totalPages;
            return View("Index",students);
        }
        public IActionResult Add(int stuId)
        {
            StudentManager studentManager = new StudentManager();
            if (stuId != 0)
            {
                Student student = studentManager.GetStudent(stuId);
                return View("Add",student);
            }
            else
            {
                return View("Add");
            }
        }

        public IActionResult DoCreate(Student student)
        {
            StudentManager studentManager = new StudentManager();
            if (student.StudentId == 0)
                studentManager.InsertStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int stuId)
        {
            StudentManager studentManager = new StudentManager();
            Student student = studentManager.GetStudent(stuId);
            ViewBag.Student = student;
            ViewBag.stuId = stuId;
            return View("Edit");
        }
        public IActionResult DoEdit(int stuId, string firstName, string midName, string lastName)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.EditStudent(stuId,firstName,midName,lastName);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int stuId)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.RemoveStudent(stuId);
            return RedirectToAction("Index");
        }
        
        
    }
}

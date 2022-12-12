using BT1212.Logics;
using BT1212.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT1212.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult List(int? birthYear, string? country, int? reportTo)
        {
            Manager manager = new Manager();
            
            if(birthYear == null)
            {
                birthYear = 0;
            }
            if(country == null)
            {
                country = "";
            }
            if(reportTo == null)
            {
                reportTo = 0;
            }
            List<int> years = new List<int>();
            for(int i = 1937; i <= 2000; i++)
            {
                years.Add(i);
            }

            List<Employee> employees = manager.GetEmployees(birthYear, country, reportTo);
            List<Employee> reportToo = manager.GetEmployees();
            
            string[] counstries = { "USA", "UK", "VN" };

            ViewBag.CurBirthYear = birthYear;
            ViewBag.CurCountry = country;
            ViewBag.CurReportTo = reportTo;

            ViewBag.BirthYears = years;
            ViewBag.Counstries = counstries;
            ViewBag.ReportTo = reportToo;

            ViewBag.Employees = employees; 
            return View();
        }

        public IActionResult Create(int id)
        {
            Manager manager = new Manager();
            if (id == 0)
            {
                return View();
            }
            else
            {
                Employee e = manager.GetEmployee(id);
                return View();
            }
        }

        public IActionResult DoDelete(int id)
        {
            Manager manager = new Manager();
            manager.DeleteEmployee(id);
            return RedirectToAction("List");
        }

    }
}

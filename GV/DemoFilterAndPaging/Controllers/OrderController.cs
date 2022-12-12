using DemoFilterAndPaging.Logics;
using DemoFilterAndPaging.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoFilterAndPaging.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult List(int empId, string cusId, DateTime fromDate, DateTime toDate, int pageIndex)
        {
            int totalPages, totalItems, pageSize = 50;
            if (fromDate == DateTime.MinValue) fromDate = new DateTime(1990, 1, 1);
            if (toDate == DateTime.MinValue) toDate = DateTime.Now;
            //getdata
            Manager manager = new Manager();
            totalItems = manager.GetTotalNumberOrders(empId, cusId, fromDate, toDate);
            totalPages = (totalItems - 1) / pageSize + 1;
            if (pageIndex < 1 || pageIndex > totalPages) pageIndex = 1;
            List<Order> orders = manager.GetOrders(empId, cusId, fromDate, toDate, (pageIndex -1) * pageSize + 1, pageSize);
            List<Employee> employees = manager.GetEmployees();
            List<Customer> customers = manager.GetCustomers();

            //send data
            ViewBag.Employees = employees;
            ViewBag.Customers = customers;
            ViewBag.CurEmployee = empId;
            ViewBag.CurCustomer = cusId;
            ViewBag.CurFromDate = fromDate.ToString("yyyy-MM-dd") ;
            ViewBag.CurToDate = toDate.ToString("yyyy-MM-dd");
            ViewBag.CurPage = pageIndex;
            ViewBag.TotalPages = totalPages;
            return View("/Views/Order/List2.cshtml", orders);
        }
    }
}

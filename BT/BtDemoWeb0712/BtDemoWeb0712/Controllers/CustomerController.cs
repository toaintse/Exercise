using BtDemoWeb0712.Models;
using Microsoft.AspNetCore.Mvc;
using BtDemoWeb0712.Logics;

namespace BtDemoWeb0712.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(string id)
        {
            Manager manager = new Manager();
            Customer customer = manager.GetCustomer(id);
            ViewBag.CurCustomer = customer;
            ViewData["id"] = id;
            //ViewBag.Name = name;
            return View();
        }
    }
}

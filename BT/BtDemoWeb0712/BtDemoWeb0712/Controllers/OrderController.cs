using BtDemoWeb0712.Logics;
using BtDemoWeb0712.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BtDemoWeb0712.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            Manager manager = new Manager();
            Order order = manager.GetOrder(id);
            ViewBag.CurOrder = order;
            ViewData["id"] = id;
            //ViewBag.Name = name;
            return View();
        }
    }
}

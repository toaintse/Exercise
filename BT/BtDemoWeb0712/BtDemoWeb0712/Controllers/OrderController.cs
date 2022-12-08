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

        public IActionResult GetOrder(int? orderId)
        {
            Manager manager = new Manager();
            ViewBag.Order = manager.GetOrder(orderId);
            return View();
        }

        public IActionResult Detail(int id)
        {
            Manager manager = new Manager();
            Order order = manager.GetOrder(id);
            ViewBag.CurOrder = order;
            ViewBag.OrderList = manager.GetOrderDetails(id);
            ViewBag.ProductList = manager.GetProducts(0);
            ViewData["id"] = id;
            //ViewBag.Name = name;
            return View();
        }

        public IActionResult DoDelete(int id, int cid)
        {
            Manager manager = new Manager();
            manager.RemoveQuantity(id, cid);
            return RedirectToAction("Detail");
        }
    }
    }


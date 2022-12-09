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

        public IActionResult Create(int id)
        {
            Manager manager = new Manager();
            ViewBag.Categories = manager.GetCategories();
            ViewBag.Suppliers = manager.GetSuppliers();
            if (id == 0)
            {
                return View();
            }
            else
            {
                Product p = manager.GetProduct(id);
                return View(p);
            }


        }

        public IActionResult DoCreate(Product product)
        {
            Manager manager = new Manager();
            if (product.ProductId == 0)
                manager.InsertProduct(product);
            else manager.EditProduct(product);
            return RedirectToAction("Detail");
        }

        public IActionResult Edit(int id, int cid)
        {
            Manager manager = new Manager();
            OrderDetail orderDetail = manager.GetOrderDetail(id, cid);
            ViewBag.OrderDetail = orderDetail;
            ViewBag.productid = id;
            ViewBag.orderid = cid;
            return View();
        }

        public IActionResult DoEdit(int id, int cid,int quantity)
        {
            Manager manager = new Manager();
            manager.EditQuantity(id, cid, quantity);
            
            return RedirectToAction("Detail");
        }

        public IActionResult DoDelete(int id, int cid)
        {
            Manager manager = new Manager();
            manager.RemoveQuantity(id, cid);
            return RedirectToAction("Detail");
        }
    }
    }


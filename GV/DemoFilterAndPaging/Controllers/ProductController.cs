using DemoFilterAndPaging.Logics;
using DemoFilterAndPaging.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoFilterAndPaging.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            Manager manager = new Manager();
            List<Product> products = manager.GetProducts();
            return View(products);
        }

        public IActionResult AddToCart(int id)
        {
            Manager manager = new Manager();
            if (manager.ExistsProduct(id))
            {
                //dem id add vao cart
                //1. Lay du lieu cart hien tai trong session ra

                List<int> cart;
                if (HttpContext.Session.GetString("cart") == null)
                {
                    cart = new List<int>();
                }
                else
                {
                    string data = HttpContext.Session.GetString("cart");
                    cart = JsonSerializer.Deserialize<List<int>>(data);
                }
                //2. Them moi id vao cart
                cart.Add(id);
                //3. Dem cart luu lai vao session
                HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
            }            

            return RedirectToAction("List");
        }

        public IActionResult ViewCart()
        {
            Manager manager = new Manager();
            List<int> cart;
            if (HttpContext.Session.GetString("cart") == null)
            {
                cart = new List<int>();
            }
            else
            {
                string data = HttpContext.Session.GetString("cart");
                cart = JsonSerializer.Deserialize<List<int>>(data);
            }
            List<Product> products = manager.GetProducts(cart);
            return View(products);
        }
    }
}

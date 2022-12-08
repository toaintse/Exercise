using FirstWebApp.Logics;
using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class ProductController : Controller
    {
        public void Index()
        {

        }

        public IActionResult List(int id)
        {
            Manager manager = new Manager();
            List<Product> products = manager.GetProducts(id);
            ViewBag.CurCategory = id;
            return View(products);
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
            return RedirectToAction("List");
        }

        public IActionResult DoDelete(int id, int cid)
        {
            Manager manager = new Manager();
            manager.DeleteProduct(id);
            return RedirectToAction("List", new {id=cid});
        }

        public IActionResult Detail(int id, string name)
        {
            Manager manager = new Manager();
            Product product = manager.GetProduct(id);
            ViewBag.CurProduct = product;
            ViewData["id"] = id;
            ViewBag.Name = name;
            return View();//tra ve view mac dinh cua action.
            //La: /Views/Product/Detail.cshtml
            //return View("/Views/Norule.cshtml");
        }

        public IActionResult ViewProduct(int id)
        {
            Manager manager = new Manager();
            Product product = manager.GetProduct(id);

            return View(product);// set Model = product
        }

    }
}

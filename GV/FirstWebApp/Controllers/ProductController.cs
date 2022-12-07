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

        public string List(int id, string name)
        {
            return $"Category: {id}, name: {name}" ;
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
    }
}

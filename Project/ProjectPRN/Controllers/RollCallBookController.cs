using Microsoft.AspNetCore.Mvc;
using ProjectPRN.Logics;
using ProjectPRN.Models;

namespace ProjectPRN.Controllers
{
    public class RollCallBookController : Controller
    {
        public IActionResult ViewAtt()
        {
            RollCallBookManager rcbManager = new RollCallBookManager();
            StudentManager studentManager = new StudentManager();
            ViewBag.Students = ;
            ViewBag.RCBs = rcbManager.GetRCB();
            return View("View");
        }
    }
}

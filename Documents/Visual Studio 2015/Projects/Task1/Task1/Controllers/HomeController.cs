using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            ViewBag.Message = "Your User List";

            return View();
        }

        public ActionResult CustomerList()
        {
            ViewBag.Message = "Your customer List.";

            return View();
        }
    }
}
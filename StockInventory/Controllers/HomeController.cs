using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockInventory.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["login"] != null)
                return View();
            else
                return RedirectToAction("Index", "Login");
        }
    }
}
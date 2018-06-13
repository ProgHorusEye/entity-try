using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace entity_try.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["nom"] = "MyHorusEye";
            ViewBag.Humeur = "heureux";

            return View();
        }
    }
}
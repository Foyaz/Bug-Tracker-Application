using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTrackerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
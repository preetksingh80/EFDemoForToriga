using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = ConfigurationManager.AppSettings["Title"];
            return View();
        }

        public ActionResult Data()
        {
            return View();
        }
    }
}

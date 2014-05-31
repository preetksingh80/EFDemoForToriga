using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entities;
using Core.Services;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = ConfigurationManager.AppSettings["Title"];
            return View();
        }

        [UsesDatabase]
        public ActionResult Data()
        {
            var dataService = System.Web.HttpContext.Current.Items["DataService"] as IMyDataService<MyData>;
            var data = dataService.GetAll();
            var isDataFromDb = ConfigurationManager.AppSettings["DataService"] == "DB";
            var viewModel = new DataViewModel()
                {
                    Title = ConfigurationManager.AppSettings["DataViewTitle"] + (isDataFromDb? " From Database " : " From Memory"),
                    Data = data,
                    ColumnHeadings = new[]{"Id", "Column1", "Column2", "Column3"}
                };
            return View(viewModel);
        }
    }

    
}
using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class HomeController : Controller
    {
        private Models.CarDataBaseEntities db = new Models.CarDataBaseEntities();
        public ActionResult Index()
        {
            var Items = db.Brands;
            ViewBag.brand = Items;
            return View();
        }

    
    }
}
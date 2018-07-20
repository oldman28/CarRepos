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
       // [HttpGet]
        public ActionResult Models(int id)
        {
            var item = db.Models.Where(p => p.BrandsId == id).ToList();
            return View(item);
        }
        /*[HttpPost]
        public ActionResult Models()
        {
            var Items = db.Models;
            ViewBag.model = Items;
            return View();
        }*/
    }
}
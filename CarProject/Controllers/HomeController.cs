using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Models(int id)
        {
            var item = db.Models.Where(p => p.BrandsId == id).ToList();
            return View(item);
        }
        public ActionResult Parts(int id)
        {
            var item = db.Parts.Where(p => p.ModelsId == id).ToList();
            return View(item);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        public ActionResult Create()
        {
            ViewBag.ModelsId = new SelectList(db.Models, "Id", "ModelsName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartsName,ModelsId,Price")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelsId = new SelectList(db.Models, "Id", "ModelsName", part.ModelsId);
            return View(part);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelsId = new SelectList(db.Models, "Id", "ModelsName", part.ModelsId);
            return View(part);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartsName,ModelsId,Price")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelsId = new SelectList(db.Models, "Id", "ModelsName", part.ModelsId);
            return View(part);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = db.Parts.Find(id);
            db.Parts.Remove(part);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
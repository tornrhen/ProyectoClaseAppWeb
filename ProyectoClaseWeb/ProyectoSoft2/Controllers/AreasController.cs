using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSoft2.DB;

namespace ProyectoSoft2.Controllers
{
    [Authorize]
    public class AreasController : Controller
    {
        private courageproEntities db = new courageproEntities();
        
        public ActionResult Index()
        {
            return View(db.Areas.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Areas areas = db.Areas.Find(id);
            if (areas == null)
            {
                return HttpNotFound();
            }
            return View(areas);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArea,NombreArea")] Areas areas)
        {
            if (ModelState.IsValid)
            {
                db.Areas.Add(areas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areas);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Areas areas = db.Areas.Find(id);
            if (areas == null)
            {
                return HttpNotFound();
            }
            return View(areas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArea,NombreArea")] Areas areas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areas);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Areas areas = db.Areas.Find(id);
            if (areas == null)
            {
                return HttpNotFound();
            }
            return View(areas);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Areas areas = db.Areas.Find(id);
            db.Areas.Remove(areas);
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

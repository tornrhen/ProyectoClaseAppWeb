using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSoft2.DB;
using ProyectoSoft2.Models.Centro;
using ProyectoSoft2.Models.Base;

namespace ProyectoSoft2.Controllers
{
    [Authorize]
    public class CentrosController : Controller
    {
        [HttpGet]
        public ActionResult MostrarModalListaAreas(int id)
        {
                using (var context = new courageproEntities())
                {
                    ViewBag.IdCentro = id;
                    var list = context.Areas.Select(x => new ListaAreasAsignadasACentroViewModel {IdArea=x.IdArea, Nombre = x.NombreArea, EstaAsignado = x.AreasPorCentro.Any(y=>y.IdCentro==id)}).ToList();
                    return PartialView(list);
                }
        }

        [HttpPost]
        public ActionResult GuardarAsignacionDeAreas(List<int> Lista, int IdCentro)
        {
            using (var context = new courageproEntities())
            {
                var listaAborrar = context.AreasPorCentro.Where(x => x.IdCentro == IdCentro).ToList();
                context.AreasPorCentro.RemoveRange(listaAborrar);
                if (Lista != null) Lista.ForEach(x => context.AreasPorCentro.Add(new AreasPorCentro { IdArea = x, IdCentro = IdCentro }));
                var resultado = context.SaveChanges() > 0;
                return Json(new MensajeRespuestaViewModel
                {
                    Titulo = "Asignar Areas a Centro",
                    Mensaje = resultado ? "Se guardo Satisfactoriamente" : "Error al guardar",
                    Estado = resultado
                }, JsonRequestBehavior.AllowGet);
              
            }
        }






        private courageproEntities db = new courageproEntities();

        // GET: Centros
        public ActionResult Index()
        {
            return View(db.Centros.ToList());
        }

        // GET: Centros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centros centros = db.Centros.Find(id);
            if (centros == null)
            {
                return HttpNotFound();
            }
            return View(centros);
        }

        // GET: Centros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Centros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCentro,NombreCentro,Direccion")] Centros centros)
        {
            if (ModelState.IsValid)
            {
                db.Centros.Add(centros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centros);
        }

        // GET: Centros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centros centros = db.Centros.Find(id);
            if (centros == null)
            {
                return HttpNotFound();
            }
            return View(centros);
        }

        // POST: Centros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCentro,NombreCentro,Direccion")] Centros centros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centros);
        }

        // GET: Centros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centros centros = db.Centros.Find(id);
            if (centros == null)
            {
                return HttpNotFound();
            }
            return View(centros);
        }

        // POST: Centros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Centros centros = db.Centros.Find(id);
            db.Centros.Remove(centros);
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

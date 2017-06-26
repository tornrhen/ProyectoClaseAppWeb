using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSoft2.DB;
using ProyectoSoft2.Models.Curso;
using ProyectoSoft2.Models.Base;

namespace ProyectoSoft2.Controllers
{
    [Authorize]
    public class CursosController : Controller
    {

        //Asignar Modulos a Curso
        [HttpGet]
        public ActionResult MostrarModalListaModulos(int id)
        {
            using (var context = new courageproEntities())
            {
                ViewBag.IdCurso = id;
                var list = context.Modulos.Select(x => new ListaModulosAsignadosACurso { IdModulo = x.IdModulo, Nombre = x.NombreModulo, EstaAsignado = x.ModulosPorCurso.Any(y => y.IdCurso == id) }).ToList();
                return PartialView(list);
            }
        }

        [HttpPost]
        public ActionResult GuardarAsignacionDeModulosACurso(List<int> Lista, int IdCurso)
        {
            try
            {
                using (var context = new courageproEntities())
                {
                   // var listaAborrar = context.ModulosPorCurso.Where(x => x.IdCurso == IdCurso).ToList();
                  //  context.ModulosPorCurso.RemoveRange(listaAborrar);
                    if (Lista != null) Lista.ForEach(x =>
                    { if (!context.ModulosPorCurso.Any(y => y.IdModulo == x && y.IdCurso == IdCurso)) context.ModulosPorCurso.Add(new ModulosPorCurso { IdModulo = x, IdCurso = IdCurso }); }
                    );
                    var resultado = context.SaveChanges() > 0;
                    return Json(new MensajeRespuestaViewModel
                    {
                        Titulo = "Asignar Modulo a Curso",
                        Mensaje = resultado ? "Se guardo Satisfactoriamente" : "Error al guardar",
                        Estado = resultado
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new MensajeRespuestaViewModel
                {
                    Titulo = "Error al asignar Modulo a Curso",
                    Mensaje = e.InnerException.Message,
                    Estado = false
                }, JsonRequestBehavior.AllowGet);
            }

        }

        //[HttpPost]
        //public ActionResult GuardarAsignacionDeAlumnosACurso(List<int> Lista, int IdCurso)
        //{
        //    using (var context = new courageproEntities())
        //    {
        //        var listaAborrar = context.AlumnoPorCurso.Where(x => x.IdCurso == IdCurso).ToList();
        //        context.AlumnoPorCurso.RemoveRange(listaAborrar);
        //        if (Lista != null) Lista.ForEach(x => context.AlumnoPorCurso.Add(new AlumnoPorCurso { IdUsuario = x, IdCurso = IdCurso }));
        //        var resultado = context.SaveChanges() > 0;
        //        return Json(new MensajeRespuestaViewModel
        //        {
        //            Titulo = "Asignar Alumno a Curso",
        //            Mensaje = resultado ? "Se guardo Satisfactoriamente" : "Error al guardar",
        //            Estado = resultado
        //        }, JsonRequestBehavior.AllowGet);

        //    }
        //}

        ////Asignar Instructor a Curso
        //[HttpGet]
        //public ActionResult MostrarModalListaInstructor(int id)
        //{
        //    using (var context = new courageproEntities())
        //    {
        //        ViewBag.IdCurso = id;
        //        var list = context.Usuarios.Where(x => x.AspNetUsers.AspNetRoles.Any(y => y.Name == "Instructor")).Select(x => new ListaIntructorAsignadoACurso { IdInstructor = x.IdUsuario, Nombre = x.Nombre + " " + x.Apellido, EstaAsignado = x.InstructorPorCurso.Any(y => y.IdCurso == id) }).ToList();
        //        return PartialView(list);
        //    }

        //}

        //[HttpPost]
        //public ActionResult GuardarAsignacionDeInstructorACurso(List<int> Lista, int IdCurso)
        //{
        //    using (var context = new courageproEntities())
        //    {
        //        var listaAborrar = context.InstructorPorCurso.Where(x => x.IdCurso == IdCurso).ToList();
        //        context.InstructorPorCurso.RemoveRange(listaAborrar);
        //        if (Lista != null) Lista.ForEach(x => context.InstructorPorCurso.Add(new InstructorPorCurso { IdUsuario = x, IdCurso = IdCurso }));
        //        var resultado = context.SaveChanges() > 0;
        //        return Json(new MensajeRespuestaViewModel
        //        {
        //            Titulo = "Asignar Instructor a Curso",
        //            Mensaje = resultado ? "Se guardo Satisfactoriamente" : "Error al guardar",
        //            Estado = resultado
        //        }, JsonRequestBehavior.AllowGet);

        //    }
        //}

        private courageproEntities db = new courageproEntities();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.Areas);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "NombreArea");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCurso,NombreCurso,IdArea")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "NombreArea", cursos.IdArea);
            return View(cursos);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "NombreArea", cursos.IdArea);
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCurso,NombreCurso,IdArea")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArea = new SelectList(db.Areas, "IdArea", "NombreArea", cursos.IdArea);
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
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

using ProyectoSoft2.DB;
using ProyectoSoft2.Models.Base;
using ProyectoSoft2.Models.Matricula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
    public class MatriculaController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new courageproEntities())
            {
                var lista = context.MatriculaCurso.Select(x=> new ListaMatriculaViewModel {
                    Centro = x.Centros.NombreCentro,
                    Curso = x.Cursos.NombreCurso,
                    NombreUsuario = x.Usuarios.Nombre +" "+ x.Usuarios.Apellido,
                    EsAlumno = x.Usuarios.AspNetUsers.AspNetRoles.Any(y=>y.Name=="Alumno"),
                    Estado = x.Estado,
                    Id = x.Id
                }).ToList();
                return View(lista);
            }              
        }
        
        public ActionResult Create()
        {
            using (var context = new courageproEntities())
            {
                ViewBag.ListaCentros = context.Centros.Select(x => new SelectListItem { Value = x.IdCentro.ToString(), Text = x.NombreCentro }).ToList();
                ViewBag.ListaUsuarios = context.Usuarios.Select(x => new SelectListItem { Value = x.IdUsuario.ToString(), Text = x.Nombre +" "+ x.Apellido}).ToList();
                ViewBag.ListaCursos = new List<SelectListItem>();
                return View();
            }   
        }

        public ActionResult GetListaCurso(int id)
        {
            using (var context = new courageproEntities())
            {
                var list = context.Cursos.Where(x => x.Areas.AreasPorCentro.Any(y => y.IdCentro == id)).Select(x => new { id = x.IdCurso.ToString(), text = x.Areas.NombreArea+" / "+ x.NombreCurso, }).ToList();
                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Create(MatriculaViewModel model)
        {
            using (var context = new courageproEntities())
            {
                if (context.MatriculaCurso.Any(x => x.IdCurso == model.IdCurso && x.IdUsuario == model.IdUsuario)) return Json(new MensajeRespuestaViewModel
                {
                    Titulo = "Registrar",
                    Mensaje = "El Usuario ya esta registrado en este curso",
                    Estado = false
                }, JsonRequestBehavior.AllowGet);
                var usuario = context.Usuarios.Find(model.IdUsuario);
                context.MatriculaCurso.Add(new MatriculaCurso {
                    IdUsuario = model.IdUsuario,
                    IdCurso = model.IdCurso,
                    IdCentro = model.IdCentro,
                    EsAlumno = usuario.AspNetUsers.AspNetRoles.Any(y => y.Name == "Alumno"),
                    Estado = true,
                });
                var resultado = context.SaveChanges() > 0;
                return Json(new MensajeRespuestaViewModel
                {
                    Titulo = "Crear Matricula",
                    Mensaje = resultado ? "Se creo Satisfactoriamente" : "Error al crear la Matricula",
                    Estado = resultado
                }, JsonRequestBehavior.AllowGet);
            }
        }
  
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

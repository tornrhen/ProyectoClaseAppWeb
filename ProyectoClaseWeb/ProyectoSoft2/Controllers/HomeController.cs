using ProyectoSoft2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
   
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        courageproEntities conexion = new courageproEntities();
        [HttpGet]
        public ActionResult MostrarModulosMatriculados()
        {
                var idusuario = ObtenerIdUsuario();
                var listModulos = conexion.Cursos.Where(y => y.MatriculaCurso.Any(z => z.IdUsuario == idusuario)).ToList();
                return PartialView(listModulos);
        }

        public ActionResult MostrarModulosMatriculadosInstructor()
        {
            var idusuario = ObtenerIdUsuario();
            var listModulos = conexion.Cursos.Where(y => y.MatriculaCurso.Any(z => z.IdUsuario == idusuario)).ToList();
            return PartialView(listModulos);
        }


    }
}
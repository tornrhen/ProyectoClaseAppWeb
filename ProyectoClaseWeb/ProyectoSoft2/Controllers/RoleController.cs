using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoSoft2.DB;
using ProyectoSoft2.Models;
using ProyectoSoft2.Models.Base;
using ProyectoSoft2.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ControllerName = "Role";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            using (var context = new courageproEntities())
            {
                var jsonResult = Json(context.AspNetRoles.Select(x => new RoleViewModel { Id = x.Id, NombreRole = x.Name }).ToList(), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = Int32.MaxValue;
                return jsonResult;
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return PartialView("CrearRole",new RoleViewModel { Accion="Crear"});
        }

        [HttpPost]
        public ActionResult Crear(RoleViewModel model)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (roleManager.RoleExists(model.NombreRole.Trim())) return Json(new MensajeRespuestaViewModel{Titulo = "Crear Rol", Mensaje =  "El Rol ya Existe", Estado = false}, JsonRequestBehavior.AllowGet);
            var result =  roleManager.Create(new IdentityRole { Name = model.NombreRole.Trim() });
            return Json(new MensajeRespuestaViewModel { Titulo = "Crear Rol",  Mensaje = result.Succeeded ? "Se creo Satisfactoriamente" : "Error al crear el Rol: "+result.Errors.FirstOrDefault(), Estado = result.Succeeded}, JsonRequestBehavior.AllowGet);                    
        }
        
        [HttpGet]
        public ActionResult Editar(string Id)
        {
            using (var context = new courageproEntities())
            {
                var role = context.AspNetRoles.Find(Id);
                return PartialView("CrearRole", new RoleViewModel { Id = role.Id, NombreRole = role.Name, Accion="Editar" });
            }
        }

        [HttpPost]
        public ActionResult Editar(RoleViewModel model)
        {
            using (var context = new courageproEntities())
            {
                var rol = context.AspNetRoles.Find(model.Id);
                rol.Name = model.NombreRole;
                var result = context.SaveChanges() > 0;
                return Json(new MensajeRespuestaViewModel { Titulo = "Editar Rol", Mensaje = result ? "Se edito Satisfactoriamente" : "Error al editar " , Estado = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string Id)
        {
            using (var context = new courageproEntities())
            {         
                var rol = context.AspNetRoles.Find(Id);
                context.AspNetRoles.Remove(rol);         
                var result = context.SaveChanges() > 0;
                return Json(new MensajeRespuestaViewModel { Titulo = "Eliminar Rol", Mensaje = result ? "Se elimino Satisfactoriamente" : "Error al eliminar ", Estado = result }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
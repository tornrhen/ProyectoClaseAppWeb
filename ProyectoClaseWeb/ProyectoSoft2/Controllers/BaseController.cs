using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
    public class BaseController : Controller
    {
        [Authorize]

        public int ObtenerIdUsuario()
        {
            using (var context = new ProyectoSoft2.DB.courageproEntities())
            {
                return context.Usuarios.FirstOrDefault(x => x.AspNetUsers.UserName == User.Identity.Name)?.IdUsuario ?? 0;
            }
        }
    }
}
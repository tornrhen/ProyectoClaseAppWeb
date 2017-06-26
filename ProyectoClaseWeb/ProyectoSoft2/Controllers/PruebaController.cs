using ProyectoSoft2.DB;
using ProyectoSoft2.Models.Prueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSoft2.Controllers
{
    public class PruebaController : BaseController
    {
       [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MostrarCrearPrueba(int id)
        {
            using (var context = new courageproEntities())
            {
                ViewBag.IdModulo = id;
                return View();
            }
        }

        [HttpGet]
        public ActionResult MostrarSeleccionPreguntasParaPrueba(int IdModulo)
        {
            using (var context = new courageproEntities())
            {
                var listapreguntas = context.Preguntas.Where(x => x.Estado).Select(x => new SeleccionPreguntaViewModel {
                    Id = x.IdPregunta,
                    Pregunta = x.Descripcion,
                    Seleccionado = false
                }).ToList();
                return PartialView(listapreguntas);
            }
        }
        [HttpPost]
        public ActionResult MostrarPreguntaEnCreacionPrueba(List<int> Lista)
        {
            using (var context = new courageproEntities())
            {
                var ListaPreguntas = new List<PreguntaConRespuestaViewModel>();
                foreach (var IdPregunta in Lista)
                {
                    var pregunta = context.Preguntas.Find(IdPregunta);
                    ListaPreguntas.Add(new PreguntaConRespuestaViewModel {
                        Id = pregunta.IdPregunta,
                        Pregunta = pregunta.Descripcion,
                        ListaRespuestas = pregunta.Respuestas.Select(x=>new RespuestaViewModel {
                            IdRespuesta = x.IdRespuesta,
                            Respuesta = x.Descripcion,
                            RespuestaCorrecta = x.RespuestaCorrecta
                        }).ToList()
                    });
                }
                return PartialView(ListaPreguntas);
            }
        }

        [HttpGet]
        public ActionResult MostrarCrearPregunta(int IdModulo)
        {
            return PartialView(new PreguntaConRespuestaViewModel { IdModulo=IdModulo});
        }

        [HttpPost]
        public ActionResult CrearPregunta(PreguntaViewModel model, List<RespuestaViewModel> ListaRespuestas)
        {
            using (var context = new courageproEntities())
            {
                var pregunta = context.Preguntas.Add(new Preguntas
                {
                    Descripcion = model.Pregunta,
                    IdModulo = model.IdModulo,
                    Estado = true,
                });
                foreach (var resp in ListaRespuestas)
                {
                    if (resp.Respuesta != null)
                    {
                        context.Respuestas.Add(new Respuestas
                        {
                            Descripcion =resp.Respuesta,
                            RespuestaCorrecta = resp.RespuestaCorrecta,
                            IdPregunta = pregunta.IdPregunta,
                    });
                    }
                }
                return Json(new {resultado = context.SaveChanges()>0, idPregunta= pregunta.IdPregunta }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CrearPrueba(PruebaViewModel model, List<int> ListaPreguntas)
        {
            using (var context = new courageproEntities())
            {
                var prueba = context.Pruebas.Add(new Pruebas
                {
                    Descripcion = model.NombrePrueba,
                    DuracionMin = 10,
                    Estado = true,
                    IdModulo = model.IdModulo,
                });

                foreach (var resp in ListaPreguntas)
                {
                    context.PreguntasPorPrueba.Add(new PreguntasPorPrueba
                    {
                        IdPregunta = resp,
                        IdPrueba = prueba.IdPrueba,
                        Estado = true,
                    });
                }
                return Json(new { resultado = context.SaveChanges() > 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        courageproEntities conexion = new courageproEntities();
        [HttpGet]
        public ActionResult MostrarRealizarPrueba(int id)
        {       
            return View(conexion.Pruebas.Find(id));
        }
    }
}
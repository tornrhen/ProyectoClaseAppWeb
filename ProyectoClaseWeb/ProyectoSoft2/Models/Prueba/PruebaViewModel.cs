using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Prueba
{
    public class PruebaViewModel
    {
        public int IdPrueba { get; set; }
        public string NombrePrueba { get; set; }
        public string NombreCursoModulo { get; set; }
        public int IdModulo { get; set; }
        public List<PreguntaConRespuestaViewModel> ListaPreguntas = new List<PreguntaConRespuestaViewModel>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Prueba
{
    public class PreguntaViewModel
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public int IdModulo { get; set; }
    }
}
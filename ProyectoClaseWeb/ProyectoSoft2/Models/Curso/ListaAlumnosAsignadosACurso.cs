using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Curso
{
    public class ListaAlumnosAsignadosACurso
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public bool EstaAsignado { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Curso
{
    public class ListaIntructorAsignadoACurso
    {
        public int IdInstructor { get; set; }
        public string Nombre { get; set; }
        public bool EstaAsignado { get; set; }
    }
}
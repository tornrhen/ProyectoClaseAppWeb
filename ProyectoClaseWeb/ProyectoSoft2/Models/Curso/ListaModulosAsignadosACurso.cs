using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Curso
{
    public class ListaModulosAsignadosACurso
    {
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public bool EstaAsignado { get; set; }
    }
}
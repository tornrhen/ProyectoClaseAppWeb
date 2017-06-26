using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Matricula
{
    public class ListaMatriculaViewModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Curso { get; set; }
        public string Centro { get; set; }
        public bool Estado { get; set; }
        public bool EsAlumno { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Centro
{
    public class ListaAreasAsignadasACentroViewModel
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public bool EstaAsignado { get; set; }
    }
}
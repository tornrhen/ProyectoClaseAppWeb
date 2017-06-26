using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoft2.Models.Matricula
{
    public class MatriculaViewModel
    {
        public int Id{ get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Display(Name = "Centro")]
        public int IdCentro { get; set; }
        [Required]
        [Display(Name = "Area / Curso")]
        public int IdCurso { get; set; } 
                   
        public bool Estado { get; set; }
      
    }
}
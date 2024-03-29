﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {      
        [Required(ErrorMessage = "Ingrese una condición")]
        public int IDCondicion { get; set; }

        [Range(1, 10, ErrorMessage = "Ingrese una nota entre 1 y 10")]
        public int? Nota { get; set; }

        [Required(ErrorMessage = "Ingrese un alumno")]
        public int IDAlumno { get; set; }

        [Required(ErrorMessage = "Ingrese un curso")]
        public int IDCurso { get; set; }

        public int IDMateria { get; set; }

        public int IDComision { get; set; }

        public int Legajo { get; set; }

        public string DescripcionCurso { get; set; }

        public string NombreApellido { get; set; }
        
        public Usuario Usuario { get; set; }

        public string DescripcionMateria { get; set; }

        public string DescripcionPlan { get; set; }

        public string DescripcionCondicion { get; set; }
    }
}
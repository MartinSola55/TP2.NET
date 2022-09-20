using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese un cargo")]
        public int IDCargo { get; set; }

        [Required(ErrorMessage = "Ingrese un curso")]
        public int IDCurso { get; set; }

        [Required(ErrorMessage = "Ingrese un docente")]
        public int IDDocente { get; set; }

        public string DescripcionCurso { get; set; }
        
        public int IDComision { get; set; }
        
        public int IDMateria { get; set; }

        public Usuario Usuario { get; set; }

        public string DescripcionCargo{ get; set; }

    }
}
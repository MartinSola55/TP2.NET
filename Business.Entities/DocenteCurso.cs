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
        [MinLength(3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z0-9\u00C0-\u017F\s]+$", ErrorMessage = "Sólo se permiten caracteres alfabéticos")]

        public string Cargo { get; set; }

        [Required(ErrorMessage = "Ingrese un curso")]
        public int IDCurso { get; set; }

        [Required(ErrorMessage = "Ingrese un docente")]
        public int IDDocente { get; set; }

        public string DescripcionCurso { get; set; }
        
        public int IDComision { get; set; }
        
        public int IDMateria { get; set; }

        public Usuario Usuario { get; set; }

    }
}
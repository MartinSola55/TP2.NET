using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese una descripción")]
        [MinLength(1, ErrorMessage = "Ingrese un mínimo de 1 caracter")]
        [MaxLength(10, ErrorMessage = "Máximo 30 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z0-9\u00C0-\u017F\s]+$", ErrorMessage = "Sólo se permiten caracteres alfanuméricos")]
        public string Descripcion { get; set; }
    }
}
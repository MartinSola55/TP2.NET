using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese una descripción")]
        [MinLength(3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z0-9\u00C0-\u017F\s]+$", ErrorMessage = "Sólo se permiten caracteres alfanuméricos")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese una especialidad")]
        public int IDEspecialidad { get; set; }

        public string DescripcionEsp { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese una descripción")]
        [MinLength(3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z0-9\u00C0-\u017F\s]+$", ErrorMessage = "Sólo se permiten caracteres alfanuméricos")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad de horas semanales")]
        [Range(1, 20, ErrorMessage = "Ingrese entre 1 y 20 horas")]
        public int HSSemanales { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad de horas totales")]
        [Range(1, 500, ErrorMessage = "Ingrese entre 1 y 500 horas")]
        public int HSTotales { get; set; }

        [Required(ErrorMessage = "Ingrese un plan")]
        public int IDPlan { get; set; }

        public string DescripcionPlan { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        [Required(ErrorMessage ="Complete con un año")]
        [Range(1980, 2023, ErrorMessage = "Complete con un año entre 1980 y 2023")]
        public int AnioEspecialidad { get; set; }

        [Required(ErrorMessage = "Complete con una descripción")]
        [MinLength(3, ErrorMessage = "Ingrese un mínimo de 3 caracteres")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z0-9\u00C0-\u017F\s]+$", ErrorMessage = "Sólo se permiten caracteres alfanuméricos")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un plan")]
        public int IDPlan { get; set; }

        public string PlanDesc { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese un año")]
        [Range(1980, 2023, ErrorMessage = "Complete con un año entre 1980 y 2023")]
        public int AnioCalendario { get; set; }

        [Required(ErrorMessage = "Ingrese un cupo")]
        [Range(1, 500, ErrorMessage = "El cupo debe estar entre 1 y 500 personas")]
        public int Cupo { get; set; }

        [Required(ErrorMessage = "Ingrese una comisión")]
        public int IDComision { get; set; }

        [Required(ErrorMessage = "Ingrese una materia")]
        public int IDMateria { get; set; }

        public string ComisionDesc { get; set; }

        public string MateriaDesc { get; set; }
    }
}
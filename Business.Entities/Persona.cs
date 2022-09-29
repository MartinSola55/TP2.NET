using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese un apelido")]
        [MinLength(1, ErrorMessage = "Ingrese un mínimo de 1 caracter")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u017F\s]+$", ErrorMessage = "Ingrese un apellido válido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre")]
        [MinLength(1, ErrorMessage = "Ingrese un mínimo de 1 caracter")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u017F\s]+$", ErrorMessage = "Ingrese un nombre válido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una dirección")]
        [MinLength(1, ErrorMessage = "Ingrese un mínimo de 1 caracter")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z0-9\u00C0-\u017F\s]+$", ErrorMessage = "Ingrese una dirección válida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese un email")]
        [EmailAddress(ErrorMessage = "Ingrese un formato de email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese un teléfono")]
        [Phone(ErrorMessage = "Ingrese un teléfono válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese una fecha de nacimiento")]
        [RegularExpression("^[0-9]{2}\\/[0-9]{2}\\/[1-2][0-9]{3}$", ErrorMessage = "Ingrese un formato de fecha válido")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Ingrese un número de legajo")]
        [Range(10, 100000, ErrorMessage = "El legajo debe estar entre 10 y 100.000")]
        [RegularExpression("^[1-9][0-9]+$", ErrorMessage = "Sólo se permiten números y no debe comenzar con 0")]
        public int Legajo { get; set; }

        [Required(ErrorMessage = "Ingrese un tipo de persona")]
        public int TipoPersona { get; set; }

        [Required(ErrorMessage = "Ingrese un plan")]
        public int IDPlan { get; set; }

        public string NacimientoString { get; set; }

        public string DescPlan { get; set; }

        public string NombreUsuario { get; set; }
    }
}
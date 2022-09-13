using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        [Required(ErrorMessage = "Ingrese un nombre de usuario")]
        [MinLength(6, ErrorMessage = "Ingrese un mínimo de 6 caracteres")]
        [MaxLength(18, ErrorMessage = "Máximo 18 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_.-]+$", ErrorMessage = "Ingrese un nombre de usuario válido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese una clave")]
        [DataType(DataType.Password, ErrorMessage = "Ingrese una contraseña válida")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Repita su clave")]
        [DataType(DataType.Password, ErrorMessage = "Ingrese una contraseña válida")]
        [Compare(nameof(Clave), ErrorMessage = "Las claves deben ser idénticas")]
        public string RepiteClave { get; set; }

        [Required(ErrorMessage = "Ingrese una persona")]
        public int IDPersona { get; set; }
        
        [Required(ErrorMessage = "No has seleccionado si el usuario está habilitado")]
        public bool Habilitado { get; set; }

        public string Email { get; set; }
        
        public int TipoPersona { get; set; }
    }
}
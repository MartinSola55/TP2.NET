using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Logic
{
    public static class Validaciones
    {
        public static bool esMailValido(string mail)
        {
            return mail != null && Regex.IsMatch(mail, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$"); ;
        }
        public static bool esNombreValido(string nombre)
        {
            return nombre != null && Regex.IsMatch(nombre, @"^[a-zA-Z\u00C0-\u017F\s]+$"); ;
        }
        public static bool esDireccionValida(string nombre)
        {
            return nombre != null && Regex.IsMatch(nombre, @"^[a-zA-Z0-9\u00C0-\u017F\s]+$"); ;
        }
        public static bool esUsuarioValido(string usuario)
        {
            return usuario != null && Regex.IsMatch(usuario, @"^[a-zA-Z0-9\u00C0-\u017F\s]+$"); ;
        }
        public static bool esNumeroValido(string numero)
        {
            return numero != null && Regex.IsMatch(numero, "^[1-9][0-9]+$"); ;
        }
    }
}

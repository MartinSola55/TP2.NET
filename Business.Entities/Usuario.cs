using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private string _Apellido;
        private string _Clave;
        private string _Email;
        private bool _Habilitado;
        private string _Nombre;
        private string _NombreUsuario;

        public string Apellido
        {
            get; set;
        }

        public string Clave
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public bool Habilitado
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }

        public string NombreUsuario
        {
            get; set;
        }
    }
}
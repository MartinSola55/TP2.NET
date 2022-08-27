using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private int _IDPersona;
        private string _Clave;
        private bool _Habilitado;
        private string _NombreUsuario;
        private string _Email;

        public int IDPersona
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

        public string NombreUsuario
        {
            get; set;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private int _TipoPersona;

        public string Apellido
        {
            get; set;
        }

        public string Direccion
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public DateTime FechaNacimiento
        {
            get; set;
        }

        public string NacimientoString
        {
            get; set;
        }

        public int IDPlan
        {
            get; set;
        }

        public string DescPlan
        {
            get; set;
        }

        public int TipoPersona
        {
            get; set;
        }

        public string Telefono
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }

        public int Legajo
        {
            get; set;
        }
    }
}
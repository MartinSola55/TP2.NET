using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        private string _Descripcion;
        private int _ID;

        public string Descripcion
        {
            get; set;
        }
        public int ID
        {
            get;
            set;
        }
    }
}
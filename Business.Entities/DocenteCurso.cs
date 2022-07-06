using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private int _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public int Cargo
        {
            get; set;
        }

        public int IDCurso
        {
            get; set;
        }

        public int IDDocente
        {
            get; set;
        }
    }
}
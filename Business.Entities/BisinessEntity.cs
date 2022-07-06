using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _ID;
        private States _State;

        public BusinessEntity()
        {
            this.State = States.New;
        }

        public int ID
        {
            get; set;
        }

        public States State
        {
            get; set;
        }

        public enum States {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
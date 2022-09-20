using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CondicionLogic : BusinessLogic
    {
        public CondicionAdapter CondicionData { get; set; }
        public CondicionLogic()
        {
            CondicionData = new CondicionAdapter();
        }
        public List<Condicion> GetAll()
        {
            try
            {
                return CondicionData.GetAll();
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public Condicion GetOne(int id)
        {

            try
            {
                return CondicionData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

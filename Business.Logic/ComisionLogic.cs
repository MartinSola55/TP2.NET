using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data.SqlClient;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        public ComisionAdapter ComisionData
        {
            get; set;
        }
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Comision GetOne(int id)
        {

            try
            {
                return ComisionData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }

        public void Save(Comision comision)
        {
            try
            {
                ComisionData.Save(comision);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }

        public void Delete(int id)
        {
            try
            {
                ComisionData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

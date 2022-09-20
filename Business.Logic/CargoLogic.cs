using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CargoLogic : BusinessLogic
    {
        public CargoAdapter CargoData { get; set; }
        public CargoLogic()
        {
            CargoData = new CargoAdapter();
        }
        public List<Cargo> GetAll()
        {
            try
            {
                return CargoData.GetAll();
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public Cargo GetOne(int id)
        {

            try
            {
                return CargoData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

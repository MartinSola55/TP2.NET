using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        public PlanAdapter PlanData
        {
            get; set;
        }
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        public Plan GetOne(int id)
        {

            try
            {
                return PlanData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Save(Plan plan)
        {
            try
            {
                PlanData.Save(plan);
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
                PlanData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Plan> FiltraPlanes(string descripcion)
        {
            try
            {
                return PlanData.FiltraPlanes(descripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public Plan GetByDescripcion(Plan plan)
        {

            try
            {
                return PlanData.GetByDescripcion(plan);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

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
    public class MateriaLogic : BusinessLogic
    {
        public MateriaAdapter MateriaData
        {
            get; set;
        }
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Materia GetOne(int id)
        {

            try
            {
                return MateriaData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }

        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }

        public void Save(Materia materia)
        {
            try
            {
                MateriaData.Save(materia);
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
                MateriaData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Materia> FiltraMaterias(string descripcion)
        {
            try
            {
                return MateriaData.FiltraMaterias(descripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public Materia GetRepetido(Materia materia)
        {

            try
            {
                return MateriaData.GetRepetido(materia);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

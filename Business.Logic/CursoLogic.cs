using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoAdapter CursoData
        {
            get; set;
        }
        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }
        public Curso GetOne(int id)
        {

            try
            {
                return CursoData.GetOne(id);
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Save(Curso curso)
        {
            try
            {
                CursoData.Save(curso);
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Delete(int id)
        {
            try
            {
                CursoData.Delete(id);
            } catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

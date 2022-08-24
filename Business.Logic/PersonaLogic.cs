using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        public PersonaAdapter PersonaData
        {
            get; set;
        }
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }
        public Persona GetOne(int id)
        {

            try
            {
                return PersonaData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void Save(Persona persona)
        {
            try
            {
                PersonaData.Save(persona);
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
                PersonaData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool EsLegajoRepetido(Persona persona)
        {
            try
            {
                return PersonaData.EsLegajoRepetido(persona);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public Persona GetRepetido(Persona persona)
        {
            try
            {
                return PersonaData.GetRepetido(persona);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Persona> GetByLegajo(string nombre, string apellido, string legajo)
        {
            try
            {
                return PersonaData.GetByLegajo(nombre, apellido, legajo);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<Persona> FiltraPersonas(string nombre, string apellido)
        {
            try
            {
                return PersonaData.FiltraPersonas(nombre, apellido);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

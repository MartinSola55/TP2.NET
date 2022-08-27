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
        public AlumnoInscripcionAdapter AlumnoData
        {
            get; set;
        }
        public DocenteCursoAdapter DocenteData
        {
            get; set;
        }
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
            AlumnoData = new AlumnoInscripcionAdapter();
            DocenteData = new DocenteCursoAdapter();
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
        public List<AlumnoInscripcion> GetInscripcionesAlumnno(int id)
        {
            try
            {
                return AlumnoData.GetInscripcionesAlumnno(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<DocenteCurso> GetInscripcionesDocente(int id)
        {
            try
            {
                return DocenteData.GetInscripcionesDocente(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public AlumnoInscripcion GetInscripcionAlumnno(int id)
        {
            try
            {
                return AlumnoData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public DocenteCurso GetInscripcionDocente(int id)
        {
            try
            {
                return DocenteData.GetOne(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool EsInscripcionRepetida(AlumnoInscripcion inscripcion)
        {
            try
            {
                return AlumnoData.EsInscripcionRepetida(inscripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool EsInscripcionRepetida(int idAlumno, int idCurso)
        {
            try
            {
                return AlumnoData.EsInscripcionRepetida(idAlumno, idCurso);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public bool EsInscripcionRepetida(DocenteCurso inscripcion)
        {
            try
            {
                return DocenteData.EsInscripcionRepetida(inscripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void SaveIns(AlumnoInscripcion inscripcion)
        {
            try
            {
                AlumnoData.Save(inscripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void UpdateCondicion(AlumnoInscripcion inscripcion)
        {
            try
            {
                AlumnoData.UpdateCondicion(inscripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void SaveIns(DocenteCurso inscripcion)
        {
            try
            {
                DocenteData.Save(inscripcion);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void DeleteInsAl(int id)
        {
            try
            {
                AlumnoData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public void DeleteInsDoc(int id)
        {
            try
            {
                DocenteData.Delete(id);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
        public List<AlumnoInscripcion> GetAlumnosXCurso(int idCurso, int idMateria, int idComision)
        {
            try
            {
                return AlumnoData.GetAlumnosXCurso(idCurso, idMateria, idComision);
            }
            catch (Exception exceptionManejada)
            {
                throw exceptionManejada;
            }
        }
    }
}

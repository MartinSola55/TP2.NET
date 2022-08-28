using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebMVC.Filter;

namespace UI.WebMVC.Controllers
{
    [Seguridad]
    [Alumno]
    public class InscripcionesAlumnoController : Controller
    {
        private PersonaLogic pl = new PersonaLogic();
        // GET: InscripcionesAlumno
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getOne(int id)
        {
            Persona persona = new Persona();
            try
            {
                persona = pl.GetOne(id);
            }
            catch (Exception e)
            {

            }
            return Json(persona, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInscripciones(int id)
        {
            List<AlumnoInscripcion> ai = new List<AlumnoInscripcion>();
            try
            {
                ai = pl.GetInscripcionesAlumnno(id);
                return Json(ai, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(ai, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInscripcion(int id)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                ai = pl.GetInscripcionAlumnno(id);
                return Json(ai, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(ai, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(int idAlumno, int idCurso)
        {
            string[] respuesta = { "", "" };
            try
            {
                if (!pl.EsInscripcionRepetida(idAlumno, idCurso))
                {
                    AlumnoInscripcion inscripcion = new AlumnoInscripcion();
                    inscripcion.IDAlumno = idAlumno;
                    inscripcion.IDCurso = idCurso;
                    inscripcion.Condicion = "Inscripto";
                    inscripcion.Nota = null;
                    inscripcion.State = BusinessEntity.States.New;
                    pl.SaveIns(inscripcion);
                    respuesta[0] = "La inscripción se guardó correctamente";
                    respuesta[1] = "1";
                }
                else
                {
                    respuesta[0] = "La inscripción que desea guardar ya existe";
                    respuesta[1] = "0";
                }
            }
            catch (Exception ex)
            {
                respuesta[0] = ex.Message;
                respuesta[1] = "0";
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
    }
}
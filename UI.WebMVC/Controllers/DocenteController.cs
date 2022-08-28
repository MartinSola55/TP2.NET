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
    [Docente]
    public class DocenteController : Controller
    {
        private PersonaLogic pl = new PersonaLogic();
        // GET: Docente
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Notas()
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
            List<DocenteCurso> dc = new List<DocenteCurso>();
            try
            {
                dc = pl.GetInscripcionesDocente(id);
                return Json(dc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(dc, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInscripcionAlumno(int id)
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
        public JsonResult GetAlumnosXCurso(int idCurso, int idMateria, int idComision)
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();
            try
            {
                alumnos = pl.GetAlumnosXCurso(idCurso, idMateria, idComision);
                return Json(alumnos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(alumnos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveCondicion(AlumnoInscripcion inscripcion)
        {
            string[] respuesta = { "", "" };
            try
            {
                pl.UpdateCondicion(inscripcion);
                respuesta[0] = "La inscripción se guardó correctamente";
                respuesta[1] = "1";
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
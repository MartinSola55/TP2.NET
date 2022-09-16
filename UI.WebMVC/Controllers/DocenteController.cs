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
        [HttpPost]
        public ActionResult Notas(AlumnoInscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                return View(inscripcion);
            }
            return RedirectToAction(nameof(Inicio));
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
        public JsonResult GetAlumnosXCurso(int idCurso)
        {
            List<AlumnoInscripcion> alumnos = new List<AlumnoInscripcion>();
            try
            {
                alumnos = pl.GetAlumnosXCurso(idCurso);
                return Json(alumnos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(alumnos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveCondicion(AlumnoInscripcion inscripcion)
        {
            try
            {
                inscripcion.State = BusinessEntity.States.Modified;
                pl.UpdateCondicion(inscripcion);
                ViewBag.Message = "La condición se guardó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            return RedirectToAction("/Notas", new { curso = inscripcion.IDCurso, materia = inscripcion.IDMateria, com = inscripcion.IDComision });
        }
    }
}
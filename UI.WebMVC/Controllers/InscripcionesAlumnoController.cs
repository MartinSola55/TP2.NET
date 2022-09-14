using Business.Entities;
using Business.Logic;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebMVC.Filter;

namespace UI.WebMVC.Controllers
{
    public class InscripcionesAlumnoController : Controller
    {
        private CursoLogic cursol = new CursoLogic();
        private PersonaLogic pl = new PersonaLogic();
        // GET: InscripcionesAlumno
        [Seguridad]
        [Alumno]
        public ActionResult Inicio()
        {
            ViewBag.listado = listadoCursos();
            return View();
        }
        [Seguridad]
        [Alumno]
        [HttpPost]
        public ActionResult Inicio(AlumnoInscripcion inscripcion)
        {
            ViewBag.listado = listadoCursos();
            if (ModelState.IsValid)
            {
                return View(inscripcion);
            }
            return RedirectToAction(nameof(Inicio));
        }
        [Seguridad]
        [Alumno]
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
        [Seguridad]
        [Alumno]
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
        [Seguridad]
        [Alumno]
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
        [Seguridad]
        [Alumno]
        public ActionResult Save(AlumnoInscripcion inscripcion)
        {
            try
            {
                if (!pl.EsInscripcionRepetida(inscripcion.IDAlumno, inscripcion.IDCurso))
                {
                    inscripcion.Condicion = "Inscripto";
                    inscripcion.Nota = null;
                    inscripcion.State = BusinessEntity.States.New;
                    pl.SaveIns(inscripcion);
                    ViewBag.Message = "La inscripción se guardó correctamente";
                }
                else
                {
                    ViewBag.Message = "Ya te encuentras inscripto a esta materia";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listado = listadoCursos();
            return View("Inicio");
        }
        [Seguridad]
        [Alumno]
        public IEnumerable<SelectListItem> listadoCursos()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Curso> cursos = cursol.GetAll();
                lista = cursos.Select(c => new SelectListItem { Text = c.AnioCalendario + " - " + c.ComisionDesc + " - " + c.MateriaDesc, Value = c.ID.ToString() });
            }
            catch (Exception e)
            {

            }
            return lista;
        }
        public ActionResult Report(int id)
        {
            List<AlumnoInscripcion> listado = pl.GetInscripcionesAlumnno(id);
            return View(listado);
        }
        [Seguridad]
        [Alumno]
        public ActionResult Print()
        {
            string id = Session["idPer"].ToString();
            var report = new UrlAsPdf("/InscripcionesAlumno/Report/?id=" + id)
            {
                FileName = "Condición alumno.pdf",
            };
            return report;
        }
    }
}
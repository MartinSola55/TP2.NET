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
    [Admin]
    public class PersonasController : Controller
    {
        private PersonaLogic pl = new PersonaLogic();
        private UsuarioLogic ul = new UsuarioLogic();
        private PlanLogic planl = new PlanLogic();
        private CursoLogic cursol = new CursoLogic();
        // GET: Personas
        public ActionResult Inicio()
        {
            ViewBag.listado = listadoPlanes();
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(Persona persona)
        {
            ViewBag.listado = listadoPlanes();
            if (ModelState.IsValid)
            {
                return View(persona);
            }
            return RedirectToAction(nameof(Inicio));
        }
        public ActionResult InscripcionesAlumno()
        {
            ViewBag.listadoCursos = listadoCursos();
            return View();
        }
        [HttpPost]
        public ActionResult InscripcionesAlumno(AlumnoInscripcion inscripcion)
        {
            ViewBag.listadoCursos = listadoCursos();
            if (ModelState.IsValid)
            {
                return View(inscripcion);
            }
            return RedirectToAction(nameof(Inicio));
        }
        public ActionResult InscripcionesDocente()
        {
            ViewBag.listadoCursos = listadoCursos();
            return View();
        }
        [HttpPost]
        public ActionResult InscripcionesDocente(DocenteCurso inscripcion)
        {
            ViewBag.listadoCursos = listadoCursos();
            if (ModelState.IsValid)
            {
                return View(inscripcion);
            }            ViewBag.listadoCursos = listadoCursos();
            return RedirectToAction(nameof(Inicio));
        }
        public JsonResult getAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                personas = pl.GetAll();
            }
            catch (Exception e)
            {

            }
            return Json(personas, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(Persona persona)
        {
            try
            {
                pl.Delete(persona.ID);
                ViewBag.Message = persona.TipoPersona == 1 ? "El docente se eliminó correctamente" : "El alumno se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listado = listadoPlanes();
            return View("Inicio");
        }
        public ActionResult Save(Persona persona)
        {
            try
            {
                if (!pl.EsLegajoRepetido(persona))
                {
                    Persona repetido = pl.GetRepetido(persona);
                    if (repetido.ID == 0)
                    {
                        if (persona.ID == 0)
                        {
                            persona.State = BusinessEntity.States.New;
                            ViewBag.Message = persona.TipoPersona == 1 ? "El docente se guardó correctamente" : "El alumno se guardó correctamente";
                        }
                        else
                        {
                            persona.State = BusinessEntity.States.Modified;
                            ViewBag.Message = persona.TipoPersona == 1 ? "El docente se actualizó correctamente" : "El alumno se actualizó correctamente";
                        }
                        pl.Save(persona);
                    }
                    else
                    {
                        ViewBag.Message = persona.TipoPersona == 1 ? "El docente que desea guardar ya existe" : "El alumno que desea guardar ya existe";
                        ViewBag.Error = 1;
                    }
                } else
                {
                    ViewBag.Message = "El legajo que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listado = listadoPlanes();
            return View("Inicio");
        }
        public JsonResult FiltraPersonas(string nombre, string apellido, string legajo)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                if (legajo != "")
                {
                    personas = pl.GetByLegajo(nombre, apellido, legajo);
                } else
                {
                    personas = pl.FiltraPersonas(nombre, apellido);
                }
                return Json(personas, JsonRequestBehavior.AllowGet);
            } catch (Exception e)
            {
                return Json(personas, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetInscripciones(int id, int tipo)
        {
            List<AlumnoInscripcion> ai = new List<AlumnoInscripcion>();
            List<DocenteCurso> dc = new List<DocenteCurso>();
            try
            {
                if (tipo == 1)
                {
                    dc = pl.GetInscripcionesDocente(id);
                    return Json(dc, JsonRequestBehavior.AllowGet);
                }
                else if (tipo == 2)
                {
                    ai = pl.GetInscripcionesAlumnno(id);
                    return Json(ai, JsonRequestBehavior.AllowGet);
                }
            } catch (Exception e)
            {

            }
            return Json(ai, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInscripcion(int id, int tipo)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            DocenteCurso dc = new DocenteCurso();
            try
            {
                if (tipo == 1)
                {
                    dc = pl.GetInscripcionDocente(id);
                    return Json(dc, JsonRequestBehavior.AllowGet);
                }
                else if (tipo == 2)
                {
                    ai = pl.GetInscripcionAlumnno(id);
                    return Json(ai, JsonRequestBehavior.AllowGet);
                }
            } catch (Exception e)
            {

            }
            return Json(ai, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveInsAl(AlumnoInscripcion inscripcion)
        {
            try
            {
                if (!pl.EsInscripcionRepetida(inscripcion))
                {
                    if (inscripcion.ID == 0)
                    {
                        inscripcion.State = BusinessEntity.States.New;
                        ViewBag.Message = "La inscripción se guardó correctamente";
                    }
                    else
                    {
                        inscripcion.State = BusinessEntity.States.Modified;
                        ViewBag.Message = "La inscripción se actualizó correctamente";
                    }
                    pl.SaveIns(inscripcion);
                }
                else
                {
                    ViewBag.Message = "La inscripción que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoCursos = listadoCursos();
            return RedirectToAction("/InscripcionesAlumno", new { nro = inscripcion.IDAlumno });
        }
        public ActionResult SaveInsDoc(DocenteCurso inscripcion)
        {
            try
            {
                if (!pl.EsInscripcionRepetida(inscripcion))
                {
                    if (inscripcion.ID == 0)
                    {
                        inscripcion.State = BusinessEntity.States.New;
                        ViewBag.Message = "La inscripción se guardó correctamente";
                    }
                    else
                    {
                        inscripcion.State = BusinessEntity.States.Modified;
                        ViewBag.Message = "La inscripción se actualizó correctamente";
                    }
                    pl.SaveIns(inscripcion);
                }
                else
                {
                    ViewBag.Message = "La inscripción que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoCursos = listadoCursos();
            return RedirectToAction("/InscripcionesDocente", new { nro = inscripcion.IDDocente });
        }
        public ActionResult DeleteInsAl(AlumnoInscripcion inscripcion)
        {
            try
            {
                pl.DeleteInsAl(inscripcion.ID);
                ViewBag.Message = "La inscripción se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoCursos = listadoCursos();
            return RedirectToAction("/InscripcionesAlumno", new { nro = inscripcion.IDAlumno });
        }
        public ActionResult DeleteInsDoc(DocenteCurso inscripcion)
        {
            try
            {
                pl.DeleteInsDoc(inscripcion.ID);
                ViewBag.Message = "La inscripción se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoCursos = listadoCursos();
            return RedirectToAction("/InscripcionesDocente", new { nro = inscripcion.IDDocente });
        }
        public ActionResult SaveUser(Usuario usuario)
        {
            try
            {
                if (!ul.EsRepetido(usuario.NombreUsuario))
                {
                    usuario.State = BusinessEntity.States.New;
                    ul.Create(usuario);
                    ViewBag.Message = "El usuario se guardó correctamente";
                } else
                {
                    ViewBag.Message = "El usuario que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoCursos = listadoCursos();
            string tipoPersona = usuario.TipoPersona == 1 ? "Docente" : "Alumno";
            return RedirectToAction("/Inscripciones" + tipoPersona, new { nro = usuario.IDPersona});
        }
        public IEnumerable<SelectListItem> listadoPlanes()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Plan> planes = planl.GetAll();
                lista = planes.Select(p => new SelectListItem { Text = p.Descripcion + " - " + p.DescripcionEsp, Value = p.ID.ToString() });
            }
            catch (Exception e)
            {

            }
            return lista;
        }
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
    }
}
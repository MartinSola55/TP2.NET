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
        // GET: Personas
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult InscripcionesAlumno()
        {
            return View();
        }
        public ActionResult InscripcionesDocente()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Persona> personas = new List<Persona>();
            personas = pl.GetAll();
            return Json(personas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Persona persona = new Persona();
            persona = pl.GetOne(id);
            return Json(persona, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                pl.Delete(id);
                respuesta[0] = "La persona se eliminó correctamente";
                respuesta[1] = "1";
            }
            catch (Exception ex)
            {
                respuesta[0] = ex.Message;
                respuesta[1] = "0";
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(Persona persona)
        {
            string[] respuesta = { "", "" };
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
                        }
                        else
                        {
                            persona.State = BusinessEntity.States.Modified;
                        }
                        respuesta[0] = "La persona se guardó correctamente";
                        respuesta[1] = "1";
                        pl.Save(persona);
                    }
                    else
                    {
                        respuesta[0] = "La persona que desea guardar ya existe";
                        respuesta[1] = "0";
                    }
                } else
                {
                    respuesta[0] = "El legajo que desea guardar ya existe";
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
        public JsonResult SaveInsAl(AlumnoInscripcion inscripcion)
        {
            string[] respuesta = { "", "" };
            try
            {
                if (!pl.EsInscripcionRepetida(inscripcion))
                {
                    if (inscripcion.ID == 0)
                    {
                        inscripcion.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        inscripcion.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "La inscripción se guardó correctamente";
                    respuesta[1] = "1";
                    pl.SaveIns(inscripcion);
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
        public JsonResult SaveInsDoc(DocenteCurso inscripcion)
        {
            string[] respuesta = { "", "" };
            try
            {
                if (!pl.EsInscripcionRepetida(inscripcion))
                {
                    if (inscripcion.ID == 0)
                    {
                        inscripcion.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        inscripcion.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "La inscripción se guardó correctamente";
                    respuesta[1] = "1";
                    pl.SaveIns(inscripcion);
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
        public JsonResult DeleteInsAl(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                pl.DeleteInsAl(id);
                respuesta[0] = "La inscripción se eliminó correctamente";
                respuesta[1] = "1";
            }
            catch (Exception ex)
            {
                respuesta[0] = ex.Message;
                respuesta[1] = "0";
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteInsDoc(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                pl.DeleteInsDoc(id);
                respuesta[0] = "La inscripción se eliminó correctamente";
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
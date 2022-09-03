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
    public class CursosController : Controller
    {
        private CursoLogic cl = new CursoLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Curso
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            try
            {
                var cursos = from c in db.Cursos
                             join m in db.Materias
                                on c.IDMateria equals m.ID
                             join com in db.Comisiones
                                on c.IDComision equals com.ID
                             orderby m.Descripcion, com.Descripcion
                             select new
                             {
                                 c.ID,
                                 c.IDComision,
                                 c.IDMateria,
                                 c.AnioCalendario,
                                 c.Cupo,
                                 MateriaDesc = m.Descripcion,
                                 ComisionDesc = com.Descripcion
                             };
                return Json(cursos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult getOne(int id)
        {
            try
            {
                var curso = db.Cursos
                    .Where(c => c.ID.Equals(id))
                    .Select(c => new { c.ID, c.IDMateria, c.IDComision, c.AnioCalendario, c.Cupo })
                    .FirstOrDefault();
                return Json(curso, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        [Admin]
        public JsonResult Delete(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                cl.Delete(id);
                respuesta[0] = "El curso se eliminó correctamente";
                respuesta[1] = "1";
            }
            catch (Exception ex)
            {
                respuesta[0] = ex.Message;
                respuesta[1] = "0";
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        [Admin]
        public JsonResult Save(Curso curso)
        {
            string[] respuesta = { "", "" };
            try
            {
                Cursos repetido = db.Cursos
                    .Where(c => c.IDMateria.Equals(curso.IDMateria) && c.IDComision.Equals(curso.IDComision)
                    && c.AnioCalendario.Equals(curso.AnioCalendario) && !c.ID.Equals(curso.ID))
                    .FirstOrDefault();
                if (repetido == null)
                {
                    if (curso == null)
                    {
                        curso.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        curso.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "El curso se guardó correctamente";
                    respuesta[1] = "1";
                    cl.Save(curso);
                }
                else
                {
                    respuesta[0] = "El curso que desea guardar ya existe";
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
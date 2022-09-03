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
    public class MateriasController : Controller
    {
        private MateriaLogic ml = new MateriaLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Materias
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            try
            {
                var materias = from m in db.Materias
                               join p in db.Planes
                                   on m.IDPlan equals p.ID
                               join e in db.Especialidades
                                   on p.IDEspecialidad equals e.ID
                               orderby m.Descripcion, m.IDPlan, p.Descripcion, e.Descripcion
                               select new
                               {
                                   m.ID,
                                   m.Descripcion,
                                   m.HSTotales,
                                   m.HSSemanales,
                                   m.IDPlan,
                                   DescripcionPlan = p.Descripcion + " - " + e.Descripcion
                               };
                return Json(materias, JsonRequestBehavior.AllowGet);
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
                var materia = db.Materias
                    .Where(m => m.ID.Equals(id))
                    .Select(m => new { m.ID, m.Descripcion, m.HSSemanales, m.HSTotales, m.IDPlan })
                    .FirstOrDefault();
                return Json(materia, JsonRequestBehavior.AllowGet);
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
                ml.Delete(id);
                respuesta[0] = "La materia se eliminó correctamente";
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
        public JsonResult Save(Materia materia)
        {
            string[] respuesta = { "", "" };
            try
            {
                Materias repetido = db.Materias
                    .Where(m => m.Descripcion.Equals(materia.Descripcion) && m.IDPlan.Equals(materia.IDPlan) && !m.ID.Equals(materia.ID))
                    .FirstOrDefault();
                if (repetido == null)
                {
                    if (materia.ID == 0)
                    {
                        materia.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        materia.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "La materia se guardó correctamente";
                    respuesta[1] = "1";
                    ml.Save(materia);
                }
                else
                {
                    respuesta[0] = "La materia que desea guardar ya existe";
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
        public JsonResult FiltraMaterias(string descripcion)
        {
            try
            {
                var materias = from m in db.Materias
                               join p in db.Planes
                                   on m.IDPlan equals p.ID
                               join e in db.Especialidades
                                   on p.IDEspecialidad equals e.ID
                               orderby m.Descripcion, m.IDPlan, p.Descripcion, e.Descripcion
                               select new
                               {
                                   m.ID,
                                   m.Descripcion,
                                   m.HSTotales,
                                   m.HSSemanales,
                                   m.IDPlan,
                                   DescripcionPlan = p.Descripcion + " - " + e.Descripcion
                               };
                materias = materias.Where(m => m.Descripcion.Contains(descripcion));
                return Json(materias, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
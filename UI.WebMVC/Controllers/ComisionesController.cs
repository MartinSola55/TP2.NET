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
    public class ComisionesController : Controller
    {
        private ComisionLogic cl = new ComisionLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Comisiones
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            try
            {
                var comisiones = from c in db.Comisiones
                                 join p in db.Planes
                                    on c.IDPlan equals p.ID
                                 join e in db.Especialidades
                                    on p.IDEspecialidad equals e.ID
                                 orderby c.Descripcion
                                 select new
                                 {
                                     c.ID,
                                     c.Descripcion,
                                     c.AnioEspecialidad,
                                     c.IDPlan,
                                     PlanDesc = p.Descripcion + " - " + e.Descripcion
                                 };
                return Json(comisiones, JsonRequestBehavior.AllowGet);
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
                var comisiones = db.Comisiones
                    .Where(c => c.ID.Equals(id))
                    .Select(c => new { c.ID, c.Descripcion, c.AnioEspecialidad, c.IDPlan })
                    .FirstOrDefault();
                return Json(comisiones, JsonRequestBehavior.AllowGet);
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
                respuesta[0] = "La comisión se eliminó correctamente";
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
        public JsonResult Save(Comision comision)
        {
            string[] respuesta = { "", "" };
            try
            {
                Comisiones repetido = db.Comisiones
                    .Where(c => c.Descripcion.Equals(comision.Descripcion) && c.IDPlan.Equals(comision.IDPlan)
                    && c.AnioEspecialidad.Equals(comision.AnioEspecialidad) && !c.ID.Equals(comision.ID))
                    .FirstOrDefault();
                if (repetido == null)
                {
                    if (comision.ID == 0)
                    {
                        comision.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        comision.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "La comisión se guardó correctamente";
                    respuesta[1] = "1";
                    cl.Save(comision);
                }
                else
                {
                    respuesta[0] = "La comisión que desea guardar ya existe";
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
        public JsonResult FiltraComisiones(string descripcion)
        {
            try
            {
                var comisiones = from c in db.Comisiones
                                 join p in db.Planes
                                    on c.IDPlan equals p.ID
                                 join e in db.Especialidades
                                    on p.IDEspecialidad equals e.ID
                                 orderby c.Descripcion
                                 select new
                                 {
                                     c.ID,
                                     c.Descripcion,
                                     c.AnioEspecialidad,
                                     c.IDPlan,
                                     PlanDesc = p.Descripcion + " - " + e.Descripcion
                                 };
                comisiones = comisiones.Where(c => c.Descripcion.Contains(descripcion));
                return Json(comisiones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
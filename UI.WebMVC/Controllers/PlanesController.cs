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
    public class PlanesController : Controller
    {
        private PlanLogic pl = new PlanLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Planes
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            try
            {
                var planes = from p in db.Planes
                             join e in db.Especialidades
                                on p.IDEspecialidad equals e.ID
                             orderby p.Descripcion, e.Descripcion
                             select new
                             {
                                 p.ID,
                                 p.Descripcion,
                                 IDEspecialidad = e.ID,
                                 DescripcionEsp = e.Descripcion
                             };
                return Json(planes, JsonRequestBehavior.AllowGet);
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
                var plan = db.Planes
                    .Where(p => p.ID.Equals(id))
                    .Select(p => new { p.ID, p.Descripcion, p.IDEspecialidad })
                    .FirstOrDefault();
                return Json(plan, JsonRequestBehavior.AllowGet);
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
                pl.Delete(id);
                respuesta[0] = "El plan se eliminó correctamente";
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
        public JsonResult Save(Plan plan)
        {
            string[] respuesta = { "", "" };
            try
            {
                Planes repetido = db.Planes
                    .Where(p => p.Descripcion.Equals(plan.Descripcion) && p.IDEspecialidad.Equals(plan.IDEspecialidad) && !p.ID.Equals(plan.ID))
                    .FirstOrDefault();
                if (repetido == null)
                {
                    if (plan.ID == 0)
                    {
                        plan.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        plan.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "El plan se guardó correctamente";
                    respuesta[1] = "1";
                    pl.Save(plan);
                }
                else
                {
                    respuesta[0] = "El plan que desea guardar ya existe";
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
        public JsonResult FiltraPlanes(string descripcion)
        {
            try
            {
                var planes = from p in db.Planes
                             join e in db.Especialidades
                                on p.IDEspecialidad equals e.ID
                             orderby p.Descripcion, e.Descripcion
                             select new
                             {
                                 p.ID,
                                 p.Descripcion,
                                 IDEspecialidad = e.ID,
                                 DescripcionEsp = e.Descripcion
                             };
                planes = planes.Where(p => p.Descripcion.Contains(descripcion));
                return Json(planes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
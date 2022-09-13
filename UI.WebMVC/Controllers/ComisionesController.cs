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
        private PlanLogic pl = new PlanLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Comisiones
        public ActionResult Inicio()
        {
            ViewBag.listado = listadoPlanes();
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(Comision comision)
        {
            ViewBag.listado = listadoPlanes();
            if (ModelState.IsValid)
            {
                return View(comision);
            }
            return RedirectToAction(nameof(Inicio));
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
        public ActionResult Delete(Comision comision)
        {
            try
            {
                cl.Delete(comision.ID);
                ViewBag.Message = "La comisión se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listado = listadoPlanes();
            return View("Inicio");
        }
        [Admin]
        public ActionResult Save(Comision comision)
        {
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
                        ViewBag.Message = "La comisión se guardó correctamente";
                    }
                    else
                    {
                        comision.State = BusinessEntity.States.Modified;
                        ViewBag.Message = "La comisión se actualizó correctamente";
                    }
                    cl.Save(comision);
                }
                else
                {
                    ViewBag.Message = "La comisión que desea guardar ya existe";
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
        public IEnumerable<SelectListItem> listadoPlanes()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Plan> planes = pl.GetAll();
                lista = planes.Select(p => new SelectListItem { Text = p.Descripcion + " - " + p.DescripcionEsp, Value = p.ID.ToString() });
            } catch (Exception e)
            {

            }
            return lista;
        }
    }
}
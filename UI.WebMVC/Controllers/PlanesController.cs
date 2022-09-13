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
        private EspecialidadLogic el = new EspecialidadLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Planes
        public ActionResult Inicio()
        {
            ViewBag.listado = listadoEspecialidades();
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(Plan plan)
        {
            ViewBag.listado = listadoEspecialidades();
            if (ModelState.IsValid)
            {
                return View(plan);
            }
            return RedirectToAction(nameof(Inicio));
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
        public ActionResult Delete(Plan plan)
        {
            try
            {
                pl.Delete(plan.ID);
                ViewBag.Message = "El plan se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listado = listadoEspecialidades();
            return View("Inicio");
        }
        [Admin]
        public ActionResult Save(Plan plan)
        {
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
                    ViewBag.Message = "El plan se guardó correctamente";
                    pl.Save(plan);
                }
                else
                {
                    ViewBag.Message = "El plan que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listado = listadoEspecialidades();
            return View("Inicio");
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
        public IEnumerable<SelectListItem> listadoEspecialidades()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Especialidad> especialidades = el.GetAll();
                lista = especialidades.Select(e => new SelectListItem { Text = e.Descripcion, Value = e.ID.ToString() });
            }
            catch (Exception e)
            {

            }
            return lista;
        }
    }
}
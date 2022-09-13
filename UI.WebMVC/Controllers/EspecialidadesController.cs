using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Entities;
using Business.Logic;
using UI.WebMVC.Filter;

namespace UI.WebMVC.Controllers
{
    [Seguridad]
    public class EspecialidadesController : Controller
    {
        private EspecialidadLogic el = new EspecialidadLogic();
        private DataClassesDataContext db = new DataClassesDataContext();
        // GET: Especialidades
        public ActionResult Inicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                return View(especialidad);
            }
            return RedirectToAction(nameof(Inicio));
        }
        public JsonResult getAll()
        {
            try
            {
                var especialidades = db.Especialidades
                    .Select(e => new { ID = e.ID, Descripcion = e.Descripcion })
                    .OrderBy(e => e.Descripcion);
                return Json(especialidades, JsonRequestBehavior.AllowGet);
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
                var especialidad = db.Especialidades
                    .Where(e => e.ID.Equals(id))
                    .Select(e => new { ID = e.ID, Descripcion = e.Descripcion })
                    .FirstOrDefault();
                return Json(especialidad, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        [Admin]
        public ActionResult Delete(Especialidad esp)
        {
            try
            {
                el.Delete(esp.ID);
                ViewBag.Message = "La especialidad se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            return View("Inicio");
        }
        [Admin]
        public ActionResult Save(Especialidad esp)
        {
            try
            {
                Especialidades repetido = db.Especialidades.Where(e => e.Descripcion.Equals(esp.Descripcion)).FirstOrDefault();
                if (repetido == null)
                {
                    if (esp.ID == 0)
                    {
                        esp.State = BusinessEntity.States.New;
                        ViewBag.Message = "La especialidad se guardó correctamente";
                    }
                    else
                    {
                        esp.State = BusinessEntity.States.Modified;
                        ViewBag.Message = "La especialidad se actualizó correctamente";
                    }
                    el.Save(esp);
                } else
                {
                    ViewBag.Message = "La especialidad que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            return View("Inicio");
        }
        public JsonResult FiltraEspecialidades(string descripcion)
        {
            try
            {
                var especialidades = from e in db.Especialidades
                                     orderby e.Descripcion
                                     select new
                                     {
                                         e.ID,
                                         e.Descripcion,
                                     };
                especialidades = especialidades.Where(e => e.Descripcion.Contains(descripcion));
                return Json(especialidades, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
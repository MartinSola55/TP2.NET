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
        private PlanLogic pl = new PlanLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Materias
        public ActionResult Inicio()
        {
            ViewBag.listado = listadoPlanes();
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(Materia materia)
        {
            ViewBag.listado = listadoPlanes();
            if (ModelState.IsValid)
            {
                return View(materia);
            }
            return RedirectToAction(nameof(Inicio));
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
        public ActionResult Delete(Materia materia)
        {
            try
            {
                ml.Delete(materia.ID);
                ViewBag.Message = "La materia se eliminó correctamente";
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
        public ActionResult Save(Materia materia)
        {
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
                        ViewBag.Message = "La materia se guardó correctamente";
                    }
                    else
                    {
                        materia.State = BusinessEntity.States.Modified;
                        ViewBag.Message = "La materia se actualizó correctamente";
                    }
                    ml.Save(materia);
                }
                else
                {
                    ViewBag.Message = "La materia que desea guardar ya existe";
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
        public IEnumerable<SelectListItem> listadoPlanes()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Plan> planes = pl.GetAll();
                lista = planes.Select(p => new SelectListItem { Text = p.Descripcion + " - " + p.DescripcionEsp, Value = p.ID.ToString() });
            }
            catch (Exception e)
            {

            }
            return lista;
        }
    }
}
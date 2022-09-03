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
        public JsonResult Delete(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                el.Delete(id);
                respuesta[0] = "La especialidad se eliminó correctamente";
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
        public JsonResult Save(Especialidad esp)
        {
            string[] respuesta = { "", ""};
            try
            {
                Especialidades repetido = db.Especialidades.Where(e => e.Descripcion.Equals(esp.Descripcion)).FirstOrDefault();
                if (repetido == null)
                {
                    if (esp.ID == 0)
                    {
                        esp.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        esp.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "La especialidad se guardó correctamente";
                    respuesta[1] = "1";
                    el.Save(esp);
                } else
                {
                    respuesta[0] = "La especialidad que desea guardar ya existe";
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
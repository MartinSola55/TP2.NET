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
        // GET: Especialidades
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = el.GetAll();
            return Json(especialidades, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Especialidad especialidad = new Especialidad();
            especialidad = el.GetOne(id);
            return Json(especialidad, JsonRequestBehavior.AllowGet);
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
                Especialidad repetido = el.GetByDescripcion(esp.Descripcion);
                if (repetido.ID == 0)
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
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = el.FiltraEspecialidades(descripcion);
            return Json(especialidades, JsonRequestBehavior.AllowGet);
        }
    }
}
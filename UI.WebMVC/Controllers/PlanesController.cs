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

        // GET: Planes
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Plan> planes = new List<Plan>();
            planes = pl.GetAll();
            return Json(planes, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Plan plan = new Plan();
            plan = pl.GetOne(id);
            return Json(plan, JsonRequestBehavior.AllowGet);
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
                Plan repetido = pl.GetRepetido(plan);
                if (repetido.ID == 0)
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
            List<Plan> planes = new List<Plan>();
            planes = pl.FiltraPlanes(descripcion);
            return Json(planes, JsonRequestBehavior.AllowGet);
        }
    }
}
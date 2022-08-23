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
        // GET: Comisiones
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Comision> comisiones = new List<Comision>();
            comisiones = cl.GetAll();
            return Json(comisiones, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Comision comision = new Comision();
            comision = cl.GetOne(id);
            return Json(comision, JsonRequestBehavior.AllowGet);
        }
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
        public JsonResult Save(Comision comision)
        {
            string[] respuesta = { "", "" };
            try
            {
                Comision repetido = cl.GetRepetido(comision);
                if (repetido.ID == 0)
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
        public JsonResult FiltraPlanes(string descripcion)
        {
            List<Comision> comisiones = new List<Comision>();
            comisiones = cl.FiltraComisiones(descripcion);
            return Json(comisiones, JsonRequestBehavior.AllowGet);
        }
    }
}
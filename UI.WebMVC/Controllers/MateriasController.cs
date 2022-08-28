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
        // GET: Materias
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Materia> materia = new List<Materia>();
            try
            {
                materia = ml.GetAll();
            }
            catch (Exception e)
            {

            }
            return Json(materia, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Materia materia = new Materia();
            try
            {
                materia = ml.GetOne(id);
            }
            catch (Exception e)
            {

            }
            return Json(materia, JsonRequestBehavior.AllowGet);
        }
        [Admin]
        public JsonResult Delete(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                ml.Delete(id);
                respuesta[0] = "La materia se eliminó correctamente";
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
        public JsonResult Save(Materia materia)
        {
            string[] respuesta = { "", "" };
            try
            {
                Materia repetido = ml.GetRepetido(materia);
                if (repetido.ID == 0)
                {
                    if (materia.ID == 0)
                    {
                        materia.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        materia.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "La materia se guardó correctamente";
                    respuesta[1] = "1";
                    ml.Save(materia);
                }
                else
                {
                    respuesta[0] = "La materia que desea guardar ya existe";
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
        public JsonResult FiltraMaterias(string descripcion)
        {
            List<Materia> materia = new List<Materia>();
            try
            {
                materia = ml.FiltraMaterias(descripcion);
            }
            catch (Exception e)
            {

            }
            return Json(materia, JsonRequestBehavior.AllowGet);
        }
    }
}
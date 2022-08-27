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
    public class CursosController : Controller
    {
        private CursoLogic cl = new CursoLogic();
        // GET: Curso
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Curso> cursos = new List<Curso>();
            cursos = cl.GetAll();
            return Json(cursos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Curso curso = new Curso();
            curso = cl.GetOne(id);
            return Json(curso, JsonRequestBehavior.AllowGet);
        }
        [Admin]
        public JsonResult Delete(int id)
        {
            string[] respuesta = { "", "" };
            try
            {
                cl.Delete(id);
                respuesta[0] = "El curso se eliminó correctamente";
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
        public JsonResult Save(Curso curso)
        {
            string[] respuesta = { "", "" };
            try
            {
                Curso repetido = cl.GetRepetido(curso);
                if (repetido.ID == 0)
                {
                    if (curso.ID == 0)
                    {
                        curso.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        curso.State = BusinessEntity.States.Modified;
                    }
                    respuesta[0] = "El curso se guardó correctamente";
                    respuesta[1] = "1";
                    cl.Save(curso);
                }
                else
                {
                    respuesta[0] = "El curso que desea guardar ya existe";
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
    }
}
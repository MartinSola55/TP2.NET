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
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioLogic ul = new UsuarioLogic();
            usuarios = ul.GetAll();
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOne(int id)
        {
            Usuario usuario = new Usuario();
            UsuarioLogic ul = new UsuarioLogic();
            usuario = ul.GetOne(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            string respuesta;
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                ul.Delete(id);
                respuesta = "El usuario se eliminó correctamente";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(Usuario usr)
        {
            UsuarioLogic ul = new UsuarioLogic();
            string respuesta;
            try
            {
                if (usr.ID == 0)
                {
                    usr.State = BusinessEntity.States.New;
                } else
                {
                    usr.State = BusinessEntity.States.Modified;
                }
                ul.Save(usr);
                respuesta = "El usuario se guardó correctamente";
            }catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FiltraUsuarios(string nombre, string apellido, string usr, string mail)
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioLogic ul = new UsuarioLogic();
            usuarios = ul.FiltraUsuarios(nombre, apellido, usr, mail);
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }
    }
}
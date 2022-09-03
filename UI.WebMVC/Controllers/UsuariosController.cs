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
    [Admin]
    public class UsuariosController : Controller
    {
        private UsuarioLogic ul = new UsuarioLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Usuarios
        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult getAll()
        {
            try
            {
                var usuarios = from u in db.Usuarios
                               join per in db.Personas
                                    on u.IDPersona equals per.ID
                                    into persona
                               from p in persona.DefaultIfEmpty()
                               select new
                               {
                                   u.ID,
                                   u.NombreUsuario,
                                   u.Clave,
                                   u.Habilitado,
                                   p.Email
                               };
                return Json(usuarios, JsonRequestBehavior.AllowGet);
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
                var usuario = from u in db.Usuarios
                               join per in db.Personas
                                    on u.IDPersona equals per.ID
                                    into persona
                               from p in persona.DefaultIfEmpty()
                               where u.ID == id
                               select new
                               {
                                   u.ID,
                                   u.NombreUsuario,
                                   u.Clave,
                                   u.Habilitado,
                                   p.Email
                               };
                return Json(usuario, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        [Admin]
        public JsonResult Delete(int id)
        {
            string respuesta;
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
        [Admin]
        public JsonResult Save(Usuario usr)
        {
            string respuesta;
            try
            {
                usr.State = BusinessEntity.States.Modified;
                ul.Save(usr);
                respuesta = "El usuario se guardó correctamente";
            }catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FiltraUsuarios(string usr, string mail)
        {
            try
            {
                var usuarios = from u in db.Usuarios
                               join per in db.Personas
                                    on u.IDPersona equals per.ID
                                    into persona
                               from p in persona.DefaultIfEmpty()
                               select new
                               {
                                   u.ID,
                                   u.NombreUsuario,
                                   u.Clave,
                                   u.Habilitado,
                                   p.Email
                               };
                usuarios = usuarios.Where(u=>u.NombreUsuario.Contains(usr) && u.Email.Contains(mail));
                return Json(usuarios, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
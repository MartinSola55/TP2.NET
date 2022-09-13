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
        [HttpPost]
        public ActionResult Inicio(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return View(usuario);
            }
            return RedirectToAction(nameof(Inicio));
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
        public ActionResult Delete(Usuario usr)
        {
            try
            {
                ul.Delete(usr.ID);
                ViewBag.Message = "El usuario se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            return View("Inicio");
        }
        [Admin]
        public ActionResult Save(Usuario usr)
        {
            try
            {
                Usuarios repetido = db.Usuarios
                    .Where(u => u.NombreUsuario.Equals(usr.NombreUsuario) && !u.ID.Equals(usr.ID))
                    .FirstOrDefault();
                if (repetido == null)
                {
                    usr.State = BusinessEntity.States.Modified;
                    ul.Save(usr);
                    ViewBag.Message = "El usuario se guardó correctamente";
                } else
                {
                    ViewBag.Message = "El usuario que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            return View("Inicio");
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
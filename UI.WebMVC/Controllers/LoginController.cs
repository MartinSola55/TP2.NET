using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UI.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        UsuarioLogic ul = new UsuarioLogic();
        // GET: Login
        public ActionResult Inicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(Usuario user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction(nameof(Inicio));
        }
        public ActionResult CerrarSesion()
        {
            Session["user"] = null;
            Session["tipoUsr"] = null;
            Session["idUsr"] = null;
            return RedirectToAction("Inicio", "Home");
        }
        public ActionResult Validar(Usuario user)
        {
            bool respuesta = false;
            try
            {
                //Cifrar contraseña
                SHA256Managed sha = new SHA256Managed();
                byte[] passNoCifrada = Encoding.Default.GetBytes(user.Clave);
                byte[] bytesCifrados = sha.ComputeHash(passNoCifrada);
                string passCifrada = BitConverter.ToString(bytesCifrados).Replace("-", string.Empty);

                respuesta = ul.ValidaLogin(user.NombreUsuario, user.Clave);
                int tipoUsr = ul.GetTipoUsuario(user.NombreUsuario, user.Clave);
                int idPer = ul.GetIDPersona(user.NombreUsuario, user.Clave);

                if (respuesta == true)
                {
                    Session["user"] = user;
                    Session["tipoUsr"] = tipoUsr;
                    Session["idPer"] = idPer;
                    return RedirectToAction("Inicio", "Home");
                }
                ViewBag.Error = 1;
                ViewBag.Message = "Usuario y/o contraseña incorrectos";
                return View("Inicio");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
                return View("Inicio");
            }
        }
    }
}
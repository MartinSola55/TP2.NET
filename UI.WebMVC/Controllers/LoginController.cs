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
        // GET: Login
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult CerrarSesion()
        {
            Session["user"] = null;
            return RedirectToAction("Inicio", "Home");
        }
        public bool Validar(string user, string pass)
        {
            bool respuesta = false;
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                SHA256Managed sha = new SHA256Managed();
                //Cifrar contraseña
                byte[] passNoCifrada = Encoding.Default.GetBytes(pass);
                byte[] bytesCifrados = sha.ComputeHash(passNoCifrada);
                string passCifrada = BitConverter.ToString(bytesCifrados).Replace("-", string.Empty);

                respuesta = ul.ValidaLogin(user, pass);

                if (respuesta == true)
                {
                    Session["user"] = user;
                    return respuesta;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                return respuesta;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.WebMVC.Filter
{
    public class Seguridad : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = HttpContext.Current.Session["user"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string tipoUsr = HttpContext.Current.Session["tipoUsr"].ToString();
            if (tipoUsr != "3")
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class Alumno : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tipo = HttpContext.Current.Session["tipoUsr"];
            string tipoUsr = tipo == null ? "0" : tipo.ToString();
            if (tipoUsr != "2")
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class Docente : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tipo = HttpContext.Current.Session["tipoUsr"];
            string tipoUsr = tipo == null ? "0" : tipo.ToString();
            if (tipoUsr != "1")
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
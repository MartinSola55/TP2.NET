﻿using System;
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
            try
            {
                var usuario = HttpContext.Current.Session["user"];
                if (usuario == null)
                {
                    filterContext.Result = new RedirectResult("~/Home");
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
        }
    }
    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var tipo = HttpContext.Current.Session["tipoUsr"];
                string tipoUsr = tipo == null ? "0" : tipo.ToString();
                if (tipoUsr != "3")
                {
                    filterContext.Result = new RedirectResult("~/Home");
                }
                base.OnActionExecuting(filterContext);
            } catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
        }
    }
    public class Alumno : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var tipo = HttpContext.Current.Session["tipoUsr"];
                string tipoUsr = tipo == null ? "0" : tipo.ToString();
                if (tipoUsr != "2")
                {
                    filterContext.Result = new RedirectResult("~/Home");
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
        }
    }
    public class Docente : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var tipo = HttpContext.Current.Session["tipoUsr"];
                string tipoUsr = tipo == null ? "0" : tipo.ToString();
                if (tipoUsr != "1")
                {
                    filterContext.Result = new RedirectResult("~/Home");
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
        }
    }
}
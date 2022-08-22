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
}
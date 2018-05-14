using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Coffee3.Models.Entities;
using Coffee3.Models.Security;

namespace Coffee3.Models.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                //filterContext.Result = new RedirectToRouteResult(
                //         new System.Web.Routing.RouteValueDictionary(
                //          new
                //          {
                //              Controller = "Login",
                //              Action = "Index",
                //              ReturnUrl = filterContext.HttpContext.Request.RawUrl
                //          }));
                return;
            }

            var acc = (adminaccount)HttpContext.Current.Session["Login"];

            if (acc == null)
            {
                ////  filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
                //filterContext.Result = new RedirectToRouteResult(
                //    new System.Web.Routing.RouteValueDictionary(
                //        new
                //        {
                //            Controller = "Login",
                //            Action = "Index",
                //            ReturnUrl = filterContext.HttpContext.Request.RawUrl
                //        }));
                filterContext.Result = new RedirectResult("/Login/Index?ReturnUrl=" + filterContext.HttpContext.Request.RawUrl);
            }
            else
            {
                CustomPrincipal cp = new CustomPrincipal(acc);
                if (!cp.IsInRole(Roles))
                {
                    //filterContext.Result = new RedirectToRouteResult(
                    //    new System.Web.Routing.RouteValueDictionary(
                    //        new { Controller = "Login", Action = "Index" }));
                    filterContext.Result = new RedirectResult("/Login/Index?ReturnUrl=" + filterContext.HttpContext.Request.RawUrl);
                }
            }
        }
    }
}
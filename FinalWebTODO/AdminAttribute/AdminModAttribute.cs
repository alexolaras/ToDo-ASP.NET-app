using FinalWebTODO.BusinessLogic.Interfaces;
using FinalWebTODO.BusinessLogic;
using FinalWebTODO.Domain.Enums;
using FinalWebTODO.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinalWebTODO.AdminAttribute
{
    public class AdminModAttributes : ActionFilterAttribute
    {
        private readonly ISession _sessionBussinesLogic;

        public AdminModAttributes()
        {
            var bussinesLogic = new BussinesLogic();
            _sessionBussinesLogic = bussinesLogic.GetSessionBl();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _sessionBussinesLogic.GetUserByCookie(apiCookie.Value);
                if (profile == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                }

                if (profile.level != URole.Admin)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { controller = "Home", action = "Login" }));
                }

                if (profile.level == URole.Admin)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
    }
}
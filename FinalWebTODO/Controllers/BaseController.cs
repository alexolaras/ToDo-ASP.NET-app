using FinalWebTODO.BusinessLogic;
using FinalWebTODO.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalWebTODO.Extension;

namespace FinalWebTODO.Controllers
{
    public class BaseController : Controller
    {
        public readonly ISession _session;

        public BaseController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBl();
        }
        /*
        public void SessionStatus()
        {
            var apiCookie = Request.Cookies["X-KEY"];
            if(apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                if(profile != null)
                {
                    System.Web.HttpContext.Current.SetMySessionObject(profile);
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                }
                else
                {
                    System.Web.HttpContext.Current.Session.Clear();
                    if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                    {
                        var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                        if(cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddDays(1);
                            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                        }
                    }
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            }
        }*/
    }   
}
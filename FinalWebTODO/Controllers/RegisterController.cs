using FinalWebTODO.BusinessLogic;
using FinalWebTODO.BusinessLogic.Interfaces;
using FinalWebTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FinalWebTODO.Domain.Entities.User;

namespace FinalWebTODO.Controllers
{
    public class RegisterController : Controller
    {
        internal readonly ISession _session;
        public RegisterController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBl();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginDate>());
                var data = Mapper.Map<ULoginDate>(login);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userRegister = _session.UserRegister(data);

                if (userRegister.Status)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}
﻿using FinalWebTODO.BusinessLogic;
using FinalWebTODO.BusinessLogic.Interfaces;
using FinalWebTODO.Domain.Entities.User;
using FinalWebTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Data.SqlClient;


namespace FinalWebTODO.Controllers
{
    public class LoginController : Controller
    {
       
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBl();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginDate>());
                var data = Mapper.Map<ULoginDate>(login);

                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    /*
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    */
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
                  
            }
            return View();
        }
    }
}
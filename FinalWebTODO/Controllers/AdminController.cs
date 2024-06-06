﻿using FinalWebTODO.AdminAttribute;
using FinalWebTODO.BusinessLogic;
using FinalWebTODO.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalWebTODO.BusinessLogic.Interfaces;

namespace FinalWebTODO.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ISessionAdmin _session;

        public AdminController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetAdminSessionBL();
        }

        [AdminModAttributes]
        public ActionResult Tables()
        {
            SessionStatus();
            List<UserMinimal> allUsers = _session.RGetAllUsers();
            return View(allUsers);
        }

        [AdminModAttributes]
        [HttpGet]
        [Route("Admin/EditUserInfo/{id}")]
        public ActionResult EditUserInfo(int id)
        {
            SessionStatus();
            var userFromDB = _session.RGetUserById(id);
            if (userFromDB == null)
            {
                return View();
            }
            else
            {
                return View("EditUserInfo", userFromDB);
            }
        }

        [AdminModAttributes]
        [HttpPost]
        [Route("Admin/EditUserInfo/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInfoConfirm(int id, UserMinimal userModel)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                _session.EditUser(id, userModel);
                return RedirectToAction("Tables");
            }
            return View("EditUserInfo", userModel);
        }

        [AdminModAttributes]
        [HttpPost]
        [Route("Admin/DeleteUser/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                _session.DeleteUser(id);
                return RedirectToAction("Tables");
            }
            return RedirectToAction("Tables");
        }
/*
        [AdminModAttributes]
        [HttpGet]
        [Route("Admin/UserActivity/{id}")]
        public ActionResult UserActivity(int id)
        {
            SessionStatus();
            var user = _session.RGetUserById(id);
            var userActivityFromDB = _session.GetHistory(user);
            if (userActivityFromDB == null)
            {
                return View();
            }
            else
            {
                return View("UserActivity", userActivityFromDB);
            }
        }

        [AdminModAttributes]
        [HttpGet]
        [Route("Admin/UserCards/{id}")]
        public ActionResult UserCards(int id)
        {
            SessionStatus();
            var user = _session.RGetUserById(id);
            var userActivityFromDB = _session.GetCards(user);
            if (userActivityFromDB == null)
            {
                return View();
            }
            else
            {
                return View("UserCards", userActivityFromDB);
            }
        }

        [AdminModAttributes]
        [HttpPost]
        [Route("Admin/BlockCard/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult BlockCard(int id)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                _session.BlockCard(id);
                return RedirectToAction("Tables");
            }
            return RedirectToAction("Tables");
        }
    */}
}
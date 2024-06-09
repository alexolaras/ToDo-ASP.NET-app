using FinalWebTODO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalWebTODO.Extension;
using FinalWebTODO.BusinessLogic.Interfaces;
using FinalWebTODO.Domain.Entities.User;
using AutoMapper;
using FinalWebTODO.BusinessLogic;
using System.Web.UI.WebControls;

namespace FinalWebTODO.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Register()
        {
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        //logare mai jos
        public ActionResult Index()
        {
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
       /*
        public ActionResult Product()
        {
            var product = Request.QueryString["p"];

            UserData u = new UserData();
            u.Username = "Customer";
            u.SingleProduct = product;

            return View(u);
        }
    
        [HttpPost]
        public ActionResult Product(string btn)
        {
            return RedirectToAction("Product", "Home", new { @p = btn });
        }
        */
        public ActionResult Login()
        {
            return View();
        }

        
        ///Crearea TODO

        private  readonly ISession _session;
        public HomeController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBl();
        }

        
        //GET : Home
        public ActionResult CreazaTodo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreazaTodo(TodoMinimal todo)
        {
            if(ModelState.IsValid)
            {
                var currentUser = System.Web.HttpContext.Current.GetMySessionObject();

                todo.Data = DateTime.Now;

                var userTodo = _session.UserTodo(todo, currentUser);

                if (userTodo.Status)
                {
                    TempData["SuccessMessage"] = "Todo Creat cu Succes";
                    return RedirectToAction("CreazaTodo", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userTodo.StatusMsg);
                    return View();
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }
            return View();
        }
        
        
        public ActionResult UserList()
        {
            var list = _session.GetUserList();
            return View(list);
        }

        [HttpGet]
        public ActionResult TodoList()
        {
            var currentUser = System.Web.HttpContext.Current.GetMySessionObject();
            var todo = _session.GetTodoList(currentUser);

            return View(todo);
        }



        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Contact2()
        {
            return View();
        }
    }
}
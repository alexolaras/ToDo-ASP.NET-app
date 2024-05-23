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
    public class HomeController : Controller
    {

        public ActionResult Register()
        {
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult Index()
        {
        //    SessionStatus(); 
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
        public ActionResult CreazaTodo(TodoData todo)
        {
            if(ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TodoData, UTodoDate>());
                var data = Mapper.Map<UTodoDate>(todo);

                data.TodoTime = DateTime.Now;

                var userTodo = _session.UserTodo(data);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TodoData todo)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TodoData, UTodoDate>());
                var data = Mapper.Map<UTodoDate>(todo);

                // Salvează datele în baza de date
                _session.SaveTodoData(data);
                return RedirectToAction("TodoList");
            }

            // Dacă modelul nu este valid, reîntoarce vizualizarea cu datele curente
            var viewModel = new CombinedModels
            {
                TodoList = _session.GetTodoList(),
                TodoData = todo
            };
            return View("TodoList", viewModel);
        }

        public ActionResult TodoList()
        {
             var todoList = _session.GetTodoList(); // Obține lista de Todo-uri din sesiune sau baza de date

            var viewModel = new CombinedModels
            {
                TodoList = todoList,
                TodoData = new TodoData() // Inițializează un obiect TodoData gol sau populat după necesitate
            };

            return View(viewModel);
        }



        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}
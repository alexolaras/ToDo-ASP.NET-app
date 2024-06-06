﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWebTODO.BusinessLogic.DBModels;
using FinalWebTODO.Domain.Entities.User;
using FinalWebTODO.Domain.Enums;
using FinalWebTODO;
using System.Data.Entity;
using AutoMapper;
using System.Web;
using eUseControl.Helpers;
using RestSharp;
using System.Web.UI.WebControls;
using System.Net;

namespace FinalWebTODO.BusinessLogic.Core
{
    public class UserApi
    {
        

        internal ULoginResp UserChangeAction(UTodoDate data)
        {
            TodoDbTable result;

            using( var db = new TodoContext())
            {
                result = db.Todos.FirstOrDefault(u => u.Subiect == data.Subiect && u.Descriere == data.Descriere);
            }
            if(result == null)
            {                                       
                return new ULoginResp { Status = false, StatusMsg = "nu exista asa" };
            }

            var newTodo = new TodoDbTable()
            {
                Data = data.TodoTime,
                Subiect = data.Subiect,
                Descriere = data.Descriere,
            };
            using ( var db = new TodoContext())
            {
                db.SaveChanges();
            }
            return new ULoginResp { Status = true };
        }


        internal ULoginResp UserTodoAction(UTodoDate data)
        {
            TodoDbTable result;

            using( var db = new TodoContext())
            {
                result = db.Todos.FirstOrDefault(u => u.Subiect == data.Subiect);
            }

            var newTodo = new TodoDbTable()
            {
                Data = data.TodoTime,
                Subiect = data.Subiect,
                Descriere = data.Descriere,
            };

            using (var db = new TodoContext())
            {
                db.Todos.Add(newTodo);
                db.SaveChanges();
            }

            return new ULoginResp { Status = true };
        }
        

        internal ULoginResp UserLoginAction(ULoginDate data)
        {
            UDbTable user;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                using (var db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(us => us.Email == data.Credential);
                }

                if (user != null)
                {
                    var hashedPassword = LoginHelper.HashGen(data.Password);
                    if (user != null && user.Password == hashedPassword)
                    {
                        using (var db = new UserContext())
                        {
                            user.LastIp = data.LoginIp;
                            user.LastLogin = data.LoginDateTime;
                            db.Entry(user).State = EntityState.Modified;
                        }


                        if (user.level == URole.User)
                            return new ULoginResp { Status = true, StatusMsg = "user" };
                        else
                             if (user.level == URole.Admin)
                            return new ULoginResp { Status = true, StatusMsg = "admin" };
                    }
                }
            }
            else
            {
                using (var db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(us => us.Username == data.Credential);
                }

                if (user != null)
                {
                    var hashedPassword = LoginHelper.HashGen(data.Password);
                    if (user != null && user.Password == hashedPassword)
                    {
                        using (var db = new UserContext())
                        {
                            user.LastIp = data.LoginIp;
                            user.LastLogin = data.LoginDateTime;
                            db.Entry(user).State = EntityState.Modified;
                            //db.SaveChanges();
                        }


                        if (user.level == URole.User)
                            return new ULoginResp { Status = true, StatusMsg = "user" };
                        else
                             if (user.level == URole.Admin)
                            return new ULoginResp { Status = true, StatusMsg = "admin" };
                    }
                }
            }



            // Authentication failed
            return new ULoginResp { Status = false, StatusMsg = "none" };
        }


        //registrare

        internal ULoginResp UserRegisterAction(ULoginDate data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using ( var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(m => m.Email == data.Credential);
                }

                if(result != null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "Username or Password used" };
                }

                var newUser = new UDbTable()
                {
                    Username = data.Credential,
                    Email = data.Credential,
                    Password = pass,
                    LastLogin = data.LoginDateTime,
                    LastIp = data.LoginIp
                };
                using ( var db = new UserContext())
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
            else
            {
                return new ULoginResp { Status = false, StatusMsg = "Something went wrong" };
            }
        }

        public List<TodoDbTable> RGetTodoList()
        {
            using (var db = new TodoContext())
            {
                var list = db.Todos.ToList();
                return list;
            }
        }

        public List<UDbTable> RGetUserList()
        {
            using( var db = new UserContext())
            {
                var list = db.Users.ToList();
                return list;
            }
        }

        //Cookie
        public System.Web.HttpCookie Cookie(string credential)
{
            var apiCookie = new System.Web.HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(credential)
            };
            using (var db = new SessionContext())
            {
                var curent = db.Sessions.FirstOrDefault(e => e.Username == credential);
                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    db.Entry(curent).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = credential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }



        public UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }
    }
}

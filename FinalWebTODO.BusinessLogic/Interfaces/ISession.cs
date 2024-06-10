using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWebTODO.Domain.Entities.User;
using System.Web;

namespace FinalWebTODO.BusinessLogic.Interfaces
{
    public interface ISession
    {

        ULoginResp SaveTodoData(UTodoDate data);

        ULoginResp UserTodo(TodoMinimal todo, UserMinimal user); 

        ULoginResp UserRegister(ULoginDate data);
        ULoginResp UserLogin(ULoginDate data);

        List<TodoMinimal> GetTodoList(UserMinimal user);

        List<UDbTable> GetUserList();

        HttpCookie GenCookie(string loginCredential);

        UserMinimal GetUserByCookie(string apiCookieValue);


        List<TodoMinimal> RGetAllTodo();
        TodoMinimal RGetTodoById(int id);
        void EditTodo(int id, TodoMinimal user);
        void DeleteTodo(int id);
    }
}

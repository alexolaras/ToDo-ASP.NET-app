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

        ULoginResp UserTodo(UTodoDate data); 
        ULoginResp UserRegister(ULoginDate data);
        ULoginResp UserLogin(ULoginDate data);
        List<TodoDbTable> GetTodoList();


        List<UDbTable> GetUserList();
        /*
        HttpCookie GenCookie(string loginCredential);

        UserMinimal GetUserByCookie(string apiCookieValue);
    */}
}

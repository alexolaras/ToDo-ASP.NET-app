using FinalWebTODO.BusinessLogic.Core;
using FinalWebTODO.BusinessLogic.Interfaces;
using FinalWebTODO.Domain.Entities.User;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic
{
    public class SessionBl: UserApi, ISession
    {
        public ULoginResp SaveTodoData(UTodoDate data)
        {
            return UserChangeAction(data);
        }


        public ULoginResp UserTodo(UTodoDate data)
        {
            return UserTodoAction(data);
        }
        
        public ULoginResp UserRegister(ULoginDate data)
        {
            return UserRegisterAction(data);
        }
        public ULoginResp UserLogin(ULoginDate data)
        {
            return UserLoginAction(data);
        } 

        public List<TodoDbTable> GetTodoList()
        {
            return RGetTodoList();
        }

        public List<UDbTable> GetUserList()
        {
            return RGetUserList();
        }

        /*
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }*/
    }
}

using FinalWebTODO.BusinessLogic.Core;
using FinalWebTODO.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic.Interfaces
{
    internal class AdminSessionBL : AdminApi, ISessionAdmin
    {
        public List<UserMinimal> GetAllUsers()
        {
            return RGetAllUsers();
        }

        public UserMinimal GetUserById(int id)
        {
            return RGetUserById(id);
        }

        public void EditUser(int id, UserMinimal user)
        {
            REditUser(id, user);
        }

        public void DeleteUser(int id)
        {
            RDeleteUser(id);
        }
        /*
        public List<HistoryTable> GetHistory(UserMinimal user)
        {
            return RGetHistory(user);
        }
        public List<CardMinimal> GetCards(UserMinimal user)
        {
            return RGetCards(user);
        }
        public void BlockCard(int card)
        {
            RBlockCard(card);
        }*/
    }
}

using FinalWebTODO.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic.Interfaces
{
    public interface ISessionAdmin
    {
        List<UserMinimal> RGetAllUsers();
        UserMinimal RGetUserById(int id);
        void EditUser(int id, UserMinimal user);
        void DeleteUser(int id);
       // List<HistoryTable> GetHistory(UserMinimal user);
       // List<CardMinimal> GetCards(UserMinimal user);
       // void BlockCard(int card);
    }
}

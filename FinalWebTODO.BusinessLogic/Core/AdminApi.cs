using FinalWebTODO.BusinessLogic.DBModels;
using FinalWebTODO.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic.Core
{
    public class AdminApi: UserApi
    {
        public List<UserMinimal> RGetAllUsers()
        {
            using (var db = new UserContext()) 
            {
                return db.Users.Select(u => new UserMinimal
                {
                    Username = u.Username,
                    Email = u.Email,
                    Password = u.Password,
                    Id = u.Id,
                    LastIp = u.LastIp,
                    LastLogin = u.LastLogin,
                    level = u.level,
                }).ToList();
            }
        }

        public UserMinimal RGetUserById(int Id)
        {
            using ( var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(us => us.Id == Id);
                if (user == null) return null;
                return new UserMinimal
                {
                    Username = user.Username,
                    Email = user.Email,
                    level = user.level,
                    Id = user.Id,
                };
            }
        }

        public void REditUser(int Id, UserMinimal userModel)
        {
            using (var dbContext = new UserContext())
            {
                var user = dbContext.Users.FirstOrDefault(us => us.Id == Id);
                if (user == null) return;

                user.Username = userModel.Username;
                user.Email = userModel.Email;
                user.level = userModel.level;

                dbContext.SaveChanges();
            }
        }

        public void RDeleteUser(int id)
        {
            using (var dbContext = new UserContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
                if (user == null) return;

                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }
    }
}

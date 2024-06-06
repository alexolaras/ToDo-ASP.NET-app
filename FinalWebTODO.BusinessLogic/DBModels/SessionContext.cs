using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalWebTODO.Domain.Entities.User;

namespace FinalWebTODO.BusinessLogic.DBModels
{
    public class SessionContext: DbContext
    {
        public SessionContext() : base("name=FinalWebTODO")
        {
        }
        public virtual DbSet<Session> Sessions { get; set; }
    }
}

using FinalWebTODO.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic.DBModels
{
    class TodoContext : DbContext
    {
        public TodoContext() :
            base("name=FinalWebTODO")
        {
        }
        public virtual DbSet<TodoDbTable> Todos { get; set; }
    }
}

using FinalWebTODO.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic.DBModels
{
    class TodoContext : System.Data.Entity.DbContext
    {
        public TodoContext() :
            base("name=FinalWebTODO")
        {
        }
        public virtual System.Data.Entity.DbSet<TodoDbTable> Todos { get; set; }
    }
}

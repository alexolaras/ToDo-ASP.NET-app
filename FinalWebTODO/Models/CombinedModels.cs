using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebTODO.Models
{
    public class CombinedModels
    {
        public List<FinalWebTODO.Domain.Entities.User.TodoDbTable> TodoList { get; set; }
        public FinalWebTODO.Models.TodoData TodoData { get; set; }  
    }
}
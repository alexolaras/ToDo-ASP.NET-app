using FinalWebTODO.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FinalWebTODO;
using System.Configuration;
using System.Web;
using System.Data.Entity;

namespace FinalWebTODO.BusinessLogic.DBModels
    {
         class UserContext: DbContext
        {
            public UserContext() :
                base("name=FinalWebTODO")
            {
            }
            public virtual DbSet<UDbTable> Users { get; set; }
    }
}

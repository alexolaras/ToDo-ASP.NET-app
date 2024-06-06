using FinalWebTODO.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebTODO.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBl()
        {
            return new SessionBl();
        }
        public ISessionAdmin GetAdminSessionBL()
        {
            return new AdminSessionBL();
        }
    }
}

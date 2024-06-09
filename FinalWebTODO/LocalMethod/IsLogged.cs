using FinalWebTODO.Domain.Enums;
using FinalWebTODO.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebTODO.LocalMethod
{
    public class IsLogged
    {
        public static bool isLogged()
        {
            var user = HttpContext.Current.GetMySessionObject();

            if (user != null)
            {
                return true;
            }
            {
                return false;
            }
        }
    }
}
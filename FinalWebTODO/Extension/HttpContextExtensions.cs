using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalWebTODO.BusinessLogic.Core;
using FinalWebTODO.Domain.Entities.User;
namespace FinalWebTODO.Extension
{
    public static class HttpContextExtensions
    {
        public static UserMinimal GetMySessionObject(this HttpContext context)
        {
            var cookie = context.Request.Cookies["X-KEY"];
            if (cookie != null)
            {
                // Logare pentru verificare
                System.Diagnostics.Debug.WriteLine($"Cookie found: {cookie.Value}");

                var userApi = new UserApi(); // Instanțiere directă sau utilizarea DI
                return userApi.UserCookie(cookie.Value);
            }
            // Logare pentru caz în care cookie-ul nu este găsit
            System.Diagnostics.Debug.WriteLine("No cookie found with name 'X-KEY'");
            return null;
        }
        public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
        {
            current.Session.Add("__SessionObject", profile);
        }
    }
}
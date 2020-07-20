using AR.ARWebAuthorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes
{
    public class Security
    {
        public static bool isLogged(HttpRequest Request)
        {
            ARWebAuthorizationUser u = ARWebAuthorization.GetUser(Request.Cookies["h"]);

            if (u != null && u.Alive)
                return true;

            return false;
        }

        public static AR.TDShop.User GetTDUser(HttpRequest Request)
        {
            ARWebAuthorizationUser u = ARWebAuthorization.GetUser(Request.Cookies["h"]);
            if (u != null)
                return u.LocalUserClass as AR.TDShop.User;

            return null;
        }
    }
}

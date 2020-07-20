using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Models;

namespace Notes.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            if (Security.isLogged(Request))
                return Redirect("/Beleska");

            return View();
        }

        [Route("/Home/Login")]
        public IActionResult Login(string username, string pw)
        {
            try
            {
                AR.TDShop.User u = new AR.TDShop.User();
                u.Name = username;
                u.PW = pw;

                int uid = u.Validate();
                string newHash;
                AR.TDShop.User use = new AR.TDShop.User(uid);
                AR.ARWebAuthorization.ARWebAuthorization.LogUser(use, out newHash);
                Response.Cookies.Append("h", newHash, new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddHours(1) });
                return Redirect("/Beleska");
            }
            catch (AR.ARException ex)
            {
                return View("Error", ex.ToString());
            }
        }
        [Route("/Home/Logout")]
        public IActionResult Logout()
        {
            AR.ARWebAuthorization.ARWebAuthorization.LogoutUser(Request.Cookies["h"]);
            return Redirect("/");
        }
    }
}

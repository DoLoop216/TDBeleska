using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Models;

namespace Notes.Controllers
{
    public class BeleskaController : Controller
    {
        [Route("/Beleska")]
        public IActionResult Index()
        {
            if (Security.isLogged(Request))
            {
                AR.TDShop.User user = Security.GetTDUser(Request);
                NoteModel note = new NoteModel(user.UserID);
                return View(note);
            }

            return Redirect("/");
        }

        [Route("/Beleska/Update")]
        public IActionResult Update(string text, int uid)
        {
            try
            {
                NoteModel note = new NoteModel(uid);
                note.Text = text;
                note.Update();
                return Redirect("/Beleska");
            }
            catch (Exception ex)
            {
                return View("Error", ex.ToString());
            }
        }
    }
}

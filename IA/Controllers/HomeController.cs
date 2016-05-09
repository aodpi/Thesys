using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA.Models.ViewModels;
using System.Web.Security;
using IA.Extensions;
using IA.Models;

namespace IA.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseStore db = new DatabaseStore();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string fff()
        {
            var rz = (from a in db.Users
                      join b in db.Elevations on a.ElevationId equals b.Id
                      select new { a.UserName, b.ElevationName });
            return Newtonsoft.Json.JsonConvert.SerializeObject(rz, Newtonsoft.Json.Formatting.Indented);
        }

        [HttpPost]
        public ActionResult Register(UserViewModel mdl)
        {
            var usr= db.Users.FirstOrDefault(f => f.UserName == mdl.UserName);
            if (usr==null)
            {
                db.Users.Add(new User() { UserName = mdl.UserName, Password = Security.Encryption.Sha1Encode(mdl.Password), ElevationId = 1 });
                db.SaveChanges();
            }
            return RedirectToAction("Login", new { @mdl = mdl });
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                UserViewModel usrmdl = new UserViewModel();
                Login(usrmdl);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (mdl.IsValid(mdl.UserName,mdl.Password))
                {
                    
                    if (Request.Cookies[FormsAuthentication.FormsCookieName]==null)
                    {
                        FormsAuthentication.SetAuthCookie(mdl.UserName, mdl.RememberMe);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data incorrect");
                    return View("Index", mdl);
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
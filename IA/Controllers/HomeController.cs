using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA.Models.ViewModels;
using System.Web.Security;
using IA.Extensions;
namespace IA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel mdl)
        {
            IA.Models.DatabaseStore db = new Models.DatabaseStore();
            if (ModelState.IsValid)
            {
                if (mdl.IsValid(mdl.UserName,mdl.Password))
                {
                    
                    if (Request.Cookies[FormsAuthentication.FormsCookieName]==null)
                    {
                        //FormsAuthentication.SetAuthCookie(mdl.UserName, mdl.RememberMe);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                            mdl.UserName, 
                            DateTime.Now, 
                            DateTime.Now.AddMinutes(100), 
                            mdl.RememberMe, 
                            db.Users.GetUserId(mdl.UserName).ToString());
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(cookie);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data incorrect");
                    return View("Index", mdl);
                }
            }
            return RedirectToAction("Index", "Home", null);
        }
    }
}
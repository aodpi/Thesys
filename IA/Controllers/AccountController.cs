using System.Linq;
using System.Web.Mvc;
using IA.Extensions;
using IA.Models;
namespace IA.Controllers
{
    public class AccountController : Controller
    {
        private DatabaseStore db = new DatabaseStore();
        // GET: Account
        public ActionResult Index()
        {
            //HttpCookie authcookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //string username = FormsAuthentication.Decrypt(authcookie.Value).Name;
            //var usr = db.Users.FirstOrDefault(f => f.UserName == username);
            //IA.Models.ViewModels.UserViewModel mdl = new Models.ViewModels.UserViewModel() { UserName = username, Password = usr.Password };
            return View();
        }
        
        public string GetUS(string username)
        {
            return username != string.Empty ? username : "sss";
        }

        public ActionResult ProfileDetail(string username)
        {
            var uname = Extensions.Extensions.GetLoggedUser();
            if (username != null)
            {
                User mdl = db.Users.FirstOrDefault(f => f.UserName == username);
                if (mdl != null)
                {
                    var pass = new IA.Models.ViewModels.UserViewModel();
                    pass.UserName = mdl.UserName;
                    return View(pass);
                }
                else
                    return View("Error");
            }
            else if (uname != string.Empty)
            {
                User mdl = db.Users.FirstOrDefault(f => f.UserName == uname);
                if (mdl != null)
                {
                    var pass = new IA.Models.ViewModels.UserViewModel();
                    pass.UserName = mdl.UserName;
                    return View(pass);
                }
            }
            return View("Error");
        }
    }
}
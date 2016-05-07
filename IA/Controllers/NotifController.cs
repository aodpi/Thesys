using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace IA.Controllers
{
    public class NotifController : ApiController
    {
        private IA.Models.DatabaseStore db = new IA.Models.DatabaseStore();
        [HttpGet]
        public IHttpActionResult AddChannel(string uri)
        {
            db.NotificationChannels.Add(new Models.NotificationChannel { NotificationType = "test", NotificationChannelUri = uri, UserId = 1 });
            db.SaveChanges();
            return Ok("OK");
        }
        
        public class tst
        {
            public string uri { get; set; }
        }
        
        public JsonResult<List<tst>> GetChannels()
        {
            Newtonsoft.Json.JsonSerializerSettings sett = new Newtonsoft.Json.JsonSerializerSettings();
            sett.Formatting = Newtonsoft.Json.Formatting.Indented;
            List<tst> ls = new List<tst>();
            foreach (var item in db.NotificationChannels)
            {
                ls.Add(new tst { uri = item.NotificationChannelUri });
            }
            return Json(ls, sett);
        }
    }
}

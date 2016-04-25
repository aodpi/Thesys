using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA.IALogic.Notifications;
using IA.Models;

namespace IA.Controllers
{
    public class NotifyController : Controller
    {
        // GET: Notify
        public string Index()
        {
            DatabaseStore db = new DatabaseStore();
            List<NotificationChannel> resultquery = db.NotificationChannels.Where(f => f.User.UserName == "aodpi").ToList();
            foreach (var item in resultquery)
            {
                NotificationsManager.SendNotification(item.NotificationChannelUri, NotificationOSType.Windows);
            }
            return "OK";
        }
    }
}
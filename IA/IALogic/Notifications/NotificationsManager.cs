using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using IA.Models;

namespace IA.IALogic.Notifications
{
    public enum NotificationOSType
    {
        Windows,
        Android,
        IOS
    }
    
    public class NotificationsManager
    {
        //windows phone
        //https://db5.notify.windows.com/?token=AwYAAACT8lfDx9gxmWDKx4oBEaFYeoWWIwtMW1klTiWPV8JJ5fNvJnYBQxxbbAHcOVVvcQ%2bWUVbLgcVf04oLqwKTDSik2sgkzDXixnKKZTqfNN0kxJvYZ4IUnvS9bMLv6aogLp8%3d
        //windows
        //https://db5.notify.windows.com/?token=AwYAAAA4N76nZs8EW%2f%2fWebQBoxXk7nS2J%2fQqihVuKtQNarVbCxHfhPrikB3OX%2bjNUcvY5PTCLqoUT6C%2f5jG6z7LzI%2bX7Z5ZJbN9p5U0SN9oUZhxUGdpNgiIWoZ%2bVeBZrzZWWxmw%3d
        public static string SendNotification(string channeluri,NotificationOSType os_type, string secret = "MfW6Fh61MI/xB4cINLNPRvQmrsc08riO",
            string sid = "ms-app://s-1-15-2-2424616452-1893528945-2160086533-2296198851-2692721426-2460803556-2392277436")
        {
            OAuthToken accessToken = OAuthTokenManager.GetAccessToken(secret, sid);
            string toastxml = "<toast>"+
                "<visual>"+
                "<binding template=\"ToastImageAndText02\">"+
                "<image id=\"1\" src=\"http://aodpi.azurewebsites.net/Content/Images/Deepcoil.jpg\" alt=\"image1\" />"+
                "<text id=\"1\">IA Simple Notification</text>"+
                "<text id=\"2\">Hello this is a Test Notification</text>"+
                "</binding>"+
                "</visual>"+
                "</toast>";

            byte[] contentInBytes = Encoding.UTF8.GetBytes(toastxml);
            HttpWebRequest request = HttpWebRequest.Create(channeluri) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("X-WNS-Type", "wns/toast");
            request.ContentType = "text/xml";
            request.Headers.Add("Authorization", string.Format("Bearer {0}", accessToken.AccessToken));

            using (Stream requestStream=request.GetRequestStream())
            {
                requestStream.Write(contentInBytes, 0, contentInBytes.Length);
            }

            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
            {
                return webResponse.StatusCode.ToString();
            }
        }
    }
}
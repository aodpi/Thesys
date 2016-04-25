using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net;

namespace IA.IALogic.Notifications
{
    public class OAuthTokenManager
    {
        private static OAuthToken GetOAuthFromJson(string json)
        {
            return JsonConvert.DeserializeObject<OAuthToken>(json);
        }

        public static OAuthToken GetAccessToken(string secret,string sid)
        {
            string urlEncodedSecret = HttpUtility.UrlEncode(secret);
            string urlEncodedSid = HttpUtility.UrlEncode(sid);

            string body = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=notify.windows.com", urlEncodedSid, urlEncodedSecret);
            string response;
            using (var client=new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                response = client.UploadString("https://login.live.com/accesstoken.srf", body);
            }
            return GetOAuthFromJson(response);
        }
    }
}
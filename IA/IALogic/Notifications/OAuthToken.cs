using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace IA.IALogic.Notifications
{
    public class OAuthToken
    {
        [JsonProperty(PropertyName ="access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName ="token_type")]
        public string TokenType { get; set; }
    }
}
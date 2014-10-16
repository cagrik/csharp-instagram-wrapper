using InstagramWrapper.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;


namespace InstagramWrapper.Service
{
    public class InstagramAuth
    {
        public OuthUser GetAccessToken(string code,InstaConfig ic)
        {
            var client = new HttpClient();

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("client_id", ic.client_id));
            postData.Add(new KeyValuePair<string, string>("client_secret", ic.client_secret));
            postData.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            postData.Add(new KeyValuePair<string, string>("redirect_uri", ic.redirect_uri));
            postData.Add(new KeyValuePair<string, string>("code", code));
            HttpContent content = new FormUrlEncodedContent(postData);


            var rslt = client.PostAsync("https://api.instagram.com/oauth/access_token", content).Result;
            var result = rslt.Content.ReadAsStringAsync().Result;
            OuthUser aa = JsonConvert.DeserializeObject<OuthUser>(result);
            return aa;
        }

     
    }
}
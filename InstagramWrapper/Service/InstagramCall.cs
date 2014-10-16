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
using System.Threading.Tasks;

namespace InstagramWrapper.Service
{

    public class InstagramCall
    {

        public string ApiCall(string endpoint, Dictionary<string, string> _parameters)
        {
            StringBuilder parameters = new StringBuilder();
            parameters.Append("?");
            foreach (var item in _parameters)
            {
                parameters.AppendFormat("&{0}={1}", item.Key, item.Value);
            }
            string url = string.Format("https://api.instagram.com/v1/{0}{1}", endpoint, parameters.ToString());
            var client = new HttpClient();
            var rslt = client.GetAsync(url).Result;
            var result = rslt.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string GetApi(string endpoint, Dictionary<string,string> parameters)
        {

            HttpContent hc;
            var client = new HttpClient();
        if(parameters!=null) hc = new FormUrlEncodedContent(parameters);
        else  hc=new StringContent(" ");   
            string url = string.Format("https://api.instagram.com/v1/{0}", endpoint);

            var rslt = client.PostAsync(url, hc).Result;
            var result = rslt.Content.ReadAsStringAsync().Result;
            return result;
        }
        public string DeleteApi(string endpoint) {
            var client = new HttpClient();
            string url = string.Format("https://api.instagram.com/v1/{0}", endpoint);
            var rsl = client.DeleteAsync(url).Result;
            var result = rsl.Content.ReadAsStringAsync().Result;
            return result;
        }
        public InstagramResponse UserFee(string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ApiCall("users/self/feed", parameters);
            var aa = JsonConvert.DeserializeObject<InstagramResponse>(result);
            return aa;
        }

        public InstagramResponse Tag(string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ApiCall("tags/snow/media/recent", parameters);
            var aa = JsonConvert.DeserializeObject<InstagramResponse>(result);
            return aa;
        }
        public TagResult TagSearch(string act, string query)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            parameters.Add("q", query);
            var result = ApiCall("tags/search", parameters);
            var aa = JsonConvert.DeserializeObject<TagResult>(result);
            return aa;
        }

    }



}




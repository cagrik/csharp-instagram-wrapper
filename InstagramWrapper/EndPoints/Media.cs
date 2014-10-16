using InstagramWrapper.Model;
using InstagramWrapper.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
   public class Media
    {
       InstagramCall ac;
       public Media()
       {
           ac = new InstagramCall();
       }
       public MediaResult GetMedia(string id, string act)
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token",act);
           var url = String.Format("media/{0}",id);
           var result = ac.ApiCall(url,parameters);
           var response = JsonConvert.DeserializeObject<MediaResult>(result);
           return response;
       }
       public MediaResults Search(string lat,string lng,string act, string maxtimespan="1",string mintimespan="",int distance=0) {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token",act);
           parameters.Add("lat",lat);
           parameters.Add("lng",lng);
           if (maxtimespan != "1") parameters.Add("max_timestamp", maxtimespan);
           if (mintimespan != "1") parameters.Add("min_timestamp", mintimespan);
           if (distance > 0 && distance <= 5000) parameters.Add("distance", distance.ToString());
           var url = String.Format("media/search");
           var result = ac.ApiCall(url,parameters);
           var response = JsonConvert.DeserializeObject<MediaResults>(result);
           return response;
       }

       public MediaResults GetPopular(string act) 
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           var url = String.Format("media/popular");
           var result = ac.ApiCall(url,parameters);
           var response = JsonConvert.DeserializeObject<MediaResults>(result);
           return response;
       }
    }
}

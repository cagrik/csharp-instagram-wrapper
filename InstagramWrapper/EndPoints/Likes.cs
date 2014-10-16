using InstagramWrapper.Model;
using InstagramWrapper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
   public class Likes
    {
       InstagramCall ac;
       public Likes()
       {
           ac = new InstagramCall();
       }
       public LikesResponse GetMediaLikes(string id, string act) {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           var url = String.Format("media/{0}/likes", id);
           var result = ac.ApiCall(url, parameters);
           var response = Newtonsoft.Json.JsonConvert.DeserializeObject<LikesResponse>(result);
           return response;
       }

       public LikesResponse LikeMedia(string id, string act)
       {
        
           var result = ac.GetApi(string.Format("media/{0}/likes?access_token={1}", id, act), null);
           var response = Newtonsoft.Json.JsonConvert.DeserializeObject<LikesResponse>(result);
           return response;
       }

       public LikesResponse UnlikeMedia(string id, string act)
       {

           var result = ac.DeleteApi(string.Format("media/{0}/likes?access_token={1}", id, act));

           var response = Newtonsoft.Json.JsonConvert.DeserializeObject<LikesResponse>(result);
           return response;
       }
    }
}

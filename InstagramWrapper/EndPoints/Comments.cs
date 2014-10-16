using InstagramWrapper.Model;
using InstagramWrapper.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
   public class Comments
    {
       InstagramCall ac;
       public Comments()
       {
           ac = new InstagramCall();
       }
       public CommentsResponse GetMediaComments(string id, string act)
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           var url = String.Format("media/{0}/comments",id);
           var result = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<CommentsResponse>(result);
           return response;
       }

       public string PostComment(string id, string _comment, string act) {
           Dictionary<string, string> parameters = new Dictionary<string, string>(); parameters.Add("text", _comment);
           var result = ac.GetApi(string.Format("media/{0}/comments?access_token={1}", id, act), parameters);
         
           return result;
       }

       public string DeleteComment(string commnetid, string mediaid, string act) {
           var result = ac.DeleteApi(String.Format("media/{0}/comments/{1}?access_token={2}",mediaid,commnetid,act));

           return result;
      
       }
    }
}

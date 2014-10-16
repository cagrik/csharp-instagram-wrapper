using InstagramWrapper.Model;
using InstagramWrapper.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
   public class Tags
    {
       InstagramCall ac;
       public Tags()
       {
           ac = new InstagramCall();
       }
       public TagResult GetTag(string tag, string act) {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           var url = String.Format("tags/{0}", tag);
           var result = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<TagResult>(result);
           return response;
       }
       public MediaResults GetTagMedias(string tag, string act, string next_max_tag_id = "1", string min_tag_id="1")
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           if (next_max_tag_id != "1") parameters.Add("max_id", next_max_tag_id);
           if (min_tag_id != "1") parameters.Add("min_id", min_tag_id);
           var url = String.Format("tags/{0}/media/recent", tag);
           var result = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<MediaResults>(result);
           return response;
       }
       public TagResults TagSearch(string q, string act)
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           parameters.Add("q",q);
           var url = String.Format("tags/search");
           var result = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<TagResults>(result);
           return response;
       }
       
    }
}

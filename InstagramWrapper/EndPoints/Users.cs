using InstagramWrapper.Model;
using InstagramWrapper.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
    public class Users
    {
        InstagramCall ac;
        public Users()
        {
            ac = new InstagramCall();
        }
        public UserProfile GetUser(string id, string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ac.ApiCall(string.Format("users/{0}", id), parameters);
            var response = JsonConvert.DeserializeObject<UserProfile>(result);
            return response;
        }

        public UserProfile GetUserSelf(string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ac.ApiCall(string.Format("users/self"), parameters);
            var response = JsonConvert.DeserializeObject<UserProfile>(result);
            return response;
        }

        public InstagramResponse GetUserSelfFeed(string act, string maxid = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            if (maxid != "1") parameters.Add("max_id", maxid);
            var result = ac.ApiCall("users/self/feed", parameters);
            var response = JsonConvert.DeserializeObject<InstagramResponse>(result);
            return response;
        }

        public InstagramResponse GetUserMedia(string id, string act,string maxid="1") {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            if (maxid != "1") parameters.Add("max_id", maxid);
            var result = ac.ApiCall(String.Format("users/{0}/media/recent", id), parameters);
            var response = JsonConvert.DeserializeObject<InstagramResponse>(result);
            return response;
        }

        public InstagramResponse GetUserLikedMedia(string act) {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ac.ApiCall(String.Format("users/self/media/liked"), parameters);
            var response = JsonConvert.DeserializeObject<InstagramResponse>(result);
            return response;

        }

        public UserProfiles UserSearch(string query, string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            parameters.Add("q",query);
            var result = ac.ApiCall(string.Format("users/search"), parameters);
            var response = JsonConvert.DeserializeObject<UserProfiles>(result);
            return response;
        }

        public user GetUserByUsername(string username, string act) {
            var users = UserSearch(username,act);
          
            var user = users.data.Where(x=>x.username==username).SingleOrDefault();
            var userprofile = GetUser(user.id.ToString(), act);
            if (userprofile.meta.code=="400")
            {
                userprofile.data = user;
                userprofile.data.counts = new counts();
                userprofile.data.counts.followed_by = 0;
                userprofile.data.counts.follows = 0;
                userprofile.data.counts.media = 0;
            }
            return userprofile.data;
        
        }
    }
}

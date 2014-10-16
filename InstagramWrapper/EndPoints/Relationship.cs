using InstagramWrapper.Model;
using InstagramWrapper.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
    public class Relationship
    {
        InstagramCall ac;
        public Relationship()
        {
            ac = new InstagramCall();
        }
        public UserProfiles GetUserFollows(string id, string act, string next_cursor = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            if (next_cursor != "1") parameters.Add("cursor", next_cursor);
            var result = ac.ApiCall(string.Format("users/{0}/follows", id), parameters);
            var response = JsonConvert.DeserializeObject<UserProfiles>(result);
            return response;
        }
        public UserProfiles GetUserFollowedby(string id, string act, string next_cursor = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            if (next_cursor != "1") parameters.Add("cursor", next_cursor);
            var result = ac.ApiCall(string.Format("users/{0}/followed-by", id), parameters);
            var response = JsonConvert.DeserializeObject<UserProfiles>(result);
            return response;
        }
        public Requests GetRequests(string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ac.ApiCall(string.Format("users/self/requested-by"), parameters);
            var response = JsonConvert.DeserializeObject<Requests>(result);
            return response;
        }
        public RelationshipResponse GetRelationship(string id, string act)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_token", act);
            var result = ac.ApiCall(string.Format("users/{0}/relationship", id), parameters);
            var response = JsonConvert.DeserializeObject<RelationshipResponse>(result);
            return response;
        }

        public RelationshipResponse PostRelationship(string id, string act, string action)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>(); parameters.Add("action", action);
            var result = ac.GetApi(string.Format("users/{0}/relationship?access_token={1}", id,act),parameters);
            var response = JsonConvert.DeserializeObject<RelationshipResponse>(result);
            return response;
        }
    }
}

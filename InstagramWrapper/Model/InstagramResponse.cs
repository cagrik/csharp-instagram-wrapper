using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.Model
{
    public class _InstagramResponse
    {
        public Pagination pagination { get; set; }
        public meta meta { get; set; }
    }
    public class InstagramResponse : _InstagramResponse
    {

        public List<data> data { get; set; }

    }
    public class MediaResult
    {
        public data data { get; set; }
        public meta meta { get; set; }

    }
    public class MediaResults
    {
        public Pagination pagination { get; set; }
        public List<data> data { get; set; }
        public meta meta { get; set; }

    }
    public class TagResult 
    {
        public meta meta { get; set; }
        public Tagm data { get; set; }
    }
    public class TagResults
    {
        public meta meta { get; set; }
        public List<Tagm> data { get; set; }
    }
    public class UserProfile
    {
        public meta meta { get; set; }
        public user data { get; set; }
    }
    public class UserProfiles : _InstagramResponse
    {

        public List<user> data { get; set; }
    }
    public class Requests : _InstagramResponse
    {
        List<from> data { get; set; }
    }
    public class LikesResponse
    {
        public meta meta { get; set; }
        public List<from> data { get; set; }
    }
    public class _RelationshipResponse
    {

        public string outgoing_status { get; set; }
        public bool target_user_is_private { get; set; }
        public string incoming_status { get; set; }

    }
    public class RelationshipResponse
    {
        public meta meta { get; set; }
        public _RelationshipResponse data { get; set; }
    }
    public class CommentsResponse
    {
        public meta meta { get; set; }
        public List<comment> data { get; set; }
    }
    public class Pagination
    {
        public string next_max_tag_id { get; set; }
        public string deprecation_warning { get; set; }
        public string next_max_id { get; set; }
        public string next_min_id { get; set; }
        public string min_tag_id { get; set; }
        public string next_url { get; set; }
    }
    public class meta
    {
        public string code { get; set; }
    }
    public class data
    {//attribution tags type location comments filter createdtime link likes images user_in_photo caption user_has_liked id user
        public string attribution { get; set; }
        public string[] tags { get; set; }
        public string type { get; set; }
        public location location { get; set; }
        public CommentsMedia comments { get; set; }
        public string filter { get; set; }
        public string created_time { get; set; }
        public string link { get; set; }
        public likes likes { get; set; }
        public images images { get; set; }
        public List<users_in_photo> users_in_photo { get; set; }
       public caption caption { get ; set ; }
        public bool user_has_liked { get; set; }
        public string id { get; set; }
        public user user { get; set; }
        public videos videos { get; set; }

    }
    public class LocationResponse
    {
        public meta meta { get; set; }
        public location data { get; set; }
    }
    public class LocationsResponse:_InstagramResponse
    {
        public List<location> data { get; set; }
    }
    public class location
    {
        public double latitude { get; set; }
        public string name { get; set; }
        public double longitude { get; set; }
        public string id { get; set; }
    }
    public class CommentsMedia
    {
        public int count { get; set; }
        public List<comment> data { get; set; }
    }
    public class comment
    {
        public string created_time { get; set; }
        public string text { get; set; }
        public from from { get; set; }
        public string id { get; set; }
    }
    public class from
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
    }
    public class likes
    {
        public int count { get; set; }
        public from[] data { get; set; }
    }
    public class images
    {
        public img low_resolution { get; set; }
        public img thumbnail { get; set; }
        public img standard_resolution { get; set; }
    }
    public class videos
    {
        public img low_resolution { get; set; }
        public img standard_resolution { get; set; }
    }
    public class img
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }
    public class users_in_photo
    {
        public users_in_photo()
        {
            position = null;
            user = null;
        }
        public postions position { get; set; }
        public from user { get; set; }

    }
    public class postions
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class user
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public long id { get; set; }
        public string full_name { get; set; }
        public string website { get; set; }
        public string bio { get; set; }
        public counts counts { get; set; }
    }
    public class caption
    {
        public caption()
        {
            created_time=String.Empty;
             text=String.Empty;
             id=String.Empty;
             from = null;
        }
        public string created_time { get; set; }
        public string text { get; set; }
        public from from { get; set; }
        public string id { get; set; }
    }


    public class counts
    {

        public Int64 media { get; set; }
        public Int64 followed_by { get; set; }
        public Int64 follows { get; set; }
    }
    public class Tagm
    {
        public Int64 media_count { get; set; }
        public string name { get; set; }

    }
    public class OuthUser
    {
        public string access_token { get; set; }
        public user user { get; set; }
    }
}

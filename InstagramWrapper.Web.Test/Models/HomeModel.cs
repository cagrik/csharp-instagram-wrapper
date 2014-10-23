using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstagramWrapper.Model;
namespace InstagramWrapper.Web.Test.Models
{
    public class HomeModel
    {
        public InstagramResponse UserFeed { get; set; }
        public OuthUser user { get; set; }
        public string pagetype { get; set; }
        public ProfileModel  profilmodel{ get; set; }
    }
    public class ProfileModel {
        public counts counts { get; set; }
        public RelationshipResponse followstatus { get; set; }
        public string Id { get; set; }
    }

    public class PlaceModel
    {
        public location place { get; set; }
        public MediaResults Medias { get; set; }
    }
}
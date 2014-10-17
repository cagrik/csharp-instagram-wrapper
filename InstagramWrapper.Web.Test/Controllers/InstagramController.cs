using InstagramWrapper.EndPoints;
using InstagramWrapper.Model;
using InstagramWrapper.Service;
using InstagramWrapper.Web.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InstagramWrapper.Web.Test.Controllers
{
    public class InstagramController : Controller
    {
        //
        // GET: /Instagram/

        public ActionResult Index(string code="")
        {
            HomeModel mdl = new HomeModel();
             Users usr= new Users();
            if (!Request.IsAuthenticated)
            {


                if (!string.IsNullOrEmpty(code))
                {
                    InstagramAuth ia = new InstagramAuth();
                    InstaConfig ic = new InstaConfig();
                    ic.redirect_uri = "http://devkod.com/InstagramCSharpSdk";
                    ic.client_secret = "";
                    ic.client_id = "";
                     mdl.user = ia.GetAccessToken(code,ic);
                    
                    FormsAuthentication.SetAuthCookie(mdl.user.access_token, true);
                   

                    mdl.UserFeed = usr.GetUserSelfFeed(mdl.user.access_token);
                }

            }
            else
            {
              
                    mdl.user = new OuthUser();
                    mdl.user.access_token = HttpContext.User.Identity.Name;
                    mdl.user.user = usr.GetUserSelf(mdl.user.access_token).data;
                mdl.UserFeed = usr.GetUserSelfFeed(mdl.user.access_token);
            }
            mdl.pagetype = "home";
            mdl.profilmodel= new ProfileModel();
            mdl.profilmodel.counts=mdl.user.user.counts;
            return View(mdl);
        }
        public ActionResult NextPage(string maxid)
        {
            Users usr= new Users();
            var response = usr.GetUserSelfFeed(HttpContext.User.Identity.Name,maxid);
            return View("UserFeed",response);
        }
        public ActionResult Like(string id, string actn)
        {
            Likes lk = new Likes();
            actn = actn.ToLower();
            string result=string.Empty;
            if (actn == "like"){
            var s=    lk.LikeMedia(id, HttpContext.User.Identity.Name);
            if(s.meta.code=="200") result="liked";
            }
            else if (actn == "unlike") { 
                 var s=    lk.UnlikeMedia(id, HttpContext.User.Identity.Name);
                 if (s.meta.code == "200") result = "unliked";
            }
            
            return Content(result);
        }

        public ActionResult Profile(string username)
        {
            Users u = new Users();
            HomeModel mdl = new HomeModel();
            mdl.user = new OuthUser();
            mdl.UserFeed = new InstagramResponse();
            string act=HttpContext.User.Identity.Name;
            var user = u.GetUserByUsername(username, act);
            Relationship r = new Relationship();
            var rs = r.GetRelationship(user.id.ToString(), act);
            mdl.profilmodel = new ProfileModel();
            mdl.profilmodel.Id = user.id.ToString();
            if ((rs.data.target_user_is_private&&rs.data.outgoing_status=="follows")||(!rs.data.target_user_is_private))
            {

                var userfeed = u.GetUserMedia(user.id.ToString(), act);
                mdl.user.access_token = act;
                mdl.user.user = user;
                mdl.UserFeed = userfeed;
                mdl.pagetype = "profile";

               
                mdl.profilmodel.counts = mdl.user.user.counts;
                mdl.profilmodel.followstatus = rs; 
            }
            else
            {
                mdl.profilmodel.followstatus = rs;
                return View("PrivateProfile",mdl.profilmodel);
            }
            return View("Index",mdl);
        }

        public ActionResult Follow(string UId, string actn) {
            Relationship r = new Relationship();
            var s = r.PostRelationship(UId, HttpContext.User.Identity.Name, actn);
        return Redirect(Request.UrlReferrer.AbsoluteUri);
      
        }
    }
}

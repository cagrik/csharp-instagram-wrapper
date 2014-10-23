using InstagramWrapper.Model;
using InstagramWrapper.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.EndPoints
{
   public class Locations
    {
       InstagramCall ac;
       public Locations()
       {
           ac = new InstagramCall();
       }
       public LocationResponse GetPlace(string id, string act) {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token",act);
           var url = String.Format("locations/{0}", id);
           var result = ac.ApiCall(url,parameters);
           var response = JsonConvert.DeserializeObject<LocationResponse>(result);
           return response;
       }
       public MediaResults GetPlaceMedias(string id, string act, string max_id = "1")
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           if (max_id != "1") parameters.Add("max_id",max_id);
           var url = String.Format("locations/{0}/media/recent", id);
           var result = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<MediaResults>(result);
           return response;
       }

       public LocationsResponse SearchPlacesByCoordinate(string act, string lat, string lng, string distance = "0")
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           parameters.Add("lat", lat);
           parameters.Add("lng", lng);
           if (distance != "0") parameters.Add("distance", distance);
           var url = String.Format("locations/search");
           var resuls = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<LocationsResponse>(resuls);
           return response;
       }

       public LocationsResponse SearchPlaceByFacebookPlacesId(string act, string id)
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           parameters.Add("facebook_places_id", id);
           var url = String.Format("locations/search");
           var result = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<LocationsResponse>(result);
           return response;
       }

       public LocationsResponse SearchPlaceByFoursquareV2Id(string act, string id)
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           parameters.Add("foursquare_v2_id", id);
           var url = String.Format("locations/search");
           var resuls = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<LocationsResponse>(resuls);
           return response;
       }

       public LocationResponse SearchPlaceByFoursquareId(string act, string id)
       {
           Dictionary<string, string> parameters = new Dictionary<string, string>();
           parameters.Add("access_token", act);
           parameters.Add("foursquare_id", id);
           var url = String.Format("locations/search");
           var resuls = ac.ApiCall(url, parameters);
           var response = JsonConvert.DeserializeObject<LocationResponse>(resuls);
           return response;
       }
    }
}

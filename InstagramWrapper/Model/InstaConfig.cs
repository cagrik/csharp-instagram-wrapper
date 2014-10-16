using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramWrapper.Model
{
   public class InstaConfig
    {
       public string client_id { get; set; }
       public string client_secret { get; set; }
       public string website_url { get; set; }
       public string redirect_uri { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UrumiumMVC.Common.Attributes
{
    public class LoginAttribute:Attribute
    {
        public static void LoginAthorize()
        {
            HttpCookie myCookie = HttpContext.Current.Response.Cookies["usercookie"];
            if (myCookie == null)
            {
                string s = myCookie.Value;
            }
        }
    }
}

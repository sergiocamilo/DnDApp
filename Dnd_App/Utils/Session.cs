using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dnd_App.Models;
using System.Web.Security;
using System.Text;

namespace Dnd_App.Utils
{
    public class Session
    {
        public static User CurrentSession()
        {
            var Session = new User();
            if (HttpContext.Current.Request.Cookies["session"] != null
                && HttpContext.Current.Request.Cookies["session"].Value != string.Empty)
            {
                
                Session.UserName = Encoding.UTF8.GetString(MachineKey
                    .Unprotect(Convert.FromBase64String(HttpContext
                    .Current.Request.Cookies["session"].Value)));
                if (!Session.Read(Session.UserName)) Session = null;
            }
            else
            {
                Session = null;
            }
            return Session;
        }

        public static void LogIn(User User)
        {
            var CookieSession = new HttpCookie("session");
            CookieSession.Expires = DateTime.Now.AddDays(1);
            
            CookieSession.Value = Convert.ToBase64String(MachineKey
                .Protect(Encoding.UTF8.GetBytes(User.UserName))) ;
            HttpContext.Current.Response.Cookies.Add(CookieSession);
        }

        public static void LogOut()
        {
            var CookieSession = new HttpCookie("session");
            CookieSession.Expires = DateTime.Now.AddDays(-1);
            CookieSession.Value = string.Empty;
            HttpContext.Current.Response.Cookies.Add(CookieSession);
        }

        public static Boolean IsLogged()
        {
            var user = Session.CurrentSession();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IA.Models;
using System.Web.Security;

namespace IA.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Get user id from the database.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="username">username of the needed user.</param>
        /// <returns></returns>
        public static int GetUserId(this DbSet<User> input,string username)
        {
            return input.FirstOrDefault(f => f.UserName == username).Id;
        }

        /// <summary>
        /// Get current logged in user. If no user is logged in, an empty string is returned.
        /// </summary>
        /// <returns></returns>
        public static string GetLoggedUser()
        {
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                DatabaseStore db = new DatabaseStore();
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                return FormsAuthentication.Decrypt(authCookie.Value).Name;
            }
            else
                return string.Empty;
        }
        /// <summary>
        /// Return Avatar Uri of selected user.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetUserAvatarUri(this DbSet<User> input,string username)
        {
            var rz = input.FirstOrDefault(f => f.UserName == username).avatar_uri;
            return rz!=null ? "/UserStore/" + username + rz : "/Content/Images/placeholder-user.png";
        }
    }
}
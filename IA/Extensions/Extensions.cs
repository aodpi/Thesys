using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IA.Models;
namespace IA.Extensions
{
    public static class Extensions
    {
        public static int GetUserId(this DbSet<User> input,string username)
        {
            return input.FirstOrDefault(f => f.UserName == username).Id;
        }

        /// <summary>
        /// Return Avatar Uri of selected user.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetUserAvatarUri(this DbSet<User> input,string username)
        {
            return input.FirstOrDefault(f => f.UserName == username).avatar_uri;
        }
    }
}
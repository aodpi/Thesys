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
    }
}
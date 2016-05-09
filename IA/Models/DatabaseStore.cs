using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IA.Models
{
    public class DatabaseStore:DbContext
    {
        public DatabaseStore():base("name=IAConn")
        {
        }
        public DbSet<Elevation> Elevations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NotificationChannel> NotificationChannels { get; set; }
    }
}
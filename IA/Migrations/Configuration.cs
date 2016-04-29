namespace IA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IA.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<IA.Models.DatabaseStore>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IA.Models.DatabaseStore context)
        {
            context.Elevations.AddOrUpdate(
                p => p.ElevationName,
                new Elevation { ElevationName = "Supervisor" },
                new Elevation { ElevationName = "Student" },
                new Elevation { ElevationName = "Teacher" },
                new Elevation { ElevationName = "Guest" });
            context.Users.AddOrUpdate(
                x => x.UserName,
                new User { UserName = "aodpi", Password = "aodpiram1994", ElevationId = 1 });
            context.NotificationChannels.AddOrUpdate(
                x => x.Id,
                new NotificationChannel { NotificationChannelUri = "https://db5.notify.windows.com/?token=AwYAAACT8lfDx9gxmWDKx4oBEaFYeoWWIwtMW1klTiWPV8JJ5fNvJnYBQxxbbAHcOVVvcQ%2bWUVbLgcVf04oLqwKTDSik2sgkzDXixnKKZTqfNN0kxJvYZ4IUnvS9bMLv6aogLp8%3d", UserId = 1, NotificationType = "windows_phone" },
                new NotificationChannel { NotificationChannelUri = "https://db5.notify.windows.com/?token=AwYAAAA4N76nZs8EW%2f%2fWebQBoxXk7nS2J%2fQqihVuKtQNarVbCxHfhPrikB3OX%2bjNUcvY5PTCLqoUT6C%2f5jG6z7LzI%2bX7Z5ZJbN9p5U0SN9oUZhxUGdpNgiIWoZ%2bVeBZrzZWWxmw%3d", UserId = 1, NotificationType = "windows" });
                    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                    //  to avoid creating duplicate seed data. E.g.
                    //
                    //    context.People.AddOrUpdate(
                    //      p => p.FullName,
                    //      new Person { FullName = "Andrew Peters" },
                    //      new Person { FullName = "Brice Lambson" },
                    //      new Person { FullName = "Rowan Miller" }
                    //    );
                    //
                }
    }
}

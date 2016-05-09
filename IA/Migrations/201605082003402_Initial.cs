namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Elevations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ElevationName = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 200),
                        ElevationId = c.Int(nullable: false),
                        avatar_uri = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Elevations", t => t.ElevationId, cascadeDelete: true)
                .Index(t => t.ElevationId);
            
            CreateTable(
                "dbo.NotificationChannels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationType = c.String(),
                        NotificationChannelUri = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationChannels", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "ElevationId", "dbo.Elevations");
            DropIndex("dbo.NotificationChannels", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "ElevationId" });
            DropTable("dbo.NotificationChannels");
            DropTable("dbo.Users");
            DropTable("dbo.Elevations");
        }
    }
}

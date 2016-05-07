namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Avatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "avatar_uri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "avatar_uri");
        }
    }
}

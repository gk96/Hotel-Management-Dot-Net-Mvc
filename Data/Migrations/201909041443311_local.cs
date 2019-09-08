namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class local : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "UserId", "dbo.Users");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            AlterColumn("dbo.Rooms", "CheckInDate", c => c.DateTime());
            AlterColumn("dbo.Rooms", "CheckOutDate", c => c.DateTime());
            AlterColumn("dbo.Rooms", "UserId", c => c.Int());
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.Users", "UserId");
            DropColumn("dbo.Rooms", "Name");
            DropColumn("dbo.Rooms", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "CustomerId", c => c.String());
            AddColumn("dbo.Rooms", "Name", c => c.String());
            DropForeignKey("dbo.Rooms", "UserId", "dbo.Users");
            DropIndex("dbo.Rooms", new[] { "UserId" });
            AlterColumn("dbo.Rooms", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "CheckOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rooms", "CheckInDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Rooms", "UserId");
            AddForeignKey("dbo.Rooms", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}

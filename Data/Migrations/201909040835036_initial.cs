namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "IsOccupied", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "IsOccupied", c => c.Boolean());
        }
    }
}

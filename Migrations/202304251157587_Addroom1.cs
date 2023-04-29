namespace hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addroom1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddRooms", "Floor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddRooms", "Floor", c => c.Long(nullable: false));
        }
    }
}

namespace hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddRooms", "Room_number", c => c.Long(nullable: false));
            DropColumn("dbo.AddRooms", "Room_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddRooms", "Room_name", c => c.String());
            DropColumn("dbo.AddRooms", "Room_number");
        }
    }
}

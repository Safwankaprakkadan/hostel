namespace hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class room : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddRooms",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Room_name = c.String(),
                        Block_name = c.String(),
                        Floor = c.Long(nullable: false),
                        Total_space = c.Long(nullable: false),
                        Available_space = c.Long(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddRooms");
        }
    }
}

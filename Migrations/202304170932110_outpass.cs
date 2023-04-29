namespace hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class outpass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.outPasses",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        reg_no = c.Long(nullable: false),
                        hosteler_name = c.String(),
                        Contact_no = c.Long(nullable: false),
                        date_of_outpass = c.String(),
                        time_of_departure = c.String(),
                        return_time = c.String(),
                        reason_outpass = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.outPasses");
        }
    }
}

namespace hostel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vacate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.vacates",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        hosteler_name = c.String(),
                        reg_no = c.Long(nullable: false),
                        vacating_date = c.String(),
                        vacating_reason = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.vacates");
        }
    }
}

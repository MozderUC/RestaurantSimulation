namespace RestaurantSimulation.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGuestBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guestbooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Review = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Guestbooks");
        }
    }
}

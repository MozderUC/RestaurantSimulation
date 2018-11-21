namespace RestaurantSimulation.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vegetables",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Proteins = c.Single(nullable: false),
                        Carbohydrates = c.Single(nullable: false),
                        Fats = c.Single(nullable: false),
                        Calories = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VegetableStorages", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.VegetableStorages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VegetableStock = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VegetableMenus",
                c => new
                    {
                        Vegetable_ID = c.Int(nullable: false),
                        Menu_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vegetable_ID, t.Menu_ID })
                .ForeignKey("dbo.Vegetables", t => t.Vegetable_ID, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.Menu_ID, cascadeDelete: true)
                .Index(t => t.Vegetable_ID)
                .Index(t => t.Menu_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vegetables", "ID", "dbo.VegetableStorages");
            DropForeignKey("dbo.VegetableMenus", "Menu_ID", "dbo.Menus");
            DropForeignKey("dbo.VegetableMenus", "Vegetable_ID", "dbo.Vegetables");
            DropIndex("dbo.VegetableMenus", new[] { "Menu_ID" });
            DropIndex("dbo.VegetableMenus", new[] { "Vegetable_ID" });
            DropIndex("dbo.Vegetables", new[] { "ID" });
            DropTable("dbo.VegetableMenus");
            DropTable("dbo.VegetableStorages");
            DropTable("dbo.Vegetables");
            DropTable("dbo.Menus");
        }
    }
}

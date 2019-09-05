namespace StockInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        RegionID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Region", t => t.RegionID, cascadeDelete: true)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Cedula = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gerency = c.String(),
                        Deparment = c.String(),
                        Charge = c.String(),
                        Status = c.Boolean(nullable: false),
                        OfficeID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Office", t => t.OfficeID, cascadeDelete: true)
                .Index(t => t.OfficeID);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Direction = c.String(),
                        CityID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(),
                        Marca = c.String(),
                        Model = c.String(),
                        Status = c.Boolean(nullable: false),
                        Observation = c.String(),
                        OfficeID = c.Guid(nullable: false),
                        EmployeeID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID)
                .ForeignKey("dbo.Office", t => t.OfficeID, cascadeDelete: true)
                .Index(t => t.OfficeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                        EmployeeID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Item", "OfficeID", "dbo.Office");
            DropForeignKey("dbo.Item", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "OfficeID", "dbo.Office");
            DropForeignKey("dbo.Office", "CityID", "dbo.City");
            DropForeignKey("dbo.City", "RegionID", "dbo.Region");
            DropIndex("dbo.User", new[] { "EmployeeID" });
            DropIndex("dbo.Item", new[] { "EmployeeID" });
            DropIndex("dbo.Item", new[] { "OfficeID" });
            DropIndex("dbo.Office", new[] { "CityID" });
            DropIndex("dbo.Employee", new[] { "OfficeID" });
            DropIndex("dbo.City", new[] { "RegionID" });
            DropTable("dbo.User");
            DropTable("dbo.Item");
            DropTable("dbo.Office");
            DropTable("dbo.Employee");
            DropTable("dbo.Region");
            DropTable("dbo.City");
        }
    }
}

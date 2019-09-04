namespace StockInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Office", "CityID", "dbo.City");
            DropForeignKey("dbo.Employee", "OfficeID", "dbo.Office");
            DropForeignKey("dbo.Item", "OfficeID", "dbo.Office");
            DropIndex("dbo.Employee", new[] { "OfficeID" });
            DropIndex("dbo.Office", new[] { "CityID" });
            DropIndex("dbo.Item", new[] { "OfficeID" });
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 20),
                        CityID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            AddColumn("dbo.Employee", "UnitWork", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Employee", "DepartmentID", c => c.Guid(nullable: false));
            AddColumn("dbo.Item", "DepartmentID", c => c.Guid(nullable: false));
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Employee", "Gerency", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Employee", "Charge", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Employee", "DepartmentID");
            CreateIndex("dbo.Item", "DepartmentID");
            AddForeignKey("dbo.Employee", "DepartmentID", "dbo.Department", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Item", "DepartmentID", "dbo.Department", "ID", cascadeDelete: true);
            DropColumn("dbo.Employee", "Deparment");
            DropColumn("dbo.Employee", "OfficeID");
            DropColumn("dbo.Item", "OfficeID");
            DropTable("dbo.Office");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Code = c.String(nullable: false, maxLength: 5),
                        Direction = c.String(nullable: false, maxLength: 100),
                        CityID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Item", "OfficeID", c => c.Guid(nullable: false));
            AddColumn("dbo.Employee", "OfficeID", c => c.Guid(nullable: false));
            AddColumn("dbo.Employee", "Deparment", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.Item", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "CityID", "dbo.City");
            DropIndex("dbo.Item", new[] { "DepartmentID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "CityID" });
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Employee", "Charge", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "Gerency", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Item", "DepartmentID");
            DropColumn("dbo.Employee", "DepartmentID");
            DropColumn("dbo.Employee", "UnitWork");
            DropTable("dbo.Department");
            CreateIndex("dbo.Item", "OfficeID");
            CreateIndex("dbo.Office", "CityID");
            CreateIndex("dbo.Employee", "OfficeID");
            AddForeignKey("dbo.Item", "OfficeID", "dbo.Office", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "OfficeID", "dbo.Office", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Office", "CityID", "dbo.City", "ID", cascadeDelete: true);
        }
    }
}

namespace StockInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Region", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "Gerency", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "Deparment", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "Charge", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Office", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Office", "Code", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Office", "Direction", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Item", "Type", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Item", "Marca", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Item", "Model", c => c.String(maxLength: 30));
            AlterColumn("dbo.Item", "Observation", c => c.String(maxLength: 100));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.User", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.Item", "Observation", c => c.String());
            AlterColumn("dbo.Item", "Model", c => c.String());
            AlterColumn("dbo.Item", "Marca", c => c.String());
            AlterColumn("dbo.Item", "Type", c => c.String());
            AlterColumn("dbo.Office", "Direction", c => c.String());
            AlterColumn("dbo.Office", "Code", c => c.String());
            AlterColumn("dbo.Office", "Name", c => c.String());
            AlterColumn("dbo.Employee", "Charge", c => c.String());
            AlterColumn("dbo.Employee", "Deparment", c => c.String());
            AlterColumn("dbo.Employee", "Gerency", c => c.String());
            AlterColumn("dbo.Employee", "LastName", c => c.String());
            AlterColumn("dbo.Employee", "FirstName", c => c.String());
            AlterColumn("dbo.Region", "Name", c => c.String());
            AlterColumn("dbo.City", "Name", c => c.String());
            DropColumn("dbo.User", "UserName");
        }
    }
}

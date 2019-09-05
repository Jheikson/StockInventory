namespace StockInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Gerency", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employee", "Deparment", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employee", "Charge", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Employee", "Charge", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "Deparment", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employee", "Gerency", c => c.String(nullable: false, maxLength: 20));
        }
    }
}

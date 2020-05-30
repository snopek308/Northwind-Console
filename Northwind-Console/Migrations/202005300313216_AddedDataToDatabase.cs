namespace NorthwindConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataToDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "UnitsInStock", c => c.Short(nullable: false));
            AlterColumn("dbo.Products", "ReorderLevel", c => c.Short(nullable: false));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
            AlterColumn("dbo.Products", "ReorderLevel", c => c.Short());
            AlterColumn("dbo.Products", "UnitsInStock", c => c.Short());
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}

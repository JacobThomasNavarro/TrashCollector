namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExtraPickup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Balance", c => c.Double());
            AlterColumn("dbo.Customers", "MonthlyCharge", c => c.Double());
            AlterColumn("dbo.Customers", "PickupConfirmed", c => c.Boolean());
            AlterColumn("dbo.Customers", "ExtraPickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ExtraPickup", c => c.String());
            AlterColumn("dbo.Customers", "PickupConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "MonthlyCharge", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "Balance", c => c.Double(nullable: false));
        }
    }
}

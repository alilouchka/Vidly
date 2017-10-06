namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupressionParametreDeTestDrivingLicence2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicence2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicence2", c => c.String(nullable: false, maxLength: 255));
        }
    }
}

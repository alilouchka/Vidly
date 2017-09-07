namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  MembershipTypes SET  Name = 'Pay as You Go', DiscountRate = 0,SignUPFee=0 ,DurationInMonths=  0 WHERE id = 1");
            Sql("UPDATE  MembershipTypes SET  Name = 'Monthly', DiscountRate = 10,SignUPFee=30 ,DurationInMonths=  1 WHERE id = 2");
            Sql("UPDATE  MembershipTypes SET  Name = 'Qarterly', DiscountRate = 15,SignUPFee=90 ,DurationInMonths=  3 WHERE id = 3");
            Sql("UPDATE  MembershipTypes SET  Name = 'Annual',DiscountRate = 20,SignUPFee=300 ,DurationInMonths=  12 WHERE id = 4");

           
        }
        
        public override void Down()
        {
        }
    }
}

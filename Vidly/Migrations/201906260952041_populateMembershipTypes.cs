namespace Vidly .Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypes : DbMigration
    {
        public override void Up()
        {

                Sql("Insert into MembershipTypes (Id, SignUpFee,DurationInMonths,DiscountRate,MembershipName) Values(1,0,0,0,'Pay as u go')");
                Sql("Insert into MembershipTypes (Id, SignUpFee,DurationInMonths,DiscountRate,MembershipName) Values(2,30,1,10,'Monthly')");
                Sql("Insert into MembershipTypes (Id, SignUpFee,DurationInMonths,DiscountRate,MembershipName) Values(3,90,3,15,'Yearly')");
                Sql("Insert into MembershipTypes (Id, SignUpFee,DurationInMonths,DiscountRate,MembershipName) Values(4,300,12,20,'Quarterly')");
        
        }
        
        public override void Down()
        {
        }
    }
}

namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateexistingrecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' Where Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' Where Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quaterly' Where Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' Where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}

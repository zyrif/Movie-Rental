namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeWithNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay As You Go' WHERE Id=1;");
            Sql("UPDATE MembershipTypes SET Name='One Month' WHERE Id=2;");
            Sql("UPDATE MembershipTypes SET Name='Three Months' WHERE Id=3;");
            Sql("UPDATE MembershipTypes SET Name='One Year' WHERE Id=4;");
        }
        
        public override void Down()
        {
        }
    }
}

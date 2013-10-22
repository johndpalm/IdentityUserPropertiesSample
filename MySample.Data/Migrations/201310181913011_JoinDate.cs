namespace MySample.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "JoinDate");
        }
    }
}

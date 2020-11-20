namespace ApplicationCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "PhonenNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "PhonenNumber", c => c.Int(nullable: false));
        }
    }
}

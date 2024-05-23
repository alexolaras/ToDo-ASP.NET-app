namespace FinalWebTODO.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UDbTables", "Password", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UDbTables", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

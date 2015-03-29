namespace QLTramBTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tram", "QuangDuong", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tram", "QuangDuong", c => c.Int(nullable: false));
        }
    }
}

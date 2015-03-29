namespace QLTramBTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChayMayNo",
                c => new
                    {
                        ChayMayNoId = c.String(nullable: false, maxLength: 50),
                        NgayGioMatDien = c.DateTime(nullable: false),
                        NgayGioChayMayNo = c.DateTime(nullable: false),
                        SoGioChayMayNo = c.Single(nullable: false),
                        SoLanViPham = c.Int(nullable: false),
                        TramId = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ChayMayNoId)
                .ForeignKey("dbo.Tram", t => t.TramId, cascadeDelete: true)
                .Index(t => t.TramId);
            
            CreateTable(
                "dbo.Tram",
                c => new
                    {
                        TramId = c.String(nullable: false, maxLength: 50),
                        TenTram = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        Hang = c.String(nullable: false),
                        NamXayDung = c.Int(nullable: false),
                        SoLanViPham = c.Int(nullable: false),
                        QuangDuong = c.Int(nullable: false),
                        GiaThue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChayMayNo", "TramId", "dbo.Tram");
            DropIndex("dbo.ChayMayNo", new[] { "TramId" });
            DropTable("dbo.Tram");
            DropTable("dbo.ChayMayNo");
        }
    }
}

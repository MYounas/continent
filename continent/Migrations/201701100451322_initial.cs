namespace continent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.area",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            name = c.String(maxLength: 50, unicode: false),
            //            CI_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.city", t => t.CI_id)
            //    .Index(t => t.CI_id);
            
            //CreateTable(
            //    "dbo.city",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            name = c.String(maxLength: 50, unicode: false),
            //            CO_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.country", t => t.CO_id)
            //    .Index(t => t.CO_id);
            
            //CreateTable(
            //    "dbo.country",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            name = c.String(maxLength: 50, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.city", "CO_id", "dbo.country");
            //DropForeignKey("dbo.area", "CI_id", "dbo.city");
            //DropIndex("dbo.city", new[] { "CO_id" });
            //DropIndex("dbo.area", new[] { "CI_id" });
            //DropTable("dbo.country");
            //DropTable("dbo.city");
            //DropTable("dbo.area");
        }
    }
}

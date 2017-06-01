namespace Masterdb.DataAccsess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RID = c.Int(nullable: false),
                        PRID = c.Int(nullable: false),
                        ResourceHierachyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resorce", t => t.RID, cascadeDelete: true)
                .ForeignKey("dbo.ResourceHierachy", t => t.ResourceHierachyID, cascadeDelete: true)
                .Index(t => t.RID)
                .Index(t => t.ResourceHierachyID);
            
            CreateTable(
                "dbo.Resorce",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeID = c.Int(nullable: false),
                        DetailsXml = c.String(storeType: "xml"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResourceType", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.ResourceType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResourceHierachy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResourceHierachyType", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.ResourceHierachyType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ResourceHierachyID", "dbo.ResourceHierachy");
            DropForeignKey("dbo.ResourceHierachy", "TypeID", "dbo.ResourceHierachyType");
            DropForeignKey("dbo.Details", "RID", "dbo.Resorce");
            DropForeignKey("dbo.Resorce", "TypeID", "dbo.ResourceType");
            DropIndex("dbo.ResourceHierachy", new[] { "TypeID" });
            DropIndex("dbo.Resorce", new[] { "TypeID" });
            DropIndex("dbo.Details", new[] { "ResourceHierachyID" });
            DropIndex("dbo.Details", new[] { "RID" });
            DropTable("dbo.ResourceHierachyType");
            DropTable("dbo.ResourceHierachy");
            DropTable("dbo.ResourceType");
            DropTable("dbo.Resorce");
            DropTable("dbo.Details");
        }
    }
}

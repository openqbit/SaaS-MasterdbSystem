namespace OpenQbit.Masterdb.DataAccsess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceHierachyDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RID = c.Int(nullable: false),
                        PRID = c.Int(nullable: false),
                        ResourceHierachyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resorce", t => t.RID, cascadeDelete: true)
                .ForeignKey("dbo.Resorce", t => t.PRID, cascadeDelete: true)
                .ForeignKey("dbo.ResourceHierachy", t => t.ResourceHierachyID, cascadeDelete: true)
                .Index(t => t.RID)
                .Index(t => t.PRID)
                .Index(t => t.ResourceHierachyID);
            
            CreateTable(
                "dbo.Resorce",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResourceTypeID = c.Int(nullable: false),
                        DetailsXml = c.String(storeType: "xml"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResourceType", t => t.ResourceTypeID, cascadeDelete: true)
                .Index(t => t.ResourceTypeID);
            
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
                        ResourceHierachyTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResourceHierachyType", t => t.ResourceHierachyTypeID, cascadeDelete: true)
                .Index(t => t.ResourceHierachyTypeID);
            
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
            DropForeignKey("dbo.ResourceHierachyDetails", "ResourceHierachyID", "dbo.ResourceHierachy");
            DropForeignKey("dbo.ResourceHierachy", "ResourceHierachyTypeID", "dbo.ResourceHierachyType");
            DropForeignKey("dbo.ResourceHierachyDetails", "PRID", "dbo.Resorce");
            DropForeignKey("dbo.ResourceHierachyDetails", "RID", "dbo.Resorce");
            DropForeignKey("dbo.Resorce", "ResourceTypeID", "dbo.ResourceType");
            DropIndex("dbo.ResourceHierachy", new[] { "ResourceHierachyTypeID" });
            DropIndex("dbo.Resorce", new[] { "ResourceTypeID" });
            DropIndex("dbo.ResourceHierachyDetails", new[] { "ResourceHierachyID" });
            DropIndex("dbo.ResourceHierachyDetails", new[] { "PRID" });
            DropIndex("dbo.ResourceHierachyDetails", new[] { "RID" });
            DropTable("dbo.ResourceHierachyType");
            DropTable("dbo.ResourceHierachy");
            DropTable("dbo.ResourceType");
            DropTable("dbo.Resorce");
            DropTable("dbo.ResourceHierachyDetails");
        }
    }
}

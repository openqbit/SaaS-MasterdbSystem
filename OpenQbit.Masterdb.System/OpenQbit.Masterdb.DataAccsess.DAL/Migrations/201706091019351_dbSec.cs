namespace OpenQbit.Masterdb.DataAccsess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbSec : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Details", "RID", "dbo.Resorce");
            DropForeignKey("dbo.Details", "ResourceHierachyID", "dbo.ResourceHierachy");
            DropIndex("dbo.Details", new[] { "RID" });
            DropIndex("dbo.Details", new[] { "ResourceHierachyID" });
            RenameColumn(table: "dbo.Resorce", name: "TypeID", newName: "ResourceTypeID");
            RenameColumn(table: "dbo.ResourceHierachy", name: "TypeID", newName: "ResourceHierachyTypeID");
            RenameIndex(table: "dbo.Resorce", name: "IX_TypeID", newName: "IX_ResourceTypeID");
            RenameIndex(table: "dbo.ResourceHierachy", name: "IX_TypeID", newName: "IX_ResourceHierachyTypeID");
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
            
            DropTable("dbo.Details");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.ResourceHierachyDetails", "ResourceHierachyID", "dbo.ResourceHierachy");
            DropForeignKey("dbo.ResourceHierachyDetails", "PRID", "dbo.Resorce");
            DropForeignKey("dbo.ResourceHierachyDetails", "RID", "dbo.Resorce");
            DropIndex("dbo.ResourceHierachyDetails", new[] { "ResourceHierachyID" });
            DropIndex("dbo.ResourceHierachyDetails", new[] { "PRID" });
            DropIndex("dbo.ResourceHierachyDetails", new[] { "RID" });
            DropTable("dbo.ResourceHierachyDetails");
            RenameIndex(table: "dbo.ResourceHierachy", name: "IX_ResourceHierachyTypeID", newName: "IX_TypeID");
            RenameIndex(table: "dbo.Resorce", name: "IX_ResourceTypeID", newName: "IX_TypeID");
            RenameColumn(table: "dbo.ResourceHierachy", name: "ResourceHierachyTypeID", newName: "TypeID");
            RenameColumn(table: "dbo.Resorce", name: "ResourceTypeID", newName: "TypeID");
            CreateIndex("dbo.Details", "ResourceHierachyID");
            CreateIndex("dbo.Details", "RID");
            AddForeignKey("dbo.Details", "ResourceHierachyID", "dbo.ResourceHierachy", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Details", "RID", "dbo.Resorce", "ID", cascadeDelete: true);
        }
    }
}

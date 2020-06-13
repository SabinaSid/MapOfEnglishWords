namespace MapOfEnglishWords.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Translation = c.String(),
                        Example = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParentChild",
                c => new
                    {
                        ChildId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChildId, t.ParentId })
                .ForeignKey("dbo.Word", t => t.ChildId)
                .ForeignKey("dbo.Word", t => t.ParentId)
                .Index(t => t.ChildId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParentChild", "ParentId", "dbo.Word");
            DropForeignKey("dbo.ParentChild", "ChildId", "dbo.Word");
            DropIndex("dbo.ParentChild", new[] { "ParentId" });
            DropIndex("dbo.ParentChild", new[] { "ChildId" });
            DropTable("dbo.ParentChild");
            DropTable("dbo.Word");
        }
    }
}

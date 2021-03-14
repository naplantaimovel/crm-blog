namespace crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        BlogPostId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Texto = c.String(),
                        Autor = c.String(),
                        Data = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostId)
                .ForeignKey("dbo.Blog", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        Status = c.Int(nullable: false),
                        Blog_BlogId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Blog", t => t.Blog_BlogId)
                .Index(t => t.Blog_BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPost", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Blog", "Blog_BlogId", "dbo.Blog");
            DropIndex("dbo.Blog", new[] { "Blog_BlogId" });
            DropIndex("dbo.BlogPost", new[] { "BlogId" });
            DropTable("dbo.Blog");
            DropTable("dbo.BlogPost");
        }
    }
}

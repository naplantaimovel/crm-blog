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
                        Slug = c.String(),
                        Titulo = c.String(),
                        Texto = c.String(),
                        Autor = c.String(),
                        Img = c.String(),
                        Data = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPost");
        }
    }
}

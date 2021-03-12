namespace crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogArtigo",
                c => new
                    {
                        BlogArtigoId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Texto = c.String(),
                        BlogCategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogArtigoId)
                .ForeignKey("dbo.BlogCategoria", t => t.BlogCategoriaId, cascadeDelete: true)
                .Index(t => t.BlogCategoriaId);
            
            CreateTable(
                "dbo.BlogCategoria",
                c => new
                    {
                        BlogCategoriaId = c.Int(nullable: false, identity: true),
                        Categoria = c.String(),
                    })
                .PrimaryKey(t => t.BlogCategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogArtigo", "BlogCategoriaId", "dbo.BlogCategoria");
            DropIndex("dbo.BlogArtigo", new[] { "BlogCategoriaId" });
            DropTable("dbo.BlogCategoria");
            DropTable("dbo.BlogArtigo");
        }
    }
}

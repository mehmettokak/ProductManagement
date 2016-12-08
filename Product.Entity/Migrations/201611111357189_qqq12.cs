namespace Product.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qqq12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductFeature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "ProductId", "dbo.product");
            DropForeignKey("dbo.ProductFeature", "ProductId", "dbo.product");
            DropForeignKey("dbo.product", "CategoryId", "dbo.Category");
            DropIndex("dbo.ProductImage", new[] { "ProductId" });
            DropIndex("dbo.ProductFeature", new[] { "ProductId" });
            DropIndex("dbo.product", new[] { "CategoryId" });
            DropTable("dbo.ProductImage");
            DropTable("dbo.ProductFeature");
            DropTable("dbo.product");
            DropTable("dbo.Category");
        }
    }
}

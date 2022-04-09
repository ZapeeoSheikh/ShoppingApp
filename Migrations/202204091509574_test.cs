namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.BuyerId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.BuyerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Image = c.String(),
                        SellerId = c.Int(nullable: false),
                        ProductStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductStatus", t => t.ProductStatusId)
                .ForeignKey("dbo.Users", t => t.SellerId)
                .Index(t => t.SellerId)
                .Index(t => t.ProductStatusId);
            
            CreateTable(
                "dbo.ProductStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SellerId", "dbo.Users");
            DropForeignKey("dbo.Products", "ProductStatusId", "dbo.ProductStatus");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductStatusId" });
            DropIndex("dbo.Products", new[] { "SellerId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductStatus");
            DropTable("dbo.Products");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}

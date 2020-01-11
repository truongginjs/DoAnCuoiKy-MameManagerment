namespace Design.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 450),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.name, unique: true);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        detail = c.String(),
                        amount = c.Int(nullable: false),
                        publisher = c.String(nullable: false),
                        purchaseCost = c.Long(nullable: false),
                        SaleCost = c.Long(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        name = c.String(maxLength: 450),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.name, unique: true);
            
            CreateTable(
                "dbo.Humen",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        dateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        deposit = c.Long(nullable: false),
                        placePayment = c.Int(nullable: false),
                        modePayment = c.Int(nullable: false),
                        dateOfTrans = c.DateTime(nullable: false),
                        name = c.String(maxLength: 450),
                        deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "name" });
            DropIndex("dbo.Games", new[] { "name" });
            DropIndex("dbo.Games", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "name" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Humen");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
        }
    }
}

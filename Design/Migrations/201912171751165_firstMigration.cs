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
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                        name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        category_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
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
                        name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "category_id", "dbo.Categories");
            DropIndex("dbo.Games", new[] { "category_id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Humen");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
        }
    }
}

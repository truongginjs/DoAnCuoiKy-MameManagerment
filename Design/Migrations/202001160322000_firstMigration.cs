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
                        Id = c.Long(nullable: false, identity: true),
                        Detail = c.String(),
                        Name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Detail = c.String(),
                        Amount = c.Int(nullable: false),
                        Publisher = c.String(nullable: false),
                        PurchaseCost = c.Long(nullable: false),
                        SaleCost = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Category_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.GameInTrans",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Game_Id = c.Long(),
                        Transaction_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.Transactions", t => t.Transaction_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Deposit = c.Long(nullable: false),
                        PlacePayment = c.Int(nullable: false),
                        ModePayment = c.Int(nullable: false),
                        DateOfTrans = c.DateTime(nullable: false),
                        paymentAmount = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameInTrans", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.GameInTrans", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "Category_Id", "dbo.Categories");
            DropIndex("dbo.GameInTrans", new[] { "Transaction_Id" });
            DropIndex("dbo.GameInTrans", new[] { "Game_Id" });
            DropIndex("dbo.Games", new[] { "Category_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.GameInTrans");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
        }
    }
}

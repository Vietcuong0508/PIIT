namespace CoinMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CoinViewModels", newName: "Coins");
            RenameTable(name: "dbo.MarketViewModels", newName: "Markets");
            AddColumn("dbo.Coins", "MarketId_Id", c => c.Int());
            AlterColumn("dbo.Coins", "Volumn24h", c => c.String(nullable: false));
            CreateIndex("dbo.Coins", "MarketId_Id");
            AddForeignKey("dbo.Coins", "MarketId_Id", "dbo.Markets", "Id");
            DropColumn("dbo.Coins", "MarketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coins", "MarketId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Coins", "MarketId_Id", "dbo.Markets");
            DropIndex("dbo.Coins", new[] { "MarketId_Id" });
            AlterColumn("dbo.Coins", "Volumn24h", c => c.Double(nullable: false));
            DropColumn("dbo.Coins", "MarketId_Id");
            RenameTable(name: "dbo.Markets", newName: "MarketViewModels");
            RenameTable(name: "dbo.Coins", newName: "CoinViewModels");
        }
    }
}
